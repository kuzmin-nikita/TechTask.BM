using Task = TechTask.BM.Application.Models.Task;

namespace TechTask.BM.Application.Ports;

public interface ITaskService
{
    Task<Task> GetTaskAsync(string id, CancellationToken cancellationToken);
    Task<Guid> AddTaskAsync(CancellationToken cancellationToken);
}
