using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindTraders.DAL.Contracts;
using NorthwindTraders.DAL.POCOS;

namespace NorthwindTraders.DAL
{
    public class EmployeeDataAccess : IEmployeeDAL
    {
        public int CreateEmployee(Employee_POCO employee)
        {
            int rowsAffected;

            using (var northwindCtx = new Northwind())
                rowsAffected = northwindCtx.CreateEmployee(employee.LastName,
                    employee.FirstName,
                    employee.Title,
                    employee.HomePhone,
                    employee.HireDate);

            return rowsAffected;
        }

        public int ReadEmployeeCount()
        {
            int employeeCount = 0;

            using (var northwindCtx = new Northwind())
                employeeCount = northwindCtx.Employees.Count();

            return employeeCount;
        }

        public List<Employee_POCO> ReadEmployeesByTitle(string title)
        {
            var employees = null as List<Employee_POCO>;

            using (var northwindCtx = new Northwind())
                employees = northwindCtx.GetEmployeesByTitle(title);

            return employees;
        }

        public List<string> ReadDistinctTitles()
        {
            var titles = null as List<string>;

            using (var northwindCtx = new Northwind())
                titles = northwindCtx.GetEmployeeTitles().ToList();

            return titles;
        }
    }
}
