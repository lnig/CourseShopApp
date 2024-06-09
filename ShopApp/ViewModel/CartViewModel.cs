using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;
using ShopApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using static QuestPDF.Helpers.Colors;

namespace ShopApp.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        private CartRepository cartRepository = new CartRepository();
        private CourseRepository courseRepository = new CourseRepository();
        private OrderRepository orderRepository = new OrderRepository();

        public ObservableCollection<Course> UserCoursesInCart { get; set; }

        private Cart _selectedCart;
        private decimal _subTotal;
        private decimal _discount;
        private string _voucherCode;
        private string _fullName;
        private string _phoneNumber;
        private string _address;

        public Cart SelectedCart
        {
            get { return _selectedCart; }
            set
            {
                _selectedCart = value;
                OnPropertyChanged();
            }
        }

        public decimal SubTotal
        {
            get { return _subTotal; }
            set
            {
                _subTotal = value;
                OnPropertyChanged();
            }
        }

        public decimal Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                OnPropertyChanged();

            }
        }

        public string VoucherCode
        {
            get { return _voucherCode; }
            set
            {
                _voucherCode = value;
                OnPropertyChanged();
            }
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public decimal Total => SubTotal - Discount;

        public ICommand RemoveFromCartCommand { get; private set; }
        public ICommand ApplyVoucherCommand { get; private set; }
        public ICommand OrderCommand { get; private set; }

        public CartViewModel()
        {
            UserCoursesInCart = new ObservableCollection<Course>();
            LoadUserCoursesFromCart();
            SubTotal = CalculatePrice();
            Discount = 0.00m;
            RemoveFromCartCommand = new RelayCommand<int>(RemoveFromCart);
            ApplyVoucherCommand = new RelayCommand(ApplyVoucher);
            OrderCommand = new RelayCommand<object>(param => Order());
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

            if (SelectedCart != null)
            {
                cartRepository.RemoveFromCart(SelectedCart.CartId);
                SubTotal = CalculatePrice();
                RefreshView();
            }
        }

        private decimal CalculatePrice()
        {
            var cartItems = cartRepository.GetCartByUserId(GetCurrentClientId());
            decimal allPrice = 0.00m;

            foreach (var cartItem in cartItems)
            {
                var course = courseRepository.GetCourseById(cartItem.CourseId);
                if (course != null)
                {
                    if (decimal.TryParse(course.Prize, NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal prize))
                    {
                        allPrice += prize;
                    }
                }
            }
            return allPrice;
        }

        private void Order()
        {
            Order order = new Order(GetCurrentClientId(), FullName, PhoneNumber, Address, Total, DateTime.Now, UserCoursesInCart.ToList());

            if(order != null)
            {
                orderRepository.SaveOrder(order);

                cartRepository.ClearCart(GetCurrentClientId());
                UserCoursesInCart.Clear();

                SubTotal = 0.00m;
                PhoneNumber = String.Empty;
                Address = String.Empty;
                FullName = String.Empty;
                VoucherCode = String.Empty;

                OnPropertyChanged(nameof(SubTotal));
                OnPropertyChanged(nameof(Total));

                RefreshView();

                MessageBox.Show("Order has been placed successfully and the cart has been cleared.");
            }
        }

        private void ApplyVoucher(object parameter)
        {
            if (VoucherCode == "DISCOUNT10")
            {
                Discount = 10.00m;
            }
            else if (VoucherCode == "DISCOUNT15")
            {
                Discount = 15.00m;
            }
            else
            {
                Discount = 0.00m;
            }
            OnPropertyChanged(nameof(Discount));
            OnPropertyChanged(nameof(Total));
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
