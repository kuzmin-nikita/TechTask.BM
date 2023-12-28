namespace TechTask.BM.Application.Models;

public class Task
{
    public Guid Id { get; set; }
    public DateTime StatusChangedTime { get; set; }
    public TaskStatus Status { get; set; }

    public void UpdateStatus(TaskStatus status)
    {
        StatusChangedTime = DateTime.UtcNow;
        Status = status;
    }
}
