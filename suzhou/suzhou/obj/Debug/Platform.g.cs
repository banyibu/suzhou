﻿#pragma checksum "..\..\Platform.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5703EBEA4B353A1D20293A0CB4FD2801"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using suzhou;


namespace suzhou {
    
    
    /// <summary>
    /// Platform
    /// </summary>
    public partial class Platform : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\Platform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock home;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Platform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock firm;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Platform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock order;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Platform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock mould;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Platform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock logistics;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Platform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_Time;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Platform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_User;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Platform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Logout;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\Platform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame framePage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/suzhou;component/platform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Platform.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\Platform.xaml"
            ((suzhou.Platform)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.home = ((System.Windows.Controls.TextBlock)(target));
            
            #line 32 "..\..\Platform.xaml"
            this.home.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.home_Click);
            
            #line default
            #line hidden
            
            #line 32 "..\..\Platform.xaml"
            this.home.MouseEnter += new System.Windows.Input.MouseEventHandler(this.home_enter);
            
            #line default
            #line hidden
            
            #line 32 "..\..\Platform.xaml"
            this.home.MouseLeave += new System.Windows.Input.MouseEventHandler(this.home_leave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.firm = ((System.Windows.Controls.TextBlock)(target));
            
            #line 33 "..\..\Platform.xaml"
            this.firm.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.firm_Click);
            
            #line default
            #line hidden
            
            #line 33 "..\..\Platform.xaml"
            this.firm.MouseEnter += new System.Windows.Input.MouseEventHandler(this.firm_enter);
            
            #line default
            #line hidden
            
            #line 33 "..\..\Platform.xaml"
            this.firm.MouseLeave += new System.Windows.Input.MouseEventHandler(this.firm_leave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.order = ((System.Windows.Controls.TextBlock)(target));
            
            #line 34 "..\..\Platform.xaml"
            this.order.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.order_Click);
            
            #line default
            #line hidden
            
            #line 34 "..\..\Platform.xaml"
            this.order.MouseEnter += new System.Windows.Input.MouseEventHandler(this.order_enter);
            
            #line default
            #line hidden
            
            #line 34 "..\..\Platform.xaml"
            this.order.MouseLeave += new System.Windows.Input.MouseEventHandler(this.order_leave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mould = ((System.Windows.Controls.TextBlock)(target));
            
            #line 35 "..\..\Platform.xaml"
            this.mould.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.mould_Click);
            
            #line default
            #line hidden
            
            #line 35 "..\..\Platform.xaml"
            this.mould.MouseEnter += new System.Windows.Input.MouseEventHandler(this.mould_enter);
            
            #line default
            #line hidden
            
            #line 35 "..\..\Platform.xaml"
            this.mould.MouseLeave += new System.Windows.Input.MouseEventHandler(this.mould_leave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.logistics = ((System.Windows.Controls.TextBlock)(target));
            
            #line 36 "..\..\Platform.xaml"
            this.logistics.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.logistics_Click);
            
            #line default
            #line hidden
            
            #line 36 "..\..\Platform.xaml"
            this.logistics.MouseEnter += new System.Windows.Input.MouseEventHandler(this.logistics_enter);
            
            #line default
            #line hidden
            
            #line 36 "..\..\Platform.xaml"
            this.logistics.MouseLeave += new System.Windows.Input.MouseEventHandler(this.logistics_leave);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt_Time = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.txt_User = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.btn_Logout = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\Platform.xaml"
            this.btn_Logout.Click += new System.Windows.RoutedEventHandler(this.btn_Logout_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.framePage = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
