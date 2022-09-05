using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employee;
using Application.Employee.Commands;
using System.Collections.Generic;
using System.Linq;

namespace Application.Employee.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private IEmployeesRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeesRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employess = await _employeeRepository.GetAll() as List<Domain.Employee.Employee>;

            var employeeToDelete = employess.Where(x => x.Id == request.Id).First();

            if(employeeToDelete != null)
            {
                await _employeeRepository.Delete(employeeToDelete);
                return true;
            }

            return false;
        }
    }
}
