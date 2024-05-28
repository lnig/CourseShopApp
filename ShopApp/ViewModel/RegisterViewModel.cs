using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;

namespace ShopApp.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _email;
        private string _password;
        private string _errorMessage;


        private UsersRepository usersRepository= new UsersRepository();

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
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

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
        }

        private bool CanRegister()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname) &&
                   !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private void Register(object parameter)
        {

            try
            {
                if(CanRegister())
                {
                    if (!usersRepository.EmailTaken(Email))
                    {

                        var client = new Client(Name, Surname, Email, Password);
                        usersRepository.AddUser(client);
                        ErrorMessage = "User registered successfully!";               
                    }
                    else
                    {
                        ErrorMessage = "Email is already taken";
                    }
                   
                }
                else
                {
                    ErrorMessage =  "Please fill in the required fields";
                }

               
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
        }

        public void UpdatePassword(object parameter)
        {
            if (parameter is PasswordBox passwordBox)
            {
                Password = passwordBox.Password;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
