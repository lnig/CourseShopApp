using MySqlX.XDevAPI.Relational;
using ShopApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.ViewModel
{
    public class HomeViewModel
    {
        public string Title { get; } = "Home";
        public List<Course> testCourses;

        public List<Course> rawCourses = new List<Course>
        {
            new Course(
                    courseId: 0,
                    categoryId: 1,
                    title: "Introduction to Programming",
                    author: "Alice Smith",
                    description: "A beginner's course on programming.",
                    shortDescription: "Learn programming basics.",
                    prize: "49.99",
                    imageTitle: "/Assets/Icons/programming.png",
                    rating: 3.0f,
                    isFavorite: false

                ),
                new Course(
                    courseId: 1,
                    categoryId: 2,
                    title: "Advanced Data Structures",
                    author: "Bob Johnson",
                    description: "An in-depth look at data structures.",
                    shortDescription: "Master complex data structures.",
                    prize: "79.99",
                    imageTitle: "/Assets/Icons/datastructures.png",
                    rating: 4.0f,
                    isFavorite: false
                ),
                new Course(
                    courseId: 2,
                    categoryId: 3,
                    title: "Web Development Bootcamp",
                    author: "Charlie Brown",
                    description: "A comprehensive course on web development.",
                    shortDescription: "Become a web developer.",
                    prize: "99.99",
                    imageTitle: "/Assets/Icons/webdev.png",
                    rating: 5.0f,
                    isFavorite: true
                )
        };
        public List<Course> processedCourses = new List<Course>
        {
            new Course(
                    courseId: 0,
                    categoryId: 1,
                    title: "Introduction to Programming",
                    author: "Alice Smith",
                    description: "A beginner's course on programming.",
                    shortDescription: "Learn programming basics.",
                    prize: "49.99",
                    imageTitle: "/Assets/Icons/programming.png",
                    rating: 3.0f,
                    isFavorite: false

                ),
                new Course(
                    courseId: 1,
                    categoryId: 2,
                    title: "Advanced Data Structures",
                    author: "Bob Johnson",
                    description: "An in-depth look at data structures.",
                    shortDescription: "Master complex data structures.",
                    prize: "79.99",
                    imageTitle: "/Assets/Icons/datastructures.png",
                    rating: 4.0f,
                    isFavorite: false
                ),
                new Course(
                    courseId: 2,
                    categoryId: 3,
                    title: "Web Development Bootcamp",
                    author: "Charlie Brown",
                    description: "A comprehensive course on web development.",
                    shortDescription: "Become a web developer.",
                    prize: "99.99",
                    imageTitle: "/Assets/Icons/webdev.png",
                    rating: 5.0f,
                    isFavorite: true
                )
        };
        public int processedCoursesCount = 3;

        public decimal filterByPriceFrom = 0;
        public decimal filterByPriceTo = decimal.MaxValue;

        public List<int> filterByRating = new List<int>{ 0, 1, 2, 3, 4, 5 };

        public bool filterByFavorite = false;

        public string filterByAuthor = "";
        public string filterByTitle = "";

        public string sortByField = null;

        public HomeViewModel()
        {
            using (var context = new DataContext())
            {
                
                rawCourses = context.course.ToList();
                processedCourses = rawCourses.ToList();
                processedCoursesCount = processedCourses.Count; 

            }
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

            filteredAndSorted = FilterByAuthor(filteredAndSorted, filterByAuthor);

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
        //Filtry i sorty
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

        private List<Course> FilterByAuthor(List<Course> courses, string filterByAuthor)
        {
            return string.IsNullOrEmpty(filterByAuthor) ? courses : courses.Where(course => course.Author.Contains(filterByAuthor)).ToList();
        }

        private List<Course> FilterByTitle(List<Course> courses, string filterByTitle)
        {
            return string.IsNullOrEmpty(filterByTitle) ? courses : courses.Where(course => course.Title.Contains(filterByTitle)).ToList();
        }

        private List<Course> SortCourses(List<Course> courses, string sortByField)
        {
            switch (sortByField.ToLower())
            {
                case "title":
                    return courses.OrderBy(course => course.Title).ToList();
                case "author":
                    return courses.OrderBy(course => course.Author).ToList();
                case "price":
                    return courses.OrderBy(course => decimal.Parse(course.Prize, CultureInfo.InvariantCulture)).ToList();
                case "rating":
                    return courses.OrderByDescending(course => course.Rating).ToList();
                default:
                    throw new ArgumentException("Nieprawidłowe pole sortowania.");
            }
        }
    }
    
}
