using Application.Employee.Commands.Results;
using Domain.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employee.Commands
{
    public class CreateEmployeeCommand : IRequest<CreateEmployeeResult>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
