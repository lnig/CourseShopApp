using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;
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
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public string Title { get; } = "Profile";

        private UsersRepository usersRepository = new UsersRepository();


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
        }

        private bool CanChange()
        {
            return !string.IsNullOrEmpty(TempName) && !string.IsNullOrEmpty(TempSurname) &&
                   !string.IsNullOrEmpty(TempEmail) && !string.IsNullOrEmpty(TempPassword);
        }

        private void SaveInformation(object parameter)
        {
            try
            {
                if (CanChange())
                {
           
                    if (!usersRepository.EmailTaken(TempEmail))
                    {
                  
                        UserSession.Instance.Name = TempName;
                        UserSession.Instance.Surname = TempSurname;
                        UserSession.Instance.Email = TempEmail;
                        UserSession.Instance.Password = TempPassword;

                        Name = TempName;
                        Surname = TempSurname;
                        Email = TempEmail;
                        Password = TempPassword;

                        usersRepository.UpdateUser(UserSession.Instance);
              
                    }
                    else
                    {
                        ErrorMessage = "The provided email address is already taken.";
                    }
                }
                else
                {
                    ErrorMessage = "Fill.";
                }
            }catch(Exception ex)
            {
               Console.WriteLine(ex.ToString());
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
