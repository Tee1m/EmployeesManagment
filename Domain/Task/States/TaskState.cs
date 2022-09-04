namespace Domain.Task.States
{
    public enum TaskState
    {
        New = 10,
        InProgress = 20,
        ReOpened = 30,
        ToTest = 40,
        ToSpecify = 50,
        Completed = 60,
        Canceled = 70
    }
}
