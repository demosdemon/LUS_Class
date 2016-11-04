using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using NorthwindTraders.DAL;
using NorthwindTraders.WEBAPI.DTOS;
using NorthwindTraders.WEBAPI.Contracts;

using static NorthwindTraders.WEBAPI.Mappers.EmployeeMapper;

namespace NorthwindTraders.WEBAPI.Controllers
{
    public class EmployeeController : ApiController, IEmployeeControllerContract
    {
        private EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();

        [HttpPost, Route("Employee/CreateEmployee")]
        public int CreateEmployee(CreateEmployee_DTO employee)
        {
            var poco = Map(employee);

            var modified = employeeDataAccess.CreateEmployee(poco);

            return modified;
        }

        [HttpGet, Route("Employee/ReadEmployeeCount")]
        public int ReadEmployeeCount()
        {
            var employeeCount = employeeDataAccess.ReadEmployeeCount();

            return employeeCount;
        }

        [HttpGet, Route("Employee/ReadEmployeesByTitle/{title}")]
        public List<Employee_DTO> ReadEmployeesByTitle(string title)
        {
            var employees = employeeDataAccess
                .ReadEmployeesByTitle(title)
                /*
                    If an Employee's title contains the word Manager, then the Employee's
                    HomePhone must be set to the value Not Available before it is transferred
                    to the website.
                 */
                .Select(emp =>
                {
                    if (emp.Title.ToLowerInvariant().Contains("manager"))
                        emp.HomePhone = "Not Available";

                    return Map(emp);
                })
                .ToList();

            return employees;
        }

        [HttpGet, Route("Employee/ReadDistinctTitles")]
        public List<string> ReadDistinctTitles()
        {
            var titles = employeeDataAccess.ReadDistinctTitles();

            return titles;
        }
    }
}
