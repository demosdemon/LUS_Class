using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.DAL.POCOS
{
    /// <summary>
    /// This class models a Table named Employees
    /// aka POCO CLASS - 
    /// </summary>
    public class Employee_POCO
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
        /// Title read write string
        /// </summary>
        public string Title { get; set; }
        ///  <summary>
        /// HomePhone read write string
        /// </summary>
        public string HomePhone { get; set; }
        ///  <summary>
        /// HireDate read write date time
        /// </summary>
        public DateTime? HireDate { get; set; }

    }
}
