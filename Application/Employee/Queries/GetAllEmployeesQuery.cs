using Application.Employee.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employee.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDTO>>
    {
    }
}
