using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class OrderCourse
    {
        [Key, Column(Order = 0)]
        public int OrderId { get; set; }
        [Key, Column(Order = 1)]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
