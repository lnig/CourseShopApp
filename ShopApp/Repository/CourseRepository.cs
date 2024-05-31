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

        public Course GetCourse(int courseId)
        {
            return context.course.FirstOrDefault(c => c.CourseId == courseId);
        }

    }
}
