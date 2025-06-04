namespace Request.Data;

public class RequestDbContext : DbContext
{
    public RequestDbContext(DbContextOptions<RequestDbContext> options) : base(options) { }

    public DbSet<Requests.Models.Request> Requests => Set<Requests.Models.Request>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Configure the default schema for the database
        builder.HasDefaultSchema("request");

        // Apply configurations from the current assembly
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Call the base method to ensure any additional configurations are applied
        base.OnModelCreating(builder);
    }
}
