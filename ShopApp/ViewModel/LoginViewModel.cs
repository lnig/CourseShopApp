using ShopApp.View;
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

namespace ShopApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;
        private string _errorMessage;


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

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private bool UserExist(object parameter)
        {
            bool userfound = false;
            using (var context = new DataContext())
            {
                userfound = context.client.Any(client => client.Email == Email && client.Password == Password);
            }
            return userfound;
        }

        private void Login(object parameter)
        {
            try
            {
                if (CanLogin(parameter))
                {
                    if (UserExist(parameter))
                    {
                        OpenHomeView();
                        CloseCurrentWindow();
                    }
                    else
                    {
                        ErrorMessage = "Wrong email or password";
                    }

                }
                else
                {
                    ErrorMessage = "Please fill in the required fields";
                }


            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
        }

        private void OpenHomeView()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var mainView = new MainWindow();
                mainView.Show();
            });
        }

        private void CloseCurrentWindow()
        {
            Window window = Application.Current.MainWindow;
            if (window != null)
            {
                window.Close();
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
