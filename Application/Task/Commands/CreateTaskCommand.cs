using Application.Task.Commands.Results;
using Domain.Task.State;
using MediatR;
using System;

namespace Application.Configuration.Commands
{
    public class CreateTaskCommand : IRequest<CreateTaskResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime FinallDate { get; set; }
        public int EmployeeId { get; set; }
        public TaskState State { get; set; }
    }
}
