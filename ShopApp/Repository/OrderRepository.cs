﻿using Microsoft.EntityFrameworkCore;
using ShopApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repository
{
    public class OrderRepository
    {
        private DataContext context = new DataContext();

        public void SaveOrder(Order order)
        {
            try
            {
                context.order.Add(order);
                context.SaveChanges();

                foreach (var orderCourse in order.OrderCourses)
                {
                    var existingOrderCourse = context.orderCourse
                        .FirstOrDefault(oc => oc.OrderId == order.OrderId && oc.CourseId == orderCourse.CourseId);

                    if (existingOrderCourse == null)
                    {
                        orderCourse.OrderId = order.OrderId; 
                        context.orderCourse.Add(orderCourse);
                    }
                }
                context.SaveChanges();
                  
            }
            catch (Exception)
            {                  
                throw;
            }
           
        }

        public List<Order> GetAllUserOrdersByUserId(int userId)
        {
            return context.order
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderCourses)
                .ThenInclude(oc => oc.Course)
                .ToList();
        }

        public List<OrderCourse> GetOrderCoursesInOrder(int orderId)
        {
            return context.orderCourse
                .Where(oc => oc.OrderId == orderId)
                .Include(oc => oc.Course)
                .ToList();
        }

    }
}
