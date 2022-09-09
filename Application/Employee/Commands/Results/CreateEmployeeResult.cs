using Domain.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employee.Commands.Results
{
    public class CreateEmployeeResult
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
