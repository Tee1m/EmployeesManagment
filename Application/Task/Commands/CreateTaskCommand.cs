using Domain.Task.States;
using MediatR;

namespace Application.Configuration.Commands
{
    public class CreateTaskCommand : IRequest<bool>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int EmployeeId { get; set; }
        public TaskState TaskState { get; set; }
    }
}
