using ShopApp.Utils;
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

    public partial class CoursesListView : UserControl
    {
        public CoursesListViewModel coursesViewModel = new CoursesListViewModel();
        bool initEnded = false;
        public CoursesListView()
        {
            InitializeComponent();
            textSearch.Text = coursesViewModel.filterByTitle;
            coursesItemsControl.ItemsSource = coursesViewModel.ProcessedCourses;
            initEnded = true;
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
            TextBox searchBar = (TextBox)sender;
            coursesViewModel.filterByTitle = searchBar.Text;
            coursesViewModel.FilterAndSortCourses();
            refreshCourseList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new PdfCreator().GenerateCourseList();
        }
        private void refreshCourseList()
        {
            coursesItemsControl.ItemsSource = coursesViewModel.ProcessedCourses;
        }

        private void SortByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (initEnded) {
                ComboBox sortBy = (ComboBox)sender;
                coursesViewModel.sortByField = (sortBy.SelectedItem as ComboBoxItem)?.Content.ToString();
                coursesViewModel.FilterAndSortCourses();
                refreshCourseList();
            }
        }
    }
}
