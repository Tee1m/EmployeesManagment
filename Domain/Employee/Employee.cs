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
        public int Age { get; private set; }
        public string TelephoneNumber { get; private set; }
        public List<Task.Task> Tasks { get; private set; }

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


    //public class TelephoneNumber : ValueObject
    //{
    //    public string Directional { get; }
    //    public string Number { get; }

    //    public TelephoneNumber(string directional, string number)
    //    {
    //        this.Directional = directional;
    //        this.Number = number;
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        if (obj == null)
    //            return false;

    //        var objj = obj as TelephoneNumber;

    //        return this.Directional == objj.Directional;
    //    }
    //}

    //public class ValueObject : IEquatable<ValueObject>
    //{
    //    public bool Equals(ValueObject other)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
