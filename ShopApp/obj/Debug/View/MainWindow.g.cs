﻿#pragma checksum "..\..\..\View\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "53BF11A984263040E6C491929CFB331BF542C8994A522D495BFD1204A86240CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using SharpVectors.Converters;
using ShopApp.View;
using ShopApp.ViewModel;
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


namespace ShopApp.View {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonHome;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCart;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCourses;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonProfile;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl MainContent;
        
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
            System.Uri resourceLocater = new System.Uri("/ShopApp;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MainWindow.xaml"
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
            
            #line 40 "..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ListBox_Content_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonHome = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\View\MainWindow.xaml"
            this.ButtonHome.Click += new System.Windows.RoutedEventHandler(this.NavigateToHome);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\View\MainWindow.xaml"
            this.ButtonHome.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ButtonHome_MouseEnter);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\View\MainWindow.xaml"
            this.ButtonHome.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ButtonHome_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonCart = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\View\MainWindow.xaml"
            this.ButtonCart.Click += new System.Windows.RoutedEventHandler(this.NavigateToCart);
            
            #line default
            #line hidden
            
            #line 54 "..\..\..\View\MainWindow.xaml"
            this.ButtonCart.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ButtonCart_MouseEnter);
            
            #line default
            #line hidden
            
            #line 54 "..\..\..\View\MainWindow.xaml"
            this.ButtonCart.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ButtonCart_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonCourses = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\View\MainWindow.xaml"
            this.ButtonCourses.Click += new System.Windows.RoutedEventHandler(this.NavigateToCourses);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\View\MainWindow.xaml"
            this.ButtonCourses.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ButtonCourses_MouseEnter);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\View\MainWindow.xaml"
            this.ButtonCourses.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ButtonCourses_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonProfile = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\View\MainWindow.xaml"
            this.ButtonProfile.Click += new System.Windows.RoutedEventHandler(this.NavigateToProfile);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\View\MainWindow.xaml"
            this.ButtonProfile.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ButtonProfile_MouseEnter);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\View\MainWindow.xaml"
            this.ButtonProfile.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ButtonProfile_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 81 "..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MainContent = ((System.Windows.Controls.ContentControl)(target));
            
            #line 83 "..\..\..\View\MainWindow.xaml"
            this.MainContent.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ListBox_Content_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

