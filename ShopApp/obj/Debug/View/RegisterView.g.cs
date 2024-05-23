﻿#pragma checksum "..\..\..\View\RegisterView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2275E7C856F7BF39F404415F29E6837800F66D32704F3E267877F5A37425933D"
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
using ShopApp;
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
    /// RegisterView
    /// </summary>
    public partial class RegisterView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\View\RegisterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textName;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\View\RegisterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\View\RegisterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textSurname;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\View\RegisterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSurname;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\View\RegisterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textEmail;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\View\RegisterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\View\RegisterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textPassword;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\View\RegisterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\View\RegisterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label errorMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/ShopApp;component/view/registerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\RegisterView.xaml"
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
            
            #line 20 "..\..\..\View\RegisterView.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 22 "..\..\..\View\RegisterView.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textName = ((System.Windows.Controls.TextBlock)(target));
            
            #line 38 "..\..\..\View\RegisterView.xaml"
            this.textName.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textName_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\View\RegisterView.xaml"
            this.txtName.LostFocus += new System.Windows.RoutedEventHandler(this.txtName_LostFocus);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\View\RegisterView.xaml"
            this.txtName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textSurname = ((System.Windows.Controls.TextBlock)(target));
            
            #line 53 "..\..\..\View\RegisterView.xaml"
            this.textSurname.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textSurname_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtSurname = ((System.Windows.Controls.TextBox)(target));
            
            #line 54 "..\..\..\View\RegisterView.xaml"
            this.txtSurname.LostFocus += new System.Windows.RoutedEventHandler(this.txtSurname_LostFocus);
            
            #line default
            #line hidden
            
            #line 54 "..\..\..\View\RegisterView.xaml"
            this.txtSurname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSurname_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textEmail = ((System.Windows.Controls.TextBlock)(target));
            
            #line 69 "..\..\..\View\RegisterView.xaml"
            this.textEmail.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textEmail_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 70 "..\..\..\View\RegisterView.xaml"
            this.txtEmail.LostFocus += new System.Windows.RoutedEventHandler(this.txtEmail_LostFocus);
            
            #line default
            #line hidden
            
            #line 70 "..\..\..\View\RegisterView.xaml"
            this.txtEmail.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtEmail_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.textPassword = ((System.Windows.Controls.TextBlock)(target));
            
            #line 84 "..\..\..\View\RegisterView.xaml"
            this.textPassword.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textPassword_MouseDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 85 "..\..\..\View\RegisterView.xaml"
            this.txtPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 85 "..\..\..\View\RegisterView.xaml"
            this.txtPassword.LostFocus += new System.Windows.RoutedEventHandler(this.txtPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 11:
            this.errorMessage = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            
            #line 110 "..\..\..\View\RegisterView.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 119 "..\..\..\View\RegisterView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SignIn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

