using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int ClientId { get; set; }
        public int CourseId { get; set; }

        public Cart(int clientId, int courseId)
        {
            ClientId = clientId;
            CourseId = courseId;
        }
    }
}
