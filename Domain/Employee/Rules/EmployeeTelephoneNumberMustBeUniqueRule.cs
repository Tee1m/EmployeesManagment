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
        private readonly string _telephoneNumber;

        public EmployeeTelephoneNumberMustBeUniqueRule(
            IEmployeeUniquenessChecker checker,
            string telephoneNumber)
        {
            this._employeeUniquenessChecker = checker;
            this._telephoneNumber = telephoneNumber;
        }

        public bool IsValid() => _employeeUniquenessChecker.IsUnique(_telephoneNumber).Result;
    }
}
