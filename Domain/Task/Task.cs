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
        public string Title { get; private set; }
        public string Content { get; private set; }
        public TaskState CurrentState { get; private set; }
        public DateTime? FinishDate { get; private set; }

        public DateTime CreatedDate { get; private set; }

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
