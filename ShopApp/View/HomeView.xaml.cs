using ShopApp.Model;
using ShopApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class HomeView : UserControl
    {
        public HomeViewModel homeViewModel = new HomeViewModel();
        bool isSortByLoaded = false;

        public HomeView()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();

            homeViewModel.FilterAndSortByOwnState();
            coursesItemsControl0.ItemsSource = homeViewModel.GetDividedByColumns(3, 0);
            coursesItemsControl1.ItemsSource = homeViewModel.GetDividedByColumns(3, 1);
            coursesItemsControl2.ItemsSource = homeViewModel.GetDividedByColumns(3, 2);
            FountProductCount.Text = homeViewModel.processedCoursesCount.ToString();

        }

        private void ShowMessageBox(object sender, RoutedEventArgs e)
        {
            if (DataContext is HomeViewModel viewModel)
            {
                viewModel.ShowDetailsCommand.Execute(this);
            }
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
            TextBox textBox = (TextBox)sender;
            string searchFrase = textBox.Text;
            homeViewModel.filterByTitle = searchFrase;
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
            if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text.Length > 0)
            {
                textSearch.Visibility = Visibility.Collapsed;
            }
            else
            {
                textSearch.Visibility = Visibility.Visible;
            }
        }

        private void PriceRangeFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                homeViewModel.filterByPriceFrom = 0;
            }
            else
            {
                decimal value = decimal.Parse(textBox.Text, CultureInfo.InvariantCulture);
                homeViewModel.filterByPriceFrom = value;
            }

            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void PriceRangeFrom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void PriceRangeTo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void PriceRangeTo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                homeViewModel.filterByPriceTo = decimal.MaxValue;
            }
            else
            {
                decimal value = decimal.Parse(textBox.Text, CultureInfo.InvariantCulture);
                homeViewModel.filterByPriceTo = value;
            }

            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();

        }
        private void RefreshProductList()
        {
            coursesItemsControl0.ItemsSource = homeViewModel.GetDividedByColumns(3, 0);
            coursesItemsControl1.ItemsSource = homeViewModel.GetDividedByColumns(3, 1);
            coursesItemsControl2.ItemsSource = homeViewModel.GetDividedByColumns(3, 2);
        }

        

        private void FavoriteFilter_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool isChecked = checkBox.IsChecked ?? false;
            if (isChecked)
            {
                homeViewModel.filterByFavorite = true;
            }
            else
            {
                homeViewModel.filterByFavorite = false;
            }
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void FavoriteFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool isChecked = checkBox.IsChecked ?? false;
            if (isChecked)
            {
                homeViewModel.filterByFavorite = true;
            }
            else
            {
                homeViewModel.filterByFavorite = false;
            }
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating5Star_Checked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToAddToFilterByRating(5);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating4Star_Checked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToAddToFilterByRating(4);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating3Star_Checked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToAddToFilterByRating(3);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating2Star_Checked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToAddToFilterByRating(2);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating1Star_Checked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToAddToFilterByRating(1);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating0Star_Checked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToAddToFilterByRating(0);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating5Star_Unchecked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToRemoveToFilterByRating(5);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating4Star_Unchecked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToRemoveToFilterByRating(4);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating3Star_Unchecked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToRemoveToFilterByRating(3);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating2Star_Unchecked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToRemoveToFilterByRating(2);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating1Star_Unchecked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToRemoveToFilterByRating(1);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void Rating0Star_Unchecked(object sender, RoutedEventArgs e)
        {
            homeViewModel.TryToRemoveToFilterByRating(0);
            homeViewModel.FilterAndSortByOwnState();
            RefreshProductList();
        }

        private void SortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isSortByLoaded)
            {
                ComboBox comboBox = (ComboBox)sender;
                string selectedField = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                homeViewModel.sortByField = selectedField;
                homeViewModel.FilterAndSortByOwnState();
                RefreshProductList();
            }
            
            
        }

        private void SortBy_Loaded(object sender, RoutedEventArgs e)
        {
            isSortByLoaded = true;
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
       
            homeViewModel.ClearAllFilters();

            txtSearch.Text = string.Empty;

            PriceRangeFrom.Text = string.Empty;
            PriceRangeTo.Text = string.Empty;

            FavoriteFilter.IsChecked = false;

            Rating5Star.IsChecked = true;
            Rating4Star.IsChecked = true;
            Rating3Star.IsChecked = true;
            Rating2Star.IsChecked = true;
            Rating1Star.IsChecked = true;
            Rating0Star.IsChecked = true;

            SortBy.SelectedIndex = 0;

            RefreshProductList();
        }


    }
}
