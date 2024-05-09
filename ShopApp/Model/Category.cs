using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class Category
    {
        public int categoryId;
        public int parentCategoryId;
        public string name;

        public Category(int categoryId, int parentCategoryId, string name)
        {
            this.categoryId = categoryId;
            this.parentCategoryId = parentCategoryId;
            this.name = name;
        }
    }
}
