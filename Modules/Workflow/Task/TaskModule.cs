using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Task;

public static class TaskModule
{
    public static IServiceCollection AddTaskModule(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IApplicationBuilder UseTaskModule(this IApplicationBuilder app)
    {
        return app;
    }
}