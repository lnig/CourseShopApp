using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.Utils;
using ShopApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopApp.ViewModel
{
    public class CoursesListViewModel : ViewModelBase
    {
        public string filterByTitle = "";
        public string sortByField = null;

        private CourseRepository courseRepository = new CourseRepository();

        public List<Course> AllCourses = new List<Course>();
        public List<Course> ProcessedCourses;

        public List<Category> AllCategories = new List<Category>();

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
           ProcessedCourses = AllCourses;
           DeleteCourseCommand = new RelayCommand<int>(DeleteCourse);
           OpenAddCourseCommand = new RelayCommand(OpenAddCourse);
           EditCourseCommand = new RelayCommand<int>(EditCourse);
        }

        private void LoadAllCourses()
        {
            AllCourses = courseRepository.GetAllCoursesWithCategory();
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
                var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                editCourseView.DataContext = editCourseViewModel;
                mainWindow.Opacity = 0.5;

                if (editCourseView.ShowDialog() == true)
                {
                    mainWindow.Opacity = 1;
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
        private List<Course> DeepCopy(List<Course> courses)
        {
            return courses.Select(course => new Course(course.CourseId, course.CategoryId, course.Title, course.Author, course.Description, course.ShortDescription, course.Prize, course.ImageTitle, course.Rating, course.IsFavorite)).ToList();
        }
        public void FilterAndSortCourses()
        {
            List<Course> filteredAndSorted = DeepCopy(AllCourses);

            filteredAndSorted = FilterByTitle(filteredAndSorted, filterByTitle);

            if (!string.IsNullOrEmpty(sortByField))
            {
                filteredAndSorted = SortCourses(filteredAndSorted, sortByField);
            }

            ProcessedCourses = filteredAndSorted;
        }
        private List<Course> FilterByTitle(List<Course> courses, string filterByTitle)
        {
            return string.IsNullOrEmpty(filterByTitle)
                ? courses
                : courses.Where(course => course.Title.IndexOf(filterByTitle, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        private List<Course> SortCourses(List<Course> courses, string sortByField)
        {
            switch (sortByField.ToLower())
            {
                case "title":
                    return courses.OrderBy(course => course.Title).ToList();
                case "author":
                    return courses.OrderBy(course => course.Title).ToList();
                case "price":
                    return courses.OrderBy(course => decimal.Parse(course.Prize, CultureInfo.InvariantCulture)).ToList();
                default:
                    throw new ArgumentException("Nieprawidłowe pole sortowania.");
            }
        }
    }
}
