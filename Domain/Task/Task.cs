using Domain.Task.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Task
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public TaskState CurrentState { get; set; }
        public DateTime? FinishDate { get; set; }

        public DateTime CreatedDate { get; set; }

        private Task()
        {
            this.CurrentState = TaskState.New;
        }

        public Task(string title, string content, TaskState taskState)
        {
            this.Title = title;
            this.Content = content;
            this.CurrentState = taskState;
            this.CreatedDate = DateTime.Now;
            this.CurrentState = TaskState.New;
        }

        //public bool ChangeState(TaskState newState)
        //{

        //}

        public void NextAcceptState()
        {
            CurrentState = TaskStateProcessor.GetNextAcceptState(this.CurrentState);
        }

        public void NextCancelState()
        {
            CurrentState = TaskStateProcessor.GetNextCancelState(this.CurrentState);
        }
    }
}
