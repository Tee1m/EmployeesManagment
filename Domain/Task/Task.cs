using Domain.Task.Rules;
using Domain.Task.State;
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

        readonly private List<StateTransition> stateTransitions = new List<StateTransition>()
        {
            new StateTransition(TaskState.New, TaskState.InProgress),
            new StateTransition(TaskState.New, TaskState.Canceled),
            new StateTransition(TaskState.InProgress, TaskState.ToSpecify),
            new StateTransition(TaskState.InProgress, TaskState.ToTest),
            new StateTransition(TaskState.ReOpened, TaskState.InProgress),
            new StateTransition(TaskState.ReOpened, TaskState.Canceled),
            new StateTransition(TaskState.ToTest, TaskState.ReOpened),
            new StateTransition(TaskState.ToTest, TaskState.Completed),
            new StateTransition(TaskState.ToSpecify, TaskState.ReOpened),
            new StateTransition(TaskState.ToSpecify, TaskState.Canceled),
            new StateTransition(TaskState.Completed, TaskState.ReOpened),
            new StateTransition(TaskState.Completed, TaskState.Canceled),
            new StateTransition(TaskState.Canceled, TaskState.ReOpened)
        };

        private Task()
        {
            this.CurrentState = TaskState.New;
        }

        private Task(string title, string content, TaskState taskState)
        {
            CheckRule(new TaskMustHaveAllValues(title, content, taskState));

            this.Title = title;
            this.Content = content;
            this.CurrentState = taskState;
            this.CreatedDate = DateTime.Now;
        }

        public static Task Create(string title, string content, TaskState taskState)
        {
            var task = new Task(title, content, taskState);
        
            return task;
        }

        public IEnumerable<TaskState> GetNextStates()
        {
            return stateTransitions.Where(c => c.Current == CurrentState).Select(n => n.Next);
        }

        public bool ChangeState(TaskState state)
        {
            var isValid = stateTransitions.Where(c => c.Current == CurrentState).Any();

            if (isValid)
                CurrentState = state;

            return isValid;
        }
    }
}
