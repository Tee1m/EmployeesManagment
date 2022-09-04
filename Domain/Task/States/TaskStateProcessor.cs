namespace Domain.Task.States
{
    public static class TaskStateProcessor
    {
        public static TaskState GetNextAcceptState(TaskState currentState)
        {
            switch (currentState)
            {
                case TaskState.New:
                    currentState = TaskState.InProgress;
                    break;

                case TaskState.InProgress:
                    currentState = TaskState.ToTest;
                    break;

                case TaskState.ReOpened:
                    currentState = TaskState.InProgress;
                    break;

                case TaskState.ToTest:
                    currentState = TaskState.Completed;
                    break;

                case TaskState.ToSpecify:
                    currentState = TaskState.Completed;
                    break;

                case TaskState.Completed:
                    currentState = TaskState.ReOpened;
                    break;

                case TaskState.Canceled:
                    currentState = TaskState.ReOpened;
                    break;

                default:
                    currentState = TaskState.New;
                    break;
            }

            return currentState;
        }

        public static TaskState GetNextCancelState(TaskState currentState)
        {
            switch (currentState)
            {
                case TaskState.New:
                    currentState = TaskState.Canceled;
                    break;

                case TaskState.InProgress:
                    currentState = TaskState.ToSpecify;
                    break;

                case TaskState.ReOpened:
                    currentState = TaskState.Canceled;
                    break;

                case TaskState.ToTest:
                    currentState = TaskState.ReOpened;
                    break;

                case TaskState.ToSpecify:
                    currentState = TaskState.ReOpened;
                    break;

                case TaskState.Completed:
                    currentState = TaskState.Canceled;
                    break;

                default:
                    currentState = TaskState.New;
                    break;
            }

            return currentState;
        }
    }
}
