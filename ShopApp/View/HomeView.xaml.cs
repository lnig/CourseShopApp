using ShopApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ShopApp.View
{
    /// <summary>
    /// Logika interakcji dla klasy HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public ObservableCollection<Course> Courses { get; set; }
        public HomeView()
        {
            Courses = new ObservableCollection<Course>()
            {
                new Course(0,0,"Kurs budowa", "Mathew", "O budowie", "Budowa", "15.99", "Bud")
            };
            InitializeComponent();
        }


    }
}
