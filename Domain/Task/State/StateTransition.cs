namespace Domain.Task.State
{
    internal class StateTransition
    {
        public TaskState Current { get; private set; }
        public TaskState Next { get; private set; }

        public StateTransition(TaskState current, TaskState next)
        {
            Current = current;
            Next = next;
        }
    }
}
