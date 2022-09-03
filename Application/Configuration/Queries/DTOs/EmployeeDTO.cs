using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Configuration.Queries.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
