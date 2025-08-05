using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Database.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseMigration(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Register DbUp services
        services.AddSingleton<Migration.DatabaseMigrator>();
        services.AddSingleton<Migration.MigrationService>();

        // Register simplified migration service as the primary IMigrationService
        // This only handles views, stored procedures, and functions via DbUp
        services.AddScoped<Migration.IMigrationService>(provider =>
        {
            var dbUpService = provider.GetRequiredService<Migration.MigrationService>();
            var config = provider.GetRequiredService<IConfiguration>();
            var logger = provider.GetRequiredService<ILogger<Migration.SimplifiedMigrationService>>();
            
            return new Migration.SimplifiedMigrationService(
                dbUpService,
                config, 
                logger);
        });
        
        return services;
    }
}