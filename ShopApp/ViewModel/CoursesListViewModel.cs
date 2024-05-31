using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;
using ShopApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopApp.ViewModel
{
    public class CoursesListViewModel : ViewModelBase
    {
      
        private CourseRepository courseRepository = new CourseRepository();

        public List<Course> AllCourses = new List<Course>();

        private Course _selectedCourse;

        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditCourseCommand { get; private set; }
        public ICommand DeleteCourseCommand{ get; private set; }
        public ICommand OpenAddCourseCommand { get; private set; }

        public CoursesListViewModel()
        {
           LoadAllCourses();
           DeleteCourseCommand = new RelayCommand<int>(DeleteCourse);
           OpenAddCourseCommand = new RelayCommand(OpenAddCourse);
           EditCourseCommand = new RelayCommand<int>(EditCourse);
        }

        private void LoadAllCourses()
        {
            AllCourses = courseRepository.GetAllCourses();
        }

        public void DeleteCourse(int courseId)
        {
            SelectedCourse = courseRepository.GetCourseById(courseId);

            if(SelectedCourse != null)
            {
                courseRepository.DeleteCourse(SelectedCourse.CourseId);
                RefreshView();
            }
        }

        public void EditCourse(int courseId)
        {
            var course = courseRepository.GetCourseById(courseId);
            if (course != null)
            {
                var editCourseView = new EditCourseView();
                var editCourseViewModel = new EditCourseViewModel(course);
                editCourseView.DataContext = editCourseViewModel;

                if (editCourseView.ShowDialog() == true)
                {
                    RefreshView();
                }
            }
        }


        private void RefreshView()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.MainContent.Content = new CoursesListView { DataContext = this };
            }
        }

        private void OpenAddCourse(object commandParameter)
        {
            var addCourseView = new AddCourseView();
            var addCourseViewModel = new AddCourseViewModel();
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            addCourseView.DataContext = addCourseViewModel;
            mainWindow.Opacity = 0.5;

            if (addCourseView.ShowDialog() == true)
            {
                mainWindow.Opacity = 1;
                RefreshView();
            }
        }
    }
}
