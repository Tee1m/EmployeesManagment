using Domain.Employee.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employee.Rules
{
    public class EmployeeEmailMustBeUniqueRule : IBusinessRule
    {
        private readonly IEmployeeUniquenessChecker _employeeUniquenessChecker;
        private readonly string _email;
        

        public EmployeeEmailMustBeUniqueRule(
            IEmployeeUniquenessChecker checker,
            string email)
        {
            this._employeeUniquenessChecker = checker;
            this._email = email;
        }

        public string Message => "Podany adres e-mail nie jest unikalny";

        public bool IsBroken() => _employeeUniquenessChecker.IsUnique(_email).Result;
    }
}
