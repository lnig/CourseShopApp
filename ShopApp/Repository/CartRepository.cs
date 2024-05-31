using ShopApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repository
{
    public class CartRepository
    {
        private DataContext context = new DataContext();

        public void AddToCart(Cart cart)
        {
            context.cart.Add(cart);
            context.SaveChanges();
        }

        public void RemoveFromCart(int cartId) 
        {
            var cartItem = context.cart.Find(cartId);
            if (cartItem != null)
            {
                context.cart.Remove(cartItem);
                context.SaveChanges();
            }
        }

        public List<Cart> GetCartByUserId(int userId) 
        {
           return context.cart.Where(c => c.ClientId == userId).ToList();
        }

        public Cart GetCartByUserIdAndCourseId(int userId, int courseId)
        {
            return context.cart.FirstOrDefault(c => c.ClientId == userId && c.CourseId == courseId);
        }

        public bool CartContainCourse(int userId, int courseId)
        {
            return context.cart.Any(c => c.ClientId == userId && c.CourseId == courseId);
        }

    }
}
