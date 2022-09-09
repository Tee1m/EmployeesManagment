using Domain.Task.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Task.Commands.Results
{
    public class CreateTaskResult
    {
        public string Title { get; set; }
        public TaskState State { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? FinishDate { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeSecondName { get; set; }
    }
}
