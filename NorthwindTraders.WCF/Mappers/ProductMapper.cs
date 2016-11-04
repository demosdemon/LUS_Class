using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NorthwindTraders.WCF.DTOS;
using NorthwindTraders.DAL.POCOS;

namespace NorthwindTraders.WCF.Mappers
{
    /// <summary>
    /// Converts <see cref="Product_POCO"/> into <see cref="Product_DTO"/> objects and vice versa 
    /// </summary>
    internal static class ProductMapper
    {
        internal static Product_DTO Map(Product_POCO poco) =>
        new Product_DTO
        {
            ProductID = poco.ProductID,
            ProductName = poco.ProductName,
            UnitPrice = poco.UnitPrice
        };

        internal static Product_POCO Map(Product_DTO dto) =>
        new Product_POCO
        {
            ProductID = dto.ProductID,
            ProductName = dto.ProductName,
            UnitPrice = dto.UnitPrice
        };
    }
}