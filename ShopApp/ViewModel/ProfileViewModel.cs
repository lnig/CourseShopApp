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
using System.Windows.Controls;
using System.Windows.Input;

namespace ShopApp.ViewModel
{
    public class ProfileViewModel
    {
        public string Title { get; } = "Profile";

        private string _userName;
        private string _userSurname;
        private string _userEmail;
        private string _password;
        private string _userType;

        private string _tempName;
        private string _tempSurname;
        private string _tempEmail;
        private string _tempPassword;
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

        public ICommand SaveCommand { get; }


        public ProfileViewModel()
        {
            Name = UserSession.Instance.Name;
            Surname = UserSession.Instance.Surname;
            Email = UserSession.Instance.Email;
            Password = UserSession.Instance.Password;

            SaveCommand = new RelayCommand(SaveInformation);
        }
        public void UpdatePassword(object parameter)
        {
            if (parameter is PasswordBox passwordBox)
            {
                TempPassword = passwordBox.Password;
            }
        }

        private void SaveInformation(object parameter)
        {
            UserSession.Instance.Name = TempName;
            UserSession.Instance.Surname = TempSurname;
            UserSession.Instance.Email = TempEmail;
            UserSession.Instance.Password = TempPassword;

            Name = TempName;
            Surname = TempSurname;
            Email = TempEmail;
            Password = TempPassword;

            var userRepository = new UsersRepository();
            userRepository.UpdateUser(UserSession.Instance);
        }


        public string GetUserName()
        {
            var userRepository = new UsersRepository();
            return userRepository.getName(UserSession.Instance.UserId);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
