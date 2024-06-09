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
using ShopApp.ViewModel;

namespace ShopApp.View
{
    public partial class CartView : UserControl
    {
        public CartViewModel cartViewModel = new CartViewModel();
        public CartView()
        {
            InitializeComponent();
            coursesItemsControl.ItemsSource = cartViewModel.UserCoursesInCart;
        }
    }
}
