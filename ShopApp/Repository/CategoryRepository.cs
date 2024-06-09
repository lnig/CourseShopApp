using ShopApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repository
{
    public class CategoryRepository
    {
        private DataContext context = new DataContext();

        public Category GetCategoryById(int categoryId)
        {
            return context.category.FirstOrDefault(c=>c.CategoryId==categoryId);
        }
        public List<Category> GetAllCategories()
        {
            return context.category.ToList();
        }
    }
}
