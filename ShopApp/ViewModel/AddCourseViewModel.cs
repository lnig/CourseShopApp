using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;
using ShopApp.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopApp.ViewModel
{
    public class AddCourseViewModel : ViewModelBase
    {
        private Course _newCourse;
        private readonly CourseRepository _courseRepository;

        public Course NewCourse
        {
            get { return _newCourse; }
            set
            {
                _newCourse = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCourseCommand { get; }
        public ICommand CancelCommand { get; }

        public AddCourseViewModel()
        {
            _courseRepository = new CourseRepository();
            NewCourse = new Course(1, "", "", "", "", "", "", 0.0f, false);

            AddCourseCommand = new RelayCommand1(AddCourse);
            CancelCommand = new RelayCommand1(Cancel);
        }

        private void AddCourse()
        {
            _courseRepository.AddCourse(NewCourse);
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
