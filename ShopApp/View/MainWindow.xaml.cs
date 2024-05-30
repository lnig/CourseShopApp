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
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new HomeView();
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

        private void NavigateToView1(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CourseDetailsView();
        }

        private void NavigateToView2(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProfileView();
        }

        private void NavigateToView3(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CartView();
        }

    }
}
