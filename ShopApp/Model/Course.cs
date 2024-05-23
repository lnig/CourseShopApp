using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Prize { get; set; }
        public string ImageTitle { get; set; }

        public Course(int courseId, int categoryId, string title, string author, string description, string shortDescription, string prize, string imageTitle)
        {
            CourseId = courseId;
            CategoryId = categoryId;
            Title = title;
            Author = author;
            Description = description;
            ShortDescription = shortDescription;
            Prize = prize;
            ImageTitle = imageTitle;
        }
    }
}
