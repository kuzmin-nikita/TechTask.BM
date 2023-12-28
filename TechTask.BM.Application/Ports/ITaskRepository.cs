using Task = TechTask.BM.Application.Models.Task;

namespace TechTask.BM.Application.Ports;

public interface ITaskRepository
{
    Task<Guid> CreateOrUpdateTaskAsync(Task task, CancellationToken cancellationToken);
    Task<Task?> GetTaskAsync(Guid id, CancellationToken cancellationToken);
}
