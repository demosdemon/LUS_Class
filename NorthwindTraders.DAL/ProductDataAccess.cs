using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindTraders.DAL.Contracts;
using NorthwindTraders.DAL.POCOS;


namespace NorthwindTraders.DAL
{
    public class ProductDataAccess : IProductDAL
    {
        public List<Product_POCO> ReadProductsByCategory(int categoryID)
        {
            var products = null as List<Product_POCO>;

            using (var northwindCtx = new NorthwindEntities())
                products = northwindCtx.Products
                    .Where(product => product.CategoryID == categoryID)
                    .Select(product => new Product_POCO
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        UnitPrice = product.UnitPrice,
                    })
                    .ToList();

            return products;
        }
    }
}
