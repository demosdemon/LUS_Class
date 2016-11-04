using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using NorthwindTraders.WCF.DTOS;

namespace NorthwindTraders.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INorthwindContract" in both code and config file together.
    [ServiceContract]
    public interface INorthwindContract
    {

        [OperationContract]
        List<Category_DTO> ReadAllCategories();

        [OperationContract]
        List<Product_DTO> ReadProductsByCategory(int categoryID);

    }
}
