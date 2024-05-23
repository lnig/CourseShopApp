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
    /// Logika interakcji dla klasy HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void textSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtSearch.Focus();
            textSearch.Visibility = Visibility.Collapsed;
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                textSearch.Visibility = Visibility.Visible;
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text.Length > 0)
            {
                textSearch.Visibility = Visibility.Collapsed;
            }
            else
            {
                textSearch.Visibility = Visibility.Visible;
            }
        }
    }
}
