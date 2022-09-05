﻿using Domain.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employee.Queries.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
