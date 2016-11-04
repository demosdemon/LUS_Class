using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.DAL.POCOS
{
    /// <summary>
    /// This class models a Table name Products aka POCO class
    /// </summary>
    public class Product_POCO
    {
        /// <summary>
        /// ProductID read write int
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// ProductName read write string
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// UnitPrice read write string
        /// </summary>
        public decimal? UnitPrice { get; set; }
    }
}
