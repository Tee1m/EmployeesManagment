using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employee;
using Application.DomainServices;
using Application.Configuration.Data;
using Application.Employee.Commands;
using Application.Employee.Commands.Results;

namespace Application.Employee.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResult>
    {
        private readonly IEmployeesRepository _employeeRepository;
        private readonly IEmployeeUniquenessChecker _checker;

        public CreateEmployeeCommandHandler(IEmployeesRepository employeeRepository, IEmployeeUniquenessChecker checker)
        {
            this._employeeRepository = employeeRepository;
            this._checker = checker;
        }

        async Task<CreateEmployeeResult> IRequestHandler<CreateEmployeeCommand, CreateEmployeeResult>.Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = Domain.Employee.Employee.Create(request.FirstName, request.SecondName, request.Role, request.Email, _checker);

            await _employeeRepository.Add(employee);

            var result = new CreateEmployeeResult();
            result.FullName = employee.FirstName + " " + employee.SecondName;
            result.Email = employee.Email;
            result.Role = employee.Role;

            return result;
        }
    }
}
