using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;
using ShopApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace ShopApp.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        private CartRepository cartRepository = new CartRepository();
        private CourseRepository courseRepository = new CourseRepository();

        public ObservableCollection<Course> UserCoursesInCart { get; set; }


        private Cart _selectedCart;

        public Cart SelectedCart
        {
            get { return _selectedCart; }
            set
            {
                _selectedCart = value;
                OnPropertyChanged();
            }
        }


        public ICommand RemoveFromCartCommand { get; private set; }

        public CartViewModel()
        {
            UserCoursesInCart = new ObservableCollection<Course>();
            LoadUserCoursesFromCart();
            RemoveFromCartCommand = new RelayCommand<int>(RemoveFromCart);
        }

        private int GetCurrentClientId()
        {
            return UserSession.Instance.UserId;
        }

        private void LoadUserCoursesFromCart()
        {
            var cartItems = cartRepository.GetCartByUserId(GetCurrentClientId());

            foreach (var cartItem in cartItems)
            {
                var course = courseRepository.GetCourseById(cartItem.CourseId);
                if (course != null)
                {
                    UserCoursesInCart.Add(course);
                }
            }
        }

        private void RemoveFromCart(int courseId)
        {
            SelectedCart = cartRepository.GetCartByUserIdAndCourseId(GetCurrentClientId(), courseId);

            if(SelectedCart != null)
            {
                cartRepository.RemoveFromCart(SelectedCart.CartId);
                RefreshView();
            }

        }

        private void RefreshView()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.MainContent.Content = new CartView { DataContext = this };
            }
        }

    }
}
