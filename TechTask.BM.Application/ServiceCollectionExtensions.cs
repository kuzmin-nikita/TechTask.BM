using Microsoft.Extensions.DependencyInjection;
using TechTask.BM.Application.Adapters;
using TechTask.BM.Application.Ports;

namespace TechTask.BM.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ITaskService, TaskService>();

        return services;
    }
}
