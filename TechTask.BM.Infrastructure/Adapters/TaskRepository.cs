using Microsoft.EntityFrameworkCore;
using TechTask.BM.Application.DataAccess;
using TechTask.BM.Application.Ports;

namespace TechTask.BM.Infrastructure.Adapters;

public class TaskRepository : ITaskRepository
{
    private readonly TechTaskDbContext _dbContext;

    public TaskRepository(TechTaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> CreateOrUpdateTaskAsync(Application.Models.Task task, CancellationToken cancellationToken)
    {
        var dbTask = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id, cancellationToken: cancellationToken);

        if (dbTask == null)
        {
            _dbContext.Tasks.Add(task);
        }
        else
        {
            dbTask = task;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return task.Id;
    }

    public async Task<Application.Models.Task?> GetTaskAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }
}
