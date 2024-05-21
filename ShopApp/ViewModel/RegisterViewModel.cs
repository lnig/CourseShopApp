using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ShopApp.Model;

namespace ShopApp.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _email;
        private string _password;
        private string _errorMessage;

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

        private bool CanRegister(object parameter)
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname) &&
                   !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private bool EmailTaken(object parameter)
        {
            bool emailfound = false;
            using (var context = new DataContext())
            {
                emailfound = context.client.Any(client => client.Email == Email);
            }
            return emailfound;
        }

        private void Register(object parameter)
        {
            try
            {
                if(CanRegister(parameter))
                {
                    if (!EmailTaken(parameter))
                    {
                        using (var context = new DataContext())
                        {
                            var client = new Client(Name, Surname, Email, Password);
                            context.client.Add(client);
                            context.SaveChanges();
                        }
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

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
