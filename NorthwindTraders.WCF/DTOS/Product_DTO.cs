using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindTraders.WCF.DTOS
{
    public class Product_DTO
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