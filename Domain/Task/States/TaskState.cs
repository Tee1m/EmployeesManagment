namespace Domain.Task.States
{
    public enum TaskState
    {
        New = 100,
        InProgress = 200,
        ReOpened = 300,
        ToTest = 400,
        ToSpecify = 500,
        Completed = 600,
        Canceled = 700
    }
}
