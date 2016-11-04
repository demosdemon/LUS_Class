using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindTraders.DAL.POCOS;

namespace NorthwindTraders.DAL.Contracts
{
    public interface ICategoryDAL
    {
        List<Category_POCO> ReadAllCategories();
    }
}
