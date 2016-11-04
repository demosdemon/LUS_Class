using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindTraders.DAL.POCOS;

namespace NorthwindTraders.DAL.Contracts
{
    /// <summary>
    /// This product contains crud signatures to query product data.
    /// </summary>
    public interface IProductDAL
    {
        List<Product_POCO> ReadProductsByCategory(int categoryID);
    }
}
