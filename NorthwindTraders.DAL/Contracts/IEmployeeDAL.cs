using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindTraders.DAL.POCOS;

namespace NorthwindTraders.DAL.Contracts
{
    /// <summary>
    /// This contract contains crud signatures to query employee data
    /// IF IT IS NOT BEING CALLED FROM THE WEB API
    /// DO NOT ADD IT TO THIS CONTRACT.
    /// </summary>
    public interface IEmployeeDAL
    {
        int ReadEmployeeCount();
        List<Employee_POCO> ReadEmployeesByTitle(string title);
        List<string> ReadDistinctTitles();
        int CreateEmployee(Employee_POCO employee);
    }
}
