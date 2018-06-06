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

namespace suzhou.pages
{
    /// <summary>
    /// firm.xaml 的交互逻辑
    /// </summary>
    public partial class order : Page
    {
        static string ip = "127.0.0.1";	// 172.16.153.11
        String connectStr = "server=" + ip + "; port=3306; user=root; database=displayptf;"; // 数据库连接信息
        List<string> csidlist;//客户id
        List<int> odidlist;//订单id
        List<int> odstatelist;//订单完成状态
        List<Decimal> odvaluelist;//订单价值

        List<int> modleidlist;//用订单id查到的模具id

        List<int> mdstatelist;//单个订单下的所有模具的加工状态

        List<StackPanel> childProgressSpList = new List<StackPanel>();

        List<int> flag = new List<int>();//列表开关状态

        public string content { set; get; }
        //public string orderID { set; get; }
        //public string customerName { set; get; }
        //public string orderProgress { set; get; }
        //public string orderValue { set; get; }
        //public string orderCompany { set; get; }
        public order()
        {
            InitializeComponent();
        }

        // 订单页面加载时
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            infoLoad(); // 加载统计信息

            readOrderInfo(content);

            int length = odstatelist.Count();
            for (int i = 0; i < length; i++)
            {
                addProgress(i, odstatelist[i]);
                flag.Add(0);
            }

        }


        //传入该订单在List中的下标
        public void findMdState(int i)
        {
            //String connectstr = "server=127.0.0.1;port=3306;user=root;database=11";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                modleidlist = new List<int>();  //存储当前订单的所有模具id
                String sql = string.Format("select * from od_md where OD_ID=('{0}')",odidlist[i]);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    modleidlist.Add((int)reader["MD_ID"]);
                }

                conn.Close();//拿到模具id后关闭链接，准备新建查询通过模具id拿到模具状态(不关再次查询会报错)

                mdstatelist = new List<int>();
                //根据模具id查找设备模具表中的模具加工状态信息
                for (int j=0;j<modleidlist.Count;j++)
                {
                    conn.Open();
                    String sql1 = string.Format("select * from eqp_md where MD_ID=('{0}')", modleidlist[j]);
                    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                    //MessageBox.Show(mdstatelist.Count.ToString());
                    MySqlDataReader reader1 = cmd1.ExecuteReader();

                    while (reader1.Read())
                    {
                        int mdstate = (int)reader1["MD_Progress"];
                        mdstatelist.Add(mdstate);
                    }
                    conn.Close();
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("findstate连接数据库失败，请联系管理员");
                        break;
                    default:
                        MessageBox.Show("无效用户名或密码，请重试");
                        break;
                }
                conn.Close();
            }
        }

        public void addChildProgress(int whichorder,int mdindex,int state)
        {
            WrapPanel wp = new WrapPanel();
            wp.Height = 50;

            Label l = new Label();
            l.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            l.Content = "模具" + (mdindex + 1).ToString() + "";
            l.FontSize = 16;
            l.Height = 28;

            //添加进度条
            Rectangle r1 = new Rectangle();
            SolidColorBrush scb = new SolidColorBrush(Color.FromRgb(94, 184, 96));
            //LinearGradientBrush scb = new LinearGradientBrush(Color.FromRgb(10, 102, 53),  Color.FromRgb(106, 205, 154),  0);
            r1.Margin = new Thickness(24, 0, 0, 0);
            r1.Width = state * 8;
            r1.Height = 20;
            r1.Fill = scb;

            Label l2 = new Label();
            l2.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            l2.Content = state.ToString() + "%";
            l2.Height = 28;

            wp.Children.Add(l);
            wp.Children.Add(r1);
            wp.Children.Add(l2);
            childProgressSpList[whichorder].Children.Add(wp);
        }


        public void addProgress(int odindex,int state)
        {
            Expander ex = new Expander();
            ex.Height = 50;
            ex.Width = 50;
            StackPanel childProgressSp = new StackPanel();//每个订单完成状态下用来加载子模具完成状态的面板

            WrapPanel wp = new WrapPanel();
            wp.Height = 50;

            Label l = new Label();
            l.Margin = new Thickness(30, 0, 0, 0);
            l.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            l.Content = "订单" + (odindex + 1).ToString() + "";
            l.FontSize = 20;
            l.Height = 38;

            //添加进度条
            Rectangle r1 = new Rectangle();
            LinearGradientBrush scb = new LinearGradientBrush(Color.FromRgb(253, 204, 156), Color.FromRgb(252, 152, 36), 0);
            r1.Margin = new Thickness(40,0,0,0);
            r1.Width = state*10;
            r1.Height = 28;
            r1.Fill = scb;
            r1.MouseLeftButtonDown += new MouseButtonEventHandler(rec_click);

            
            void rec_click(object sender, EventArgs e)
            {
                

                order_csid.Text = csidlist[odindex];
                order_id.Text = odidlist[odindex].ToString();
                order_state.Text = odstatelist[odindex].ToString()+"%";
                order_value.Text = odvaluelist[odindex].ToString();

                findMdState(odindex);//更新了modestatelist(该订单的模具状态列表)

                //MessageBox.Show("xxxxx");

                childProgressSp.Children.Clear();//防止重复点击多次加载子进度条

                

                //点击订单进度条要加载订单包含的模具的完成进度,根据查找到的一个订单包含的模具数量初始化模具进度条

                //实现再次点击关闭列表
                if (flag[odindex] == 0)
                {
                    //实现打开当前列表，关闭其它模具列表
                    
                    //for (int i = 0; i < childProgressSpList.Count; i++)
                    //{
                    //    childProgressSpList[i].Children.Clear();
                    //    flag[i] = 0;
                    //}


                    for (int i = 0; i < modleidlist.Count; i++)
                    {
                        addChildProgress(odindex, i, mdstatelist[i]);
                    }
                    flag[odindex] = 1;//记录订单的模具列表打开了
                }
                else
                {
                    childProgressSp.Children.Clear();
                    flag[odindex] = 0;
                }

                
            }

            Label l2 = new Label();
            l2.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            l2.Content = state.ToString()+"%";
            l2.Height = 28;

            wp.Children.Add(l);
            wp.Children.Add(r1);
            wp.Children.Add(l2);
            progressSp.Children.Add(wp);


            //模具进度条面板设置
            childProgressSp.Margin = new Thickness(55,5,0,5);
            childProgressSpList.Add(childProgressSp);
            progressSp.Children.Add(childProgressSp);

            childProgressSp.MouseLeftButtonDown += new MouseButtonEventHandler(close_childProgress);

            void close_childProgress(object sender, EventArgs e)
            {
                //再次单击子进度条关闭子进度条
                childProgressSp.Children.Clear();
            }
        }

        
        //public void orderProgress()
        //{
        //    LinearGradientBrush scb = new LinearGradientBrush(Color.FromRgb(63, 169, 233), Color.FromRgb(16, 111, 197), 0);
        //    this.rectangle1.Width = 1000;
        //    this.rectangle1.Fill = scb;
        //    //this.label2.Margin = new Thickness(1000, this.label2.Margin.Top, this.label2.Margin.Right, this.label2.Margin.Bottom);
        //    label2.Content = 450;
        //}

        
        // 读取并保存订单信息
        public void readOrderInfo(string content)
        {
            if (content == null) content = "1";
            int index = int.Parse(content) - 1;
            //String connectstr = "server=127.0.0.1;port=3306;user=root;database=11";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                String sql = "select * from orders";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                csidlist = new List<string>();
                odidlist = new List<int>();
                odstatelist = new List<int>();
                odvaluelist = new List<Decimal>();
                while (reader.Read())
                {
                    csidlist.Add((string)reader["Customer_ID"]);
                    odidlist.Add((int)reader["OD_ID"]);
                    odstatelist.Add((int)reader["OD_compstaus"]);
                    odvaluelist.Add((Decimal)reader["OD_value"]);
                }
                conn.Close();
                order_csid.Text = csidlist[index];
                order_id.Text = odidlist[index].ToString();
                order_state.Text = odstatelist[index].ToString()+"%";
                order_value.Text = odvaluelist[index].ToString();

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
                conn.Close();
            }

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
            MySqlConnection conn = new MySqlConnection(connectStr);
            string sql = string.Format("select * from mould where MD_ID = ('{0}')", content);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    mould.id = et3.Text;
                    this.NavigationService.Navigate(mould);
                }
                else
                {
                    MessageBox.Show("您输入的模具号不存在，请重新输入!");
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

        private void logistics_Search_Click(object sender, RoutedEventArgs e)
        {
            logistics logistics = new logistics();
            string content = et4.Text;
            //logistics.content = content;
            this.NavigationService.Navigate(logistics);
        }

    }
}
