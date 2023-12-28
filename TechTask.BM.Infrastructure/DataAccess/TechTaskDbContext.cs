using Microsoft.EntityFrameworkCore;

namespace TechTask.BM.Application.DataAccess;

public class TechTaskDbContext : DbContext
{
    public TechTaskDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=localhost:5432;Database=TechTask;userid=root;password=root;Include Error Detail=true");
    }

    public DbSet<Models.Task> Tasks { get; set; }
}
