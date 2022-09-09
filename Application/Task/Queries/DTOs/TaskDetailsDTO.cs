using Domain.Task.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Task.DTOs
{
    public class TaskDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public TaskState CurrentState { get; set; }
        public TaskState? NextAcceptState { get; set; }
        public TaskState? NextCancelState { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
