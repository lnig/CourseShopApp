using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;
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

        public CartViewModel()
        {
            UserCoursesInCart = new ObservableCollection<Course>();
            LoadUserCoursesFromCart();
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
                var course = courseRepository.GetCourse(cartItem.CourseId);
                if (course != null)
                {
                    UserCoursesInCart.Add(course);
                }
            }
        }
    }
}
