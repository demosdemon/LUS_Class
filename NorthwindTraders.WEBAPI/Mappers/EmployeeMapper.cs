using NorthwindTraders.DAL.POCOS;
using NorthwindTraders.WEBAPI.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindTraders.WEBAPI.Mappers
{
    internal static class EmployeeMapper
    {
        internal static Employee_DTO Map(Employee_POCO poco) =>
            new Employee_DTO
            {
                EmployeeID = poco.EmployeeID,
                FirstName = poco.FirstName,
                LastName = poco.LastName,
                HomePhone = poco.HomePhone,
                HireDate = poco.HireDate
            };

        internal static Employee_POCO Map(CreateEmployee_DTO dto) =>
            new Employee_POCO
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Title = dto.Title,
                HomePhone = dto.HomePhone,
                HireDate = dto.HireDate
            };
    }
}