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

            using (var ctx = new NorthwindEntities())
                rowsAffected = ctx.CreateEmployee(employee.LastName,
                    employee.FirstName,
                    employee.Title,
                    employee.HomePhone,
                    employee.HireDate);

            return rowsAffected;
        }

        public int ReadEmployeeCount()
        {
            int employeeCount = 0;

            using (var ctx = new NorthwindEntities())
                employeeCount = ctx.Employees.Count();

            return employeeCount;
        }

        public List<Employee_POCO> ReadEmployeesByTitle(string title)
        {
            var employees = null as List<Employee_POCO>;

            using (var ctx = new NorthwindEntities())
                employees = ctx.GetEmployeesByTitle(title)
                    .AsEnumerable()
                    .Select(employee => new Employee_POCO
                    {
                        EmployeeID = employee.EmployeeID,
                        LastName = employee.LastName,
                        FirstName = employee.FirstName,
                        Title = employee.Title,
                        HomePhone = employee.HomePhone,
                        HireDate = employee.HireDate
                    })
                    .ToList();

            return employees;
        }

        public List<string> ReadDistinctTitles()
        {
            var titles = null as List<string>;

            using (var ctx = new NorthwindEntities())
                titles = ctx.GetEmployeeTitles().ToList();

            return titles;
        }
    }
}
