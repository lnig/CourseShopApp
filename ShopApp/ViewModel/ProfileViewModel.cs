using ShopApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        public ProfileViewModel()
        {
            Name = UserSession.Instance.Name;
            Surname = UserSession.Instance.Surname;
            Email = UserSession.Instance.Email;
            Password = UserSession.Instance.Password;
            UserType = UserSession.Instance.UserType;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
