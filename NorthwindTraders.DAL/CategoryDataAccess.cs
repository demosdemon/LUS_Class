using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindTraders.DAL.Contracts;
using NorthwindTraders.DAL.POCOS;

namespace NorthwindTraders.DAL
{
    public class CategoryDataAccess : ICategoryDAL
    {
        public List<Category_POCO> ReadAllCategories()
        {
            var categories = null as List<Category_POCO>;

            using (var northwindCtx = new NorthwindEntities())
            {
                categories = northwindCtx.Categories
                    .Select(category => new Category_POCO
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName
                    })
                    .ToList();
            }

            return categories;
        }
    }
}
