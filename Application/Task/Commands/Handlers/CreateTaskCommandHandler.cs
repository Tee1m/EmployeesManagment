using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employee;
using System.Collections.Generic;
using System.Linq;
using Application.Task.Commands.Results;

namespace Application.Configuration.Commands.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskResult>
    {
        private IEmployeesRepository _employeeRepository;

        public CreateTaskCommandHandler(IEmployeesRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<CreateTaskResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAll();
            var employee = employees.Where(x => x.Id == request.EmployeeId).First();

            var task = Domain.Task.Task.Create(request.Title, request.Description, request.State);
            employee.AddTask(task);

            await _employeeRepository.Update(employee);

            var response = new CreateTaskResult()
            {
                Title = task.Title,
                State = task.CurrentState,
                Description = task.Content,
                Created = task.CreatedDate,
                FinishDate = task.FinishDate,
                EmployeeFirstName = employee.FirstName,
                EmployeeSecondName = employee.SecondName
            };

            return response;
        }
    }
}
