using ShopApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repository
{
    public class CourseRepository
    {
        private DataContext context = new DataContext();

        public void AddCourse(Course course)
        {
            context.course.Add(course);
            context.SaveChanges();
        }

        public Course GetCourseById(int courseId)
        {
            return context.course.FirstOrDefault(c => c.CourseId == courseId);
        }

        public List<Course> GetAllCourses()
        {
            return context.course.ToList();
        }

        public List<Course> GetAllCoursesWithCategory()
        {
            var coursesWithCategories = from course in context.course
                                        join category in context.category on course.CategoryId equals category.CategoryId
                                        select new { Course = course, Category = category };

            List<Course> courses = new List<Course>();
            foreach (var item in coursesWithCategories)
            {
                item.Course.Category = item.Category;
                courses.Add(item.Course);
            }

            return courses;
        }

        public void DeleteCourse(int courseId)
        {
            var course = context.course.Find(courseId);
            if (course != null)
            {
                var relatedCarts = context.cart.Where(c => c.CourseId == courseId).ToList();
                context.cart.RemoveRange(relatedCarts);

                context.course.Remove(course);
                context.SaveChanges();
            }
        }

        public void UpdateCourse(Course course)
        {
            var existingCourse = context.course.Find(course.CourseId);
            if (existingCourse != null)
            {
                context.Entry(existingCourse).CurrentValues.SetValues(course);
                context.SaveChanges();
            }
        }
    }
}
