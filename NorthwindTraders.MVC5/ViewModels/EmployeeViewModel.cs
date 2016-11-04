using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindTraders.MVC5.ViewModels
{
    public class EmployeeViewModel
    {
        ///  <summary>
        /// EmployeeID read write int
        /// </summary>
        public int EmployeeID { get; set; }
        ///  <summary>
        /// LastName read write string
        /// </summary>
        public string LastName { get; set; }
        ///  <summary>
        /// FirstName read write string
        /// </summary>
        public string FirstName { get; set; }
        ///  <summary>
        /// HomePhone read write string
        /// </summary>
        public string HomePhone { get; set; }
        ///  <summary>
        /// HireDate read write date time
        /// </summary>
        public DateTime? HireDate { get; set; }
        /// <summary>
        /// <see cref="HireDate"/> readonly formatted as long date: ex Monday, June 15, 2009
        /// </summary>
        public string FormattedHireDate => HireDate?.ToString("D");
    }
}