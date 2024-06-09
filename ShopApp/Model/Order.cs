using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderCourse> OrderCourses { get; set; } = new List<OrderCourse>();

        public Order() { }

        public Order(int userId, string fullName, string phoneNumber, string address, decimal totalPrice, DateTime orderDate, List<Course> courses)
        {
            UserId = userId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Address = address;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            OrderCourses = courses.Select(c => new OrderCourse { CourseId = c.CourseId }).ToList();
        }
    }
}
