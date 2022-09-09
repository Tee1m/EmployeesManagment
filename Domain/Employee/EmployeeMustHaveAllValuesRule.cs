using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Employee
{
    public class EmployeeMustHaveAllValuesRule : IBusinessRule
    {
        readonly private string _firstName;
        readonly private string _secondName;
        readonly private string _email;
        readonly private Role _role;
          

        public EmployeeMustHaveAllValuesRule(string firstName, string secondName, string email, Role role)
        {
            _firstName = firstName;
            _secondName = secondName;
            _email = email;
            _role = role;
        }

        public string Message => "Nie podano wszystkich danych pracownika";

        public bool IsBroken()
        {
            return _firstName == null ||
                   _secondName == null ||
                   _email == null ||
                   !System.Enum.IsDefined(_role.GetType(), _role);
        }
    }
}
