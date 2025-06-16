using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Request.Data.Repository;
using Shared.Data.Extensions;
using Shared.Data.Interceptors;

namespace Request;

public static class RequestModule
{
    public static IServiceCollection AddRequestModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Add your module's services here
        // For example:
        // services.AddScoped<IYourService, YourService>();

        // Application User Case services
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.Decorate<IRequestRepository, CachedRequestRepository>();

        // Infrastructure services
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventInterceptor>();

        services.AddDbContext<RequestDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(configuration.GetConnectionString("Database"));
        });

        services.AddScoped<IDataSeeder, RequestDataSeed>();

        return services;
    }

    public static IApplicationBuilder UseRequestModule(this IApplicationBuilder app)
    {
        // Configure your module's middleware here
        // For example:
        // app.UseMiddleware<YourMiddleware>();

        app.UseMigration<RequestDbContext>();

        return app;
    }
}