using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employee;
using System.Collections.Generic;
using System.Linq;

namespace Application.Configuration.Commands.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, bool>
    {
        private IEmployeesRepository _employeeRepository;

        public CreateTaskCommandHandler(IEmployeesRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAll();
            var employee = employees.Where(x => x.Id == request.EmployeeId).First();

            var task = new Domain.Task.Task(request.Title, request.Content, request.TaskState);
            employee.AddTask(task);

            await _employeeRepository.Update(employee);

            return true;
        }
    }
}
