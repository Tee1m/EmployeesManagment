using Domain.Task.State;
using System;

namespace Application.Task.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskState CurrentState { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
