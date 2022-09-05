using Domain.Employee.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employee
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public List<Task.Task> Tasks { get; set; }

        private Employee() { }

        public Employee(string firstName, string secondName, Role role, string email)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Role = role;
            this.Email = email;
            this.Tasks = new List<Task.Task>();
        }

        public void AddTask(Task.Task task)
        {
            Tasks.Add(task);
        }

        public IBusinessRule IsUnique(IEmployeeUniquenessChecker checker)
            => new EmployeeEmailMustBeUniqueRule(checker, Email);
    }
}
