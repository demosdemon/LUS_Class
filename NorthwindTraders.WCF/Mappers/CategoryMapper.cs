using NorthwindTraders.DAL.POCOS;
using NorthwindTraders.WCF.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindTraders.WCF.Mappers
{
    internal static class CategoryMapper
    {
        internal static Category_DTO Map(Category_POCO poco) =>
        new Category_DTO
        {
            CategoryID = poco.CategoryID,
            CategoryName = poco.CategoryName
        };

        internal static Category_POCO Map(Category_DTO dto) =>
        new Category_POCO
        {
            CategoryID = dto.CategoryID,
            CategoryName = dto.CategoryName
        };
    }
}