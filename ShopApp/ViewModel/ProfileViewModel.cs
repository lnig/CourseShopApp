﻿using ShopApp.Model;
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

namespace ShopApp.ViewModel
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private UsersRepository usersRepository = new UsersRepository();
        private OrderRepository orderRepository = new OrderRepository();

        private string _userName;
        private string _userSurname;
        private string _userEmail;
        private string _password;
        private string _userType;

        private string _tempName;
        private string _tempSurname;
        private string _tempEmail;
        private string _tempPassword;
        private string _errorMessage;

        public ObservableCollection<Order> OrdersHistory { get; set; } = new ObservableCollection<Order>();

        public string Name
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _userSurname;
            set
            {
                _userSurname = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _userEmail;
            set
            {
                _userEmail = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string UserType
        {
            get => _userType;
            set
            {
                _userType = value;
                OnPropertyChanged();
            }
        }

        public string TempName
        {
            get => _tempName;
            set
            {
                _tempName = value;
                OnPropertyChanged();
            }
        }

        public string TempSurname
        {
            get => _tempSurname;
            set
            {
                _tempSurname = value;
                OnPropertyChanged();
            }
        }
        public string TempEmail
        {
            get => _tempEmail;
            set
            {
                _tempEmail = value;
                OnPropertyChanged();
            }
        }
        public string TempPassword
        {
            get => _tempPassword;
            set
            {
                _tempPassword = value;
                OnPropertyChanged();
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public ProfileViewModel()
        {
            Name = UserSession.Instance.Name;
            Surname = UserSession.Instance.Surname;
            Email = UserSession.Instance.Email;
            Password = UserSession.Instance.Password;

            SaveCommand = new RelayCommand(SaveInformation);
            LoadOrdersHistory();
        }

        private bool CanChange()
        {
            return !string.IsNullOrEmpty(TempName) || !string.IsNullOrEmpty(TempSurname) ||
                   !string.IsNullOrEmpty(TempEmail) || !string.IsNullOrEmpty(TempPassword);
        }


        private void SaveInformation(object parameter)
        {
            try
            {
                if (CanChange())
                {
                    string newName = string.IsNullOrEmpty(TempName) ? UserSession.Instance.Name : TempName;
                    string newSurname = string.IsNullOrEmpty(TempSurname) ? UserSession.Instance.Surname : TempSurname;
                    string newEmail = string.IsNullOrEmpty(TempEmail) ? UserSession.Instance.Email : TempEmail;
                    string newPassword = string.IsNullOrEmpty(TempPassword) ? UserSession.Instance.Password : TempPassword;

                    if (newEmail == UserSession.Instance.Email || !usersRepository.EmailTaken(newEmail))
                    {
                        UserSession.Instance.Name = newName;
                        UserSession.Instance.Surname = newSurname;
                        UserSession.Instance.Email = newEmail;
                        UserSession.Instance.Password = newPassword;

                        Name = newName;
                        Surname = newSurname;
                        Email = newEmail;
                        Password = newPassword;

                        usersRepository.UpdateUser(UserSession.Instance);
                        ErrorMessage = "Profile updated successfully.";
                    }
                    else
                    {
                        ErrorMessage = "The provided email address is already taken.";
                    }
                }
                else
                {
                    ErrorMessage = "Please provide at least one field to update.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
                Console.WriteLine(ex.ToString());
            }
        }

        private void LoadOrdersHistory()
        {
            var orders = orderRepository.GetAllUserOrdersByUserId(UserSession.Instance.UserId);
            OrdersHistory.Clear();
            foreach (var order in orders)
            {
                OrdersHistory.Add(order);
            }
        }

        public void UpdatePassword(object parameter)
        {
            if (parameter is PasswordBox passwordBox)
            {
                TempPassword = passwordBox.Password;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
