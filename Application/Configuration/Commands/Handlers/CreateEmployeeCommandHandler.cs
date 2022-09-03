using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employee;
using Application.DomainServices;
using Application.Configuration.Data;

namespace Application.Configuration.Commands.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
    {
        private IEmployeeRepository _employeeRepository;
        private ISqlConnectionFactory _sqlConnectionFactory;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, ISqlConnectionFactory sqlConnectionFactory)
        {
            _employeeRepository = employeeRepository;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        async Task<bool> IRequestHandler<CreateEmployeeCommand, bool>.Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee(request.FirstName, request.SecondName, request.Age, request.TelephoneNumber);

            if (employee.IsUnique(new EmployeeUniquenessChecker(_sqlConnectionFactory)).IsValid())
            {
                await _employeeRepository.Add(employee);

                return true;
            }

            return false;
        }
    }
}
