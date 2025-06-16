using Microsoft.EntityFrameworkCore;

namespace Shared.Data.Extensions;

public static class ModelBuilderExtension
{
    public static void ApplyGlobalConventions(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()) 
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.Name is "CreatedBy" or "UpdatedBy" && property.ClrType == typeof(string))
                    property.SetMaxLength(10);
            }
        }
    }
}