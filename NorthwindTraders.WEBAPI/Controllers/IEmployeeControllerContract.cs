using System.Collections.Generic;
using NorthwindTraders.WEBAPI.DTOS;

namespace NorthwindTraders.WEBAPI.Contracts
{
    public interface IEmployeeControllerContract
    {
        int CreateEmployee(CreateEmployee_DTO employee);
        int ReadEmployeeCount();
        List<Employee_DTO> ReadEmployeesByTitle(string title);
        List<string> ReadDistinctTitles();
    }
}