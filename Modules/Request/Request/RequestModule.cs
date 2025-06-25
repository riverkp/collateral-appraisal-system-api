using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Request.Configurations;
using Request.Data.Repository;
using Shared.Data.Extensions;
using Shared.Data.Interceptors;

namespace Request;

public static class RequestModule
{
    public static IServiceCollection AddRequestModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure Mapster mappings
        MappingConfiguration.ConfigureMappings();

        // Application User Case services
        services.AddScoped<IRequestRepository, RequestRepository>();

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
        app.UseMigration<RequestDbContext>();

        return app;
    }
}