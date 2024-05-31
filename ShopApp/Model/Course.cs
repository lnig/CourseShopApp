using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Prize { get; set; }
        public string ImageTitle { get; set; }
        public float Rating { get; set; }
        public bool IsFavorite { get; set; }

        public Course(int categoryId, string title, string author, string description, string shortDescription, string prize, string imageTitle, float rating, bool isFavorite)
        {
            // CourseId = courseId; // Usuń tę linię
            CategoryId = categoryId;
            Title = title;
            Author = author;
            Description = description;
            ShortDescription = shortDescription;
            Prize = prize;
            ImageTitle = imageTitle;
            Rating = rating;
            IsFavorite = isFavorite;
        }

        public Course(int courseId, int categoryId, string title, string author, string description, string shortDescription, string prize, string imageTitle, float rating, bool isFavorite)
        {
            CourseId = courseId;
            CategoryId = categoryId;
            Title = title;
            Author = author;
            Description = description;
            ShortDescription = shortDescription;
            Prize = prize;
            ImageTitle = imageTitle;
            Rating = rating;
            IsFavorite = isFavorite;
        }
    }
}
