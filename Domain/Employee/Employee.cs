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
        public int Age { get; set; }
        public string TelephoneNumber { get; set; }
        public List<Task.Task> Tasks { get; set; }

        private Employee() { }

        public Employee(string firstName, string secondName, int age, string telephoneNumber)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.TelephoneNumber = telephoneNumber;
            this.Tasks = new List<Task.Task>();
        }

        public void AddTask(Task.Task task)
        {
            Tasks.Add(task);
        }

        public IBusinessRule IsUnique(IEmployeeUniquenessChecker checker)
            => new EmployeeTelephoneNumberMustBeUniqueRule(checker, TelephoneNumber);
    }
}
