using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;
using ShopApp.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopApp.ViewModel
{
    public class AddCourseViewModel : ViewModelBase
    {
        private Course _newCourse;
        private string _errorMessage;

        private readonly CourseRepository courseRepository = new CourseRepository();

        public Course NewCourse
        {
            get { return _newCourse; }
            set
            {
                _newCourse = value;
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

        public ICommand AddCourseCommand { get; }
        public ICommand CancelCommand { get; }

        public AddCourseViewModel()
        {
            NewCourse = new Course(1, "", "", "", "", "", "", 0.0f, false);

            AddCourseCommand = new RelayCommand1(AddCourse);
            CancelCommand = new RelayCommand1(Cancel);
        }

        private bool CanAddCourse()
        {
            return !string.IsNullOrWhiteSpace(NewCourse.Title) &&
                   !string.IsNullOrWhiteSpace(NewCourse.Author) &&
                   !string.IsNullOrWhiteSpace(NewCourse.Description) &&
                   !string.IsNullOrWhiteSpace(NewCourse.ShortDescription) &&
                   !string.IsNullOrWhiteSpace(NewCourse.Prize);
        }

        private bool PriceIsNumber()
        {
            foreach (char c in NewCourse.Prize)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return true;
                }
            }
            return false;
        }

        private bool PriceIsGoodPattern()
        {
            return Regex.IsMatch((string)NewCourse.Prize, @"^\d+(\.\d{2})");
        }


        private void AddCourse()
        {
            if (!CanAddCourse())
            {
                ErrorMessage = "Please fill in the required fields";
                return;
            }

            if (PriceIsNumber())
            {
                ErrorMessage = "Price must be number";
                return;
            }

            if (!PriceIsGoodPattern())
            {
                ErrorMessage = "Price must be in good pattern(etc. 12.00)";
                return ;
            }

            courseRepository.AddCourse(NewCourse);
            CloseWindow(true);
        }

        private void Cancel()
        {
            CloseWindow(false);
        }

        private void CloseWindow(bool result)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.DialogResult = result;
                    window.Close();
                    var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                    mainWindow.Opacity = 1;
                }
            }
        }
    }

    public class RelayCommand1 : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand1(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

}
