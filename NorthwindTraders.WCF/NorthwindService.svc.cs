using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using NorthwindTraders.DAL;
using NorthwindTraders.WCF.Mappers;
using NorthwindTraders.WCF.DTOS;

namespace NorthwindTraders.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NorthwindService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NorthwindService.svc or NorthwindService.svc.cs at the Solution Explorer and start debugging.
    public class NorthwindService : INorthwindContract
    {
        private CategoryDataAccess categoryDal = new CategoryDataAccess();
        private ProductDataAccess productDal = new ProductDataAccess();

        public List<Category_DTO> ReadAllCategories()
        {
            var categories = categoryDal
                .ReadAllCategories()
                .ConvertAll(CategoryMapper.Map);

            return categories;
        }

        public List<Product_DTO> ReadProductsByCategory(int categoryID)
        {
            var products = productDal
                .ReadProductsByCategory(categoryID)
                .ConvertAll(ProductMapper.Map);

            return products;
        }
    }
}
