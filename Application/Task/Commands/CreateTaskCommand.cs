using Domain.Task.States;
using MediatR;
using System;

namespace Application.Configuration.Commands
{
    public class CreateTaskCommand : IRequest<bool>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime FinallDate { get; set; }
        public int EmployeeId { get; set; }
        public TaskState State { get; set; }
    }
}
