using Domain.Task.States;

namespace MVC.Controllers.Requests
{
    public class CreateTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string FinallDate { get; set; }
        public int EmployeeId { get; set; }
        public TaskState State { get; set; }
    }
}
