using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.DataBase.Entities
{
    [Table("Employees")]
    public class EmployeeDAL : DALObject
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string TelephoneNumber { get; set; }

        public EmployeeDAL() { }
    }
}
