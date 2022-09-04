using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employee.Rules
{
    public class EmployeeTelephoneNumberMustBeUniqueRule : IBusinessRule
    {
        private readonly IEmployeeUniquenessChecker _employeeUniquenessChecker;
        private readonly string _email;

        public EmployeeTelephoneNumberMustBeUniqueRule(
            IEmployeeUniquenessChecker checker,
            string email)
        {
            this._employeeUniquenessChecker = checker;
            this._email = email;
        }

        public bool IsValid() => _employeeUniquenessChecker.IsUnique(_email).Result;
    }
}
