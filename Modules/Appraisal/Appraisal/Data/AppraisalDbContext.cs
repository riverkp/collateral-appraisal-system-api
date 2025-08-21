namespace Appraisal.Data;

public class AppraisalDbContext : DbContext
{
    public AppraisalDbContext(DbContextOptions<AppraisalDbContext> options) : base(options)
    {
    }

    public DbSet<Appraisals.Models.Appraisal> Appraisals => Set<Appraisals.Models.Appraisal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Appraisal");

        modelBuilder.ApplyGlobalConventions();

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}