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

namespace ShopApp.ViewModel
{
    public class EditCourseViewModel : ViewModelBase
    {
        private Course _currentCourse;
        private readonly CourseRepository _courseRepository;

        public Course CurrentCourse
        {
            get { return _currentCourse; }
            set
            {
                _currentCourse = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCourseCommand { get; }
        public ICommand CancelCommand { get; }

        // Publiczny konstruktor bez parametrów
        public EditCourseViewModel()
        {
            _courseRepository = new CourseRepository();
            CurrentCourse = new Course(1, "", "", "", "", "", "", 0.0f, false);

            SaveCourseCommand = new RelayCommand1(SaveCourse);
            CancelCommand = new RelayCommand1(Cancel);
        }

        // Konstruktor z parametrem Course
        public EditCourseViewModel(Course course) : this()
        {
            CurrentCourse = course;
        }

        private void SaveCourse()
        {
            _courseRepository.UpdateCourse(CurrentCourse);
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
                }
            }
        }
    }


}
