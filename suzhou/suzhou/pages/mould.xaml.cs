using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Windows.Threading;
namespace suzhou.pages
{
    /// <summary>
    /// firm.xaml 的交互逻辑
    /// </summary>
    public partial class mould : Page
    {
        static string ip = "127.0.0.1";	// 172.16.153.11
        String connectStr = "server=" + ip + "; port=3306; user=root; database=displayptf;"; // 数据库连接信息
        int[] num = new int[5];
        int[] M_num = new int[6];
        int[] part = new int[6];
        int[] cycle_n1 = new int[6];
        int[] cycle_n2 = new int[6];
        int[] cycle_n3 = new int[6];
        public DispatcherTimer ShowTimer;
        //int sig = 0;

        public string id { get; set; }
        public mould()
        {
            InitializeComponent();
            //在这里窗体加载的时候不执行文本框赋值，窗体上不会及时的把时间显示出来，而是等待了片刻才显示了出来
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0,15, 0);
            ShowTimer.Start();
        }

        private void ShowCurTimer(object sender, EventArgs e)
        {
            mould_summary_change();
            //if (sig == 0)
            //{
            //    m1.Height = 200;
            //    sig = 1;
            //}
            //else
            //{
            //    m1.Height = 280;
            //    sig = 0;
            //}

        }

        private void MapView_Loaded(object sender, RoutedEventArgs e)
        {
            //String rootpath = AppDomain.CurrentDomain.BaseDirectory;
            //rootpath = rootpath.Substring(0, rootpath.LastIndexOf("\\"));
            //rootpath = rootpath.Substring(0, rootpath.LastIndexOf("\\"));
            //rootpath = rootpath.Substring(0, rootpath.LastIndexOf("\\"));
            //String url = rootpath + "\\image\\模具1.png";
            //Uri uri = new Uri((String)url);
            //webBrowser.Navigate(uri);

        }
        
        // 动态生成模具列表
        private void mouldList()
        {
            string mouldName = "模具";
            for(int i = 0; i < 6; i++)
            {
                TextBlock tx = new TextBlock();
                tx.Text = mouldName + (i + 1).ToString();
                tx.FontSize = 24;
                tx.Margin = new Thickness(20, 11, 5, 11);
                tx.Foreground = new SolidColorBrush(Colors.White);

                tx.MouseLeftButtonDown += new MouseButtonEventHandler(mouldListClick);
                tx.MouseEnter += new MouseEventHandler(enter);
                tx.MouseLeave += new MouseEventHandler(leave);

                mouldlist.Children.Add(tx);
            }
            // 模具点击、鼠标移入移出事件
            void mouldListClick(object sender, RoutedEventArgs e)
            {
                TextBlock tx = sender as TextBlock;
                string name = tx.Text;
                int index = int.Parse(name[2].ToString()) - 1;
                mould_summary(index);
                BitmapImage imgSource = new BitmapImage(new Uri("/image/mouldimage/MC1_" + (index + 1).ToString() + ".png", UriKind.Relative));
                mc1.Source = imgSource;
                BitmapImage imgSource1 = new BitmapImage(new Uri("/image/mouldimage/MC2_" + (index + 1).ToString() + ".png", UriKind.Relative));
                mc2.Source = imgSource1;
            }
            void enter(object sender, RoutedEventArgs e)
            {
                TextBlock tx = sender as TextBlock;
                tx.Foreground = new SolidColorBrush(Colors.LawnGreen);
            }
            void leave(object sender, RoutedEventArgs e)
            {
                TextBlock tx = sender as TextBlock;
                tx.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void mould_summary(int i)
        {
            Random rd = new Random();
            aim_rate.Text = rd.Next(5, 50).ToString() + "%";//停止时间
            aim_rate_Copy.Text = rd.Next(10, 60).ToString() + "%";
            aim_rate_Copy1.Text = rd.Next(8, 30).ToString() + "%";
            aim_rate_Copy2.Text = rd.Next(6, 50).ToString() + "%";
            cycle_time.Text = "15"; /*rd.Next(14, 16).ToString() + "."+rd.Next(0, 9).ToString();*/
            cycle_time_Copy.Text = rd.Next(14, 16).ToString() + "." + rd.Next(0, 9).ToString();
            cycle_time_Copy1.Text = rd.Next(14, 16).ToString() + "." + rd.Next(0, 9).ToString();
            cycle_time_Copy2.Text = rd.Next(14, 16).ToString() + "." + rd.Next(0, 9).ToString();
            num[0] = M_num[i];
            num[1] = cycle_n1[i];
            num[2] = cycle_n2[i];
            num[3]=cycle_n3[i] = num[0] - num[1] - num[2];
            cycle_number.Text = num[0].ToString(); ; /*rd.Next(14, 16).ToString() + "."+rd.Next(0, 9).ToString();*/
            cycle_number_Copy.Text = num[1].ToString();
            cycle_number_Copy1.Text = num[2].ToString();
            cycle_number_Copy2.Text = num[3].ToString();
            part_ID_Copy1.Text = num[0].ToString();
            num[4] = part[i];
            part_ID.Text = num[4].ToString();
            part_ID_Copy.Text = num[4].ToString();
            M_name.Text = "模具" + (i+1).ToString();
            M_code.Text = "MNQ536" + i.ToString();
        }
        private void mould_summary_change()
        {
            Random rd = new Random();
            aim_rate.Text = rd.Next(5, 50).ToString() + "%";//停止时间
            aim_rate_Copy.Text = rd.Next(10, 60).ToString() + "%";
            aim_rate_Copy1.Text = rd.Next(8, 30).ToString() + "%";
            aim_rate_Copy2.Text = rd.Next(6, 50).ToString() + "%";
            cycle_time.Text = "15"; /*rd.Next(14, 16).ToString() + "."+rd.Next(0, 9).ToString();*/
            cycle_time_Copy.Text = rd.Next(14, 16).ToString() + "." + rd.Next(0, 9).ToString();
            cycle_time_Copy1.Text = rd.Next(14, 16).ToString() + "." + rd.Next(0, 9).ToString();
            cycle_time_Copy2.Text = rd.Next(14, 16).ToString() + "." + rd.Next(0, 9).ToString();
            num[0] += 1;
            for (int i = 0; i < 6; i++)
            {
                M_num[i] += 1;
            }
            if (rd.Next(0, 3) < 1)
            {
                num[1] += 1;
                for(int i = 0; i < 6; ++i)
                {
                    cycle_n1[i] += 1;
                }
            }
            else if(rd.Next(0,3)<1)
            {
                num[2] += 1;
                for (int i = 0; i < 6; ++i)
                {
                    cycle_n2[i] += 1;
                }
            }
            for(int i = 0; i < 6; i++)
            {
                cycle_n3[i] = M_num[i] - cycle_n1[i] - cycle_n2[i];
            }
            cycle_number.Text = num[0].ToString(); ; /*rd.Next(14, 16).ToString() + "."+rd.Next(0, 9).ToString();*/
            cycle_number_Copy.Text = num[1].ToString();
            cycle_number_Copy1.Text = num[2].ToString();
            cycle_number_Copy2.Text = (num[0] - num[1] - num[2]).ToString();
            part_ID_Copy1.Text = num[0].ToString();
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Random rc = new Random();
            for (int i = 0; i < 6; ++i)
            {
                M_num[i] = rc.Next(3000, 10000);
                part[i] = rc.Next(0, 13);
                cycle_n1[i] = rc.Next(10, 666);
                cycle_n2[i] = rc.Next(200, 1400);
            }

            //mould_summary(0);
            //BitmapImage imgSource = new BitmapImage(new Uri("/image/mouldimage/MC1_1.png", UriKind.Relative));
            //mc1.Source = imgSource;
            //BitmapImage imgSource1 = new BitmapImage(new Uri("/image/mouldimage/MC2_1.png", UriKind.Relative));
            //mc2.Source = imgSource1;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // 加载全平台统计信息
            infoLoad();
            // 加载模具列表
            mouldList();

            var para = 0;
            if (id != null)
            {
                para = int.Parse(id) - 1;
            }
            //else { para = 0; }
            Random rc = new Random();
            for (int i = 0; i < 6; ++i)
            {
                M_num[i] = rc.Next(3000, 10000);
                part[i] = rc.Next(0, 13);
                cycle_n1[i] = rc.Next(10, 666);
                cycle_n2[i] = rc.Next(200, 1400);
            }

            mould_summary(para);

            BitmapImage imgSource = new BitmapImage(new Uri("/image/mouldimage/MC1_" + (para + 1).ToString() + ".png", UriKind.Relative));
            mc1.Source = imgSource;
            BitmapImage imgSource1 = new BitmapImage(new Uri("/image/mouldimage/MC2_" + (para + 1).ToString() + ".png", UriKind.Relative));
            mc2.Source = imgSource1;

        }


        // ------------------ 分割线 -------------------------        
        // 加载统计信息
        private void infoLoad()
        {
            string CP_sum_sql = string.Format("select count(*) from company where CP_ID is not null");//查询企业数
            CP_sum.Text += Mysql_search(CP_sum_sql).ToString();//给企业数量显示栏赋值
            //查询并显示设备总数
            string EQP_sum_sql = string.Format("select count(*) from equipment");
            EQP_sum.Text += Mysql_search(EQP_sum_sql).ToString();
            //查询并显示订单总数
            string Order_sum_sql = string.Format("select count(*) from orders");
            Order_sum.Text += Mysql_search(Order_sum_sql);
            //查询并显示正在执行的订单数量
            string EXE_Order_sum_sql = string.Format("select count(OD_ID) from eqp_md");
            EXE_Order.Text += Mysql_search(EXE_Order_sum_sql);
        }

        //数据库查询函数，
        //查询数据统计结果，
        //    返回一个数值；
        private Object Mysql_search(string sql_string)
        {
            //string connetStr = "server=127.0.0.1;port=3306;user=root;database=displayptf";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                string CP_sum_sql = sql_string;
                MySqlCommand CP_sum_cmd = new MySqlCommand(CP_sum_sql, conn);
                Object CP_sum_result = CP_sum_cmd.ExecuteScalar();
                if (CP_sum_result != null)//查询结果不为空
                {
                    return CP_sum_result;
                }
            }
            catch (MySqlException ex)//数据库连接异常处理
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    default:
                        //MessageBox.Show("其他数据库连接错误");
                        break;
                }
            }
            finally
            {
                conn.Close();
            }
            return null;
        }


        // 搜索栏点击事件
        private void company_Search_Click(object sender, RoutedEventArgs e)
        {
            company company = new company();
            string content = et1.Text;
            MySqlConnection connection = new MySqlConnection(connectStr);

            bool isID(string para)  // 判断输入的是否是ID
            {
                Boolean flag = true;
                try { int.Parse(para); }
                catch { flag = false; }
                return flag;
            }

            void searchMysql(string mysql, MySqlConnection conn)
            {
                try
                {
                    conn.Open();
                    string sql = string.Format(mysql, content);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        company.cp_name = reader["CP_name"].ToString();
                        company.cp_id = reader["CP_ID"].ToString();
                        this.NavigationService.Navigate(company);
                    }
                    else
                    {
                        MessageBox.Show("您查找的公司不存在,请检查后重新查询!");
                    }
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("连接数据库失败，请联系管理员");
                            break;
                        default:
                            MessageBox.Show("无效用户名或密码，请重试");
                            break;
                    }
                }
            }
            if (isID(content))
            {
                string mysql = "select * from company where CP_ID = ('{0}')";
                searchMysql(mysql, connection);
            }
            else
            {
                string mysql = "select * from company where CP_name = ('{0}')";
                searchMysql(mysql, connection);
            }
        }

        private void order_Search_Click(object sender, RoutedEventArgs e)
        {
            order order = new order();
            string content = et2.Text;
            MySqlConnection conn = new MySqlConnection(connectStr);
            string sql = string.Format("select * from orders where OD_ID = ('{0}')", content);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    order.content = et2.Text;
                    this.NavigationService.Navigate(order);
                }
                else
                {
                    MessageBox.Show("您输入的订单号不存在，请重新输入!");
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("连接数据库失败，请联系管理员");
                        break;
                    default:
                        MessageBox.Show("无效用户名或密码，请重试");
                        break;
                }
            }
        }

        private void mould_Search_Click(object sender, RoutedEventArgs e)
        {
            mould mould = new mould();
            string content = et3.Text;
            //mould.content = content;
            this.NavigationService.Navigate(mould);
        }

        private void logistics_Search_Click(object sender, RoutedEventArgs e)
        {
            logistics logistics = new logistics();
            string content = et4.Text;
            //logistics.content = content;
            this.NavigationService.Navigate(logistics);
        }
    }
}
