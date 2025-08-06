using System.Reflection;
using Assignment;
using Auth;
using Database.Migration;
using Document;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Notification;
using Request;
using Testcontainers.MsSql;
using Testcontainers.RabbitMq;

namespace Integration.Fixtures;

public class IntegrationTestFixture : IAsyncLifetime
{
    public MsSqlContainer Mssql { get; } = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .Build();

    public string ConnectionString => Mssql.GetConnectionString();
    public RabbitMqContainer RabbitMq { get; } = new RabbitMqBuilder()
        .WithImage("rabbitmq:3-management")
        .WithEnvironment("RABBITMQ_DEFAULT_USER", "testuser")
        .WithEnvironment("RABBITMQ_DEFAULT_PASS", "testpw")
        .WithPortBinding(5672, true)
        .Build();

    async ValueTask IAsyncLifetime.InitializeAsync()
    {
        await Mssql.StartAsync();
        await RabbitMq.StartAsync();
        await ApplyAllMigrationsAsync();
        await ApplyDatabaseModuleAsync();
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        GC.SuppressFinalize(this);
        await Mssql.DisposeAsync();
        await RabbitMq.DisposeAsync();
    }

    private async Task ApplyAllMigrationsAsync()
    {
        var dbContexts = GetAllDbContexts();
        var migrateMethod = GetType().GetMethod("MigrateAsync", BindingFlags.Instance | BindingFlags.NonPublic)!;

        foreach (var dbContext in dbContexts)
        {
            var genericMethod = migrateMethod.MakeGenericMethod(dbContext);
            Task task = (Task)genericMethod.Invoke(this, null)!;
            await task;
        }
    }

    private async Task MigrateAsync<TContext>() where TContext : DbContext
    {
        var options = new DbContextOptionsBuilder<TContext>()
            .UseSqlServer(Mssql.GetConnectionString())
            .Options;

        using var context = (TContext)Activator.CreateInstance(typeof(TContext), options)!;
        await context.Database.MigrateAsync();
    }

    private static List<Type> GetAllDbContexts()
    {
        var requestAssembly = typeof(RequestModule).Assembly;
        var authAssembly = typeof(AuthModule).Assembly;
        var notificationAssembly = typeof(NotificationModule).Assembly;
        var documentAssembly = typeof(DocumentModule).Assembly;
        var assignmentAssembly = typeof(AssignmentModule).Assembly;

        var dbContexts = GetDbContextsFromAssemblies(requestAssembly, authAssembly, notificationAssembly, documentAssembly, assignmentAssembly);
        return dbContexts;
    }

    private static List<Type> GetDbContextsFromAssemblies(params Assembly[] assemblies)
    {
        var allDbContexts = new List<Type> { };
        foreach (var assembly in assemblies)
        {
            var dbContexts = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(DbContext)))
                .ToArray();
            allDbContexts.AddRange(dbContexts);
        }
        return allDbContexts;
    }

    private async Task ApplyDatabaseModuleAsync()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "ConnectionStrings:DefaultConnection", Mssql.GetConnectionString() }
            })
            .Build();

        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var databaseLogger = loggerFactory.CreateLogger<DatabaseMigrator>();
        var databaseMigrator = new DatabaseMigrator(configuration, databaseLogger);
        var migrationLogger = loggerFactory.CreateLogger<MigrationService>();

        var service = new MigrationService(databaseMigrator, configuration, migrationLogger);
        await service.MigrateAsync();
    }
}