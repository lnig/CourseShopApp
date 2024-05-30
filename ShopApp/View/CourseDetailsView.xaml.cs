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
using ShopApp.Model;
using ShopApp.ViewModel;

namespace ShopApp.View
{ 
    public partial class CourseDetailsView : UserControl
    {
        public CourseDetailsView()
        {
            InitializeComponent();
        }

        private void BackToCourses_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.MainContent.Content = new HomeView();
            }
        }

    }
}
