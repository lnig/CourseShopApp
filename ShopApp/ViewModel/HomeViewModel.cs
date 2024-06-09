using ShopApp.Model;
using ShopApp.Repository;
using ShopApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;


namespace ShopApp.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    { 
        private int userId;

        private CartRepository cartRepository = new CartRepository();
        private UsersRepository usersRepository = new UsersRepository();
        private CourseRepository courseRepository = new CourseRepository();


        public List<Course> testCourses;

        public List<Course> rawCourses = new List<Course>();

        public List<Course> processedCourses = new List<Course>();
        
        public int processedCoursesCount = 3;

        public decimal filterByPriceFrom = 0;
        public decimal filterByPriceTo = decimal.MaxValue;

        public List<int> filterByRating = new List<int>{ 0, 1, 2, 3, 4, 5 };

        public bool filterByFavorite = false;

        public string filterByAuthor = "";
        public string filterByTitle = "";

        public string sortByField = null;

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

        public ICommand ShowDetailsCommand { get; private set; }

        public ICommand AddToCartCommand { get; private set; }

        public HomeViewModel()
        {
            userId = UserSession.Instance.UserId;
            using (var context = new DataContext())
            {

                rawCourses = courseRepository.GetAllCoursesWithCategory();
                processedCourses = rawCourses.ToList();
                processedCoursesCount = processedCourses.Count;
                ShowDetailsCommand = new RelayCommand<int>(ShowDetails);
                AddToCartCommand = new RelayCommand<int>(AddToCart);
            }
        }

        private void ShowDetails(int courseId)
        {
          
            SelectedCourse = rawCourses.FirstOrDefault(c => c.CourseId == courseId);
            if (SelectedCourse != null)
            {
                NavigateToDetailsView();
            }
        }

        private void AddToCart(int courseId)
        {
            SelectedCourse = rawCourses.FirstOrDefault(c => c.CourseId == courseId);

            if (SelectedCourse != null)
            {
                if (!cartRepository.CartContainCourse(userId, SelectedCourse.CourseId))
                {
                    Cart cart = new Cart(userId, SelectedCourse.CourseId);
                    cartRepository.AddToCart(cart);
                }
                else
                {
                    MessageBox.Show("You already have this course in your cart");
                }
            }
        }

        private void NavigateToDetailsView()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.MainContent.Content = new CourseDetailsView { DataContext = this };
            }
        }

        public void ClearAllFilters()
        {
            filterByTitle = string.Empty;
            filterByPriceFrom = 0;
            filterByPriceTo = decimal.MaxValue;
            filterByFavorite = false;
            sortByField = "Title";
            FilterAndSortByOwnState();
        }

        public void TryToRemoveToFilterByRating(int rating)
        {
            if (filterByRating.Contains(rating))
            {
                filterByRating.Remove(rating);
            }
        }
        public void TryToAddToFilterByRating(int rating)
        {
            if (!filterByRating.Contains(rating))
            {
                filterByRating.Add(rating);
            }
        }
        public int getProcessedCoursesCount() => processedCourses.Count;
        private List<Course> DeepCopy(List<Course> courses)
        {
            return courses.Select(course => new Course(course.CourseId, course.CategoryId, course.Title, course.Author, course.Description, course.ShortDescription, course.Prize, course.ImageTitle, course.Rating, course.IsFavorite)).ToList();
        }
        public void FilterAndSortByOwnState()
        {
            processedCourses = FilterAndSortCourses(rawCourses, filterByPriceFrom, filterByPriceTo, filterByRating, filterByFavorite, filterByAuthor, filterByTitle, sortByField);
        }
        public List<Course> FilterAndSortCourses(List<Course> courses, decimal filterByPriceFrom, decimal filterByPriceTo, List<int> filterByRating, bool filterByFavorite, string filterByAuthor, string filterByTitle, string sortByField)
        {
            List<Course> filteredAndSorted = DeepCopy(courses); 


            filteredAndSorted = FilterByPrice(filteredAndSorted, filterByPriceFrom, filterByPriceTo);

            filteredAndSorted = FilterByRating(filteredAndSorted, filterByRating);

            filteredAndSorted = FilterByFavorite(filteredAndSorted, filterByFavorite);

            filteredAndSorted = FilterByTitle(filteredAndSorted, filterByTitle);

            if (!string.IsNullOrEmpty(sortByField))
            {
                filteredAndSorted = SortCourses(filteredAndSorted, sortByField);
            }

            return filteredAndSorted;
        }
        public List<Course> GetDividedByColumns(int columns, int column)
        {
            List<Course> coursesInColumn = new List<Course>();

            for (int i = 0; i < processedCourses.Count; i++)
            {
                if(i % columns == column)
                {
                    coursesInColumn.Add(processedCourses[i]);
                }
            }

            return coursesInColumn;
        }
        
        private List<Course> FilterByPrice(List<Course> courses, decimal filterByPriceFrom, decimal filterByPriceTo)
        {
            return courses.Where(course => decimal.Parse(course.Prize, CultureInfo.InvariantCulture) >= filterByPriceFrom && decimal.Parse(course.Prize, CultureInfo.InvariantCulture) <= filterByPriceTo).ToList();
        }

        private List<Course> FilterByRating(List<Course> courses, List<int> filterByRating)
        {
            return courses.Where(course => filterByRating.Contains((int)Math.Round(course.Rating))).ToList();
        }

        private List<Course> FilterByFavorite(List<Course> courses, bool filterByFavorite)
        {
            return filterByFavorite ? courses.Where(course => course.IsFavorite).ToList() : courses;
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
                case "price":
                    return courses.OrderBy(course => decimal.Parse(course.Prize, CultureInfo.InvariantCulture)).ToList();
                case "rating":
                    return courses.OrderByDescending(course => course.Rating).ToList();
                default:
                    throw new ArgumentException("Nieprawidłowe pole sortowania.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
