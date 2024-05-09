using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class Course
    {
        private int courseId;
        private int categoryId;
        private string title;
        private string author;
        private string description;
        private string shortDescription;
        private string prize;
        private string imageTitle;

        public Course (int courseId, int categoryId, string title, string author, string description, string shortDescription, string prize, string imageTitle)
        {
            this.courseId = courseId;
            this.categoryId = categoryId;
            this.title = title;
            this.author = author;
            this.description = description;
            this.shortDescription = shortDescription;
            this.prize = prize;
            this.imageTitle = imageTitle;
        }
    }
}
