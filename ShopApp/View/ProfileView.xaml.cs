using ShopApp.ViewModel;
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

namespace ShopApp.View
{
    /// <summary>
    /// Logika interakcji dla klasy ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        private ProfileViewModel viewModel = new ProfileViewModel(); 
        public ProfileView()
        {
            InitializeComponent();
            DataContext = new ProfileViewModel();
        }

        private void ClearFields(object sender, RoutedEventArgs e)
        {
            TextName.Text = FirstNameTextBox.Text;
            TextEmail.Text = EmailTextBox.Text;

            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is ProfileViewModel viewModel)
            {
                viewModel.UpdatePassword(sender as PasswordBox);
            }
        }
    }
}
