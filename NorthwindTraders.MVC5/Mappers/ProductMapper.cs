using NorthwindTraders.MVC5.NorthwindServiceClasses;
using NorthwindTraders.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindTraders.MVC5.Mappers
{
    internal static class ProductMapper
    {
        internal static ProductViewModel Map(Product_DTO dto)
        {
            return new ProductViewModel
            {
                ProductID = dto.ProductID,
                ProductName = dto.ProductName,
                UnitPrice = dto.UnitPrice
            };
        }
    }
}