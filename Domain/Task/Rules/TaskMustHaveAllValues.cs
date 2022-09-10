using Domain.Task.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Task.Rules
{
    public class TaskMustHaveAllValues : IBusinessRule
    {
        readonly private string _title;
        readonly private string _content;
        readonly private TaskState _state;

        public TaskMustHaveAllValues(string title, string content, TaskState state)
        {
            this._title = title;
            this._content = content;
            this._state = state;
        }

        public string Message => "Nie podano wszystkich wartości.";

        public bool IsBroken()
        {
            return _title == null || _title == "" ||
                 _content == null || _content == "" ||
                 !System.Enum.IsDefined(_state.GetType(), _state);
        }
    }
}
