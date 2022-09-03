using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Configuration.Commands
{
    public class CreateEmployeeCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
