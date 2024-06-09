using Microsoft.EntityFrameworkCore;
using ShopApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    public class DataContext : DbContext
    {
        public DbSet<Administrator> administrator { get; set; }
        public DbSet<Client> client { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Course> course { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderCourse> orderCourse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=wpfshop;user=root;password=root;charset=utf8mb4");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => c.Id);
            modelBuilder.Entity<Administrator>().HasKey(a => a.Id);
            modelBuilder.Entity<Cart>().HasKey(c => c.CartId);

            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);

            modelBuilder.Entity<OrderCourse>().HasKey(oc => new { oc.OrderId, oc.CourseId });



            base.OnModelCreating(modelBuilder);
        }
    }
}
