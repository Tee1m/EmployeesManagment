using System;
using System.Text.RegularExpressions;

namespace Domain.Employee.Rules
{
    public class EmployeeEmailMustBeValidFormatRule : IBusinessRule
    {
        readonly private string _email;
        readonly private string _emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public EmployeeEmailMustBeValidFormatRule(string email)
        {
            this._email = email;
        }

        public string Message => "Podano błędny format e-mail pracownika";

        public bool IsBroken()
        {
            return !Regex.IsMatch(_email, _emailPattern);
        }
    }
}
