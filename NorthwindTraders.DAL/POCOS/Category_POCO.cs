using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.DAL.POCOS
{
    /// <summary>
    /// This class models a table named Categories aka POCO class
    /// </summary>
    public class Category_POCO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
