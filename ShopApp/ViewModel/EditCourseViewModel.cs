using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Text.RegularExpressions;
using ShopApp.View;

namespace ShopApp.ViewModel
{
    public class EditCourseViewModel : ViewModelBase
    {
        private Course _currentCourse;
        private string _errorMessage;
        private readonly CourseRepository courseRepository = new CourseRepository();

        public Course CurrentCourse
        {
            get { return _currentCourse; }
            set
            {
                _currentCourse = value;
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

        public ICommand SaveCourseCommand { get; }
        public ICommand CancelCommand { get; }

        public EditCourseViewModel()
        {
            CurrentCourse = new Course(1, "", "", "", "", "", "", 0.0f, false);

            SaveCourseCommand = new RelayCommand1(SaveCourse);
            CancelCommand = new RelayCommand1(Cancel);
        }

        public EditCourseViewModel(Course course) : this()
        {
            CurrentCourse = course;
        }

        private bool CanAddCourse()
        {
            return !string.IsNullOrWhiteSpace(CurrentCourse.Title) &&
                   !string.IsNullOrWhiteSpace(CurrentCourse.Author) &&
                   !string.IsNullOrWhiteSpace(CurrentCourse.Description) &&
                   !string.IsNullOrWhiteSpace(CurrentCourse.ShortDescription) &&
                   !string.IsNullOrWhiteSpace(CurrentCourse.Prize);
        }

        private bool PriceIsNumber()
        {
            foreach (char c in CurrentCourse.Prize)
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
            return Regex.IsMatch(CurrentCourse.Prize, @"^\d+(\.\d{2})");
        }

        private void SaveCourse()
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
                return;
            }


            courseRepository.UpdateCourse(CurrentCourse);
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
}
