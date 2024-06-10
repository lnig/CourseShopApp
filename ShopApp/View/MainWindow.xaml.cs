using ShopApp.Model;
using ShopApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ShopApp.View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(String userType)
        {
            InitializeComponent();
            MainContent.Content = new HomeView();
            ButtonHome.FontWeight = FontWeights.Bold;
            if(userType == "Client")
            {
                ButtonCourses.Visibility = Visibility.Collapsed;
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListBox_Content_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void NavigateToHome(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new HomeView();
            ButtonHome.FontWeight = FontWeights.Bold;
            ButtonCart.FontWeight = FontWeights.Regular;
            ButtonCourses.FontWeight = FontWeights.Regular;
            ButtonProfile.FontWeight = FontWeights.Regular;
        }

        private void NavigateToCart(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CartView();
            ButtonHome.FontWeight = FontWeights.Regular;
            ButtonCart.FontWeight = FontWeights.Bold;
            ButtonCourses.FontWeight = FontWeights.Regular;
            ButtonProfile.FontWeight = FontWeights.Regular;
        }

        private void NavigateToCourses(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CoursesListView();
            ButtonHome.FontWeight = FontWeights.Regular;
            ButtonCart.FontWeight = FontWeights.Regular;
            ButtonCourses.FontWeight = FontWeights.Bold;
            ButtonProfile.FontWeight = FontWeights.Regular;
        }

        private void NavigateToProfile(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProfileView();
            ButtonHome.FontWeight = FontWeights.Regular;
            ButtonCart.FontWeight = FontWeights.Regular;
            ButtonCourses.FontWeight = FontWeights.Regular;
            ButtonProfile.FontWeight = FontWeights.Bold;
        }
        private void NavigateToLogin(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProfileView();
            ButtonHome.FontWeight = FontWeights.Regular;
            ButtonCart.FontWeight = FontWeights.Regular;
            ButtonCourses.FontWeight = FontWeights.Regular;
            ButtonProfile.FontWeight = FontWeights.Bold;
        }

        private void ButtonHome_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonHome.Background = new SolidColorBrush(Color.FromRgb(243, 244, 246));
        }

        private void ButtonHome_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonHome.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void ButtonCart_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonCart.Background = new SolidColorBrush(Color.FromRgb(243, 244, 246));
        }

        private void ButtonCart_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonCart.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void ButtonCourses_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonCourses.Background = new SolidColorBrush(Color.FromRgb(243, 244, 246));
        }

        private void ButtonCourses_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonCourses.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void ButtonLogout_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonCourses.Background = new SolidColorBrush(Color.FromRgb(243, 244, 246));
        }

        private void ButtonLogout_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonCourses.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
    }
}
