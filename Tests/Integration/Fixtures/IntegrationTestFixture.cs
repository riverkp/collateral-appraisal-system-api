using Database.Migration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Request.Data;
using Testcontainers.MsSql;
using Testcontainers.RabbitMq;

namespace Integration.Fixtures;

public class IntegrationTestFixture: IAsyncLifetime
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

        var options = new DbContextOptionsBuilder<RequestDbContext>()
            .UseSqlServer(Mssql.GetConnectionString())
            .Options;

        using (var context = new RequestDbContext(options))
        {
            await context.Database.MigrateAsync();
        }

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "ConnectionStrings:DefaultConnection", Mssql.GetConnectionString() }
            })
            .Build();
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<DatabaseMigrator>();
        var databaseMigrator = new DatabaseMigrator(configuration, logger);
        var migrationLogger = loggerFactory.CreateLogger<MigrationService>();
        var service = new MigrationService(databaseMigrator, configuration, migrationLogger);
        await service.MigrateAsync();
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        GC.SuppressFinalize(this);
        await Mssql.DisposeAsync();
        await RabbitMq.DisposeAsync();
    }
}