using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employee;
using Application.DomainServices;
using Application.Configuration.Data;
using Application.Employee.Commands;

namespace Application.Employee.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
    {
        private IEmployeesRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeesRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        async Task<bool> IRequestHandler<CreateEmployeeCommand, bool>.Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Domain.Employee.Employee(request.FirstName, request.SecondName, request.Role, request.Email);

            if (employee.IsUnique(new EmployeeUniquenessChecker(_employeeRepository)).IsValid())
            {
                await _employeeRepository.Add(employee);

                return true;
            }

            return false;
        }
    }
}
