using TechTask.BM.Application.Exceptions;
using TechTask.BM.Application.Ports;
using TaskStatus = TechTask.BM.Application.Models.TaskStatus;

namespace TechTask.BM.Application.Adapters;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Guid> AddTaskAsync(CancellationToken cancellationToken)
    {
        var task = new Models.Task
        {
            Id = Guid.NewGuid(),
            StatusChangedTime = DateTime.UtcNow,
            Status = TaskStatus.Created,
        };

        var guid = await _taskRepository.CreateOrUpdateTaskAsync(task, cancellationToken);

        _ = DelayedUpdate(task, cancellationToken);

        return guid;
    }

    private async Task DelayedUpdate(Models.Task task, CancellationToken cancellationToken)
    {
        task.UpdateStatus(TaskStatus.Running);
        _ = _taskRepository.CreateOrUpdateTaskAsync(task, cancellationToken);

        await Task.Delay(new TimeSpan(hours: 0, minutes: 2, seconds: 0), cancellationToken);

        task.UpdateStatus(TaskStatus.Finished);
        _ = _taskRepository.CreateOrUpdateTaskAsync(task, cancellationToken);
    }

    public async Task<Models.Task> GetTaskAsync(string id, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(id, out var guid))
        {
            throw new BadRequestException($"Input Id = {id} is not a Guid.");
        }

        var task = await _taskRepository.GetTaskAsync(guid, cancellationToken);

        return task ?? throw new NotFoundException($"Task with Id = {guid} not found.");
    }
}
