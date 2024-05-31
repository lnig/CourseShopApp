using ShopApp.Model;
using System;
using System.Collections.Generic;
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

    }
}
