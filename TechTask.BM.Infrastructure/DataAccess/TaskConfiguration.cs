using Microsoft.EntityFrameworkCore;

namespace TechTask.BM.Infrastructure.DataAccess;

public class TaskConfiguration : IEntityTypeConfiguration<Application.Models.Task>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Application.Models.Task> builder)
    {
        builder.Property(x => x.Id);
        builder.Property(x => x.StatusChangedTime);
        builder.Property(x => x.Status);
    }
}
