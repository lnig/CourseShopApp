using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;
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
        private string _userType;

        private UsersRepository usersRepository = new UsersRepository();


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
            LoginCommand = new RelayCommand(Login);
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }

        private void Login(object parameter)
        {
            
            try
            {
                if (CanLogin())
                {
                    if (usersRepository.UserExist(Email, Password))
                    {
                        var user = usersRepository.GetUserDetails(Email);
                        if (user is Client client)
                        {
                            UserSession.Instance.SetClient(client);
                            _userType = "Client";
                        }
                        else if (user is Administrator admin)
                        {
                            UserSession.Instance.SetAdministrator(admin);
                            _userType = "Administator";
                        }

                        OpenHomeView(_userType);
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

        private void OpenHomeView(String userType)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var mainView = new MainWindow(userType);
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
