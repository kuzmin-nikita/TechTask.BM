using Microsoft.Extensions.DependencyInjection;
using TechTask.BM.Application.DataAccess;
using TechTask.BM.Application.Ports;
using TechTask.BM.Infrastructure.Adapters;

namespace TechTask.BM.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ITaskRepository, TaskRepository>();
        services.AddSingleton<TechTaskDbContext>();

        return services;
    }
}