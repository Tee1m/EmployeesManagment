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
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Email { get; private set; }
        public Role Role { get; private set; }
        public List<Task.Task> Tasks { get; set; }

        private Employee() 
        {
            this.Tasks = new List<Task.Task>();
        }

        private Employee(string firstName, string secondName, Role role, string email)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Role = role;
            this.Email = email;
            this.Tasks = new List<Task.Task>();
        }

        public static Employee Create(string firstName, string secondName, Role role, string email, IEmployeeUniquenessChecker checker)
        {
            CheckRule(new EmployeeMustHaveAllValuesRule(firstName, secondName, email, role));
            CheckRule(new EmployeeEmailMustBeValidFormatRule(email));
            CheckRule(new EmployeeEmailMustBeUniqueRule(checker, email));
            
            return new Employee(firstName, secondName, role, email);
        }

        public void AddTask(Task.Task task)
        {
            Tasks.Add(task);
        }

        public IBusinessRule IsUnique(IEmployeeUniquenessChecker checker)
            => new EmployeeEmailMustBeUniqueRule(checker, Email);
    }
}
