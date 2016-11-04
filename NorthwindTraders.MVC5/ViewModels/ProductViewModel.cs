using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindTraders.MVC5.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public string FormattedPrice => UnitPrice?.ToString("c");
    }
}