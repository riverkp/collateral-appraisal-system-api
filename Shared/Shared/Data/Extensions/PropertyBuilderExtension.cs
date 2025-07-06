using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shared.Data.Extensions;

public static class PropertyBuilderExtension
{
    // Username
    public static PropertyBuilder<string> UseUserNameConfig(this PropertyBuilder<string> builder)
    {
        return builder.HasMaxLength(10).IsRequired();
    }

    // Code
    public static PropertyBuilder<T> UseCodeConfig<T>(this PropertyBuilder<T> builder)
    {
        return builder.HasMaxLength(10);
    }

    // Remark
    public static PropertyBuilder<T> UseRemarkConfig<T>(this PropertyBuilder<T> builder)
    {
        return builder.HasMaxLength(4000);
    }

    // Money
    public static PropertyBuilder<decimal> UseMoneyConfig(this PropertyBuilder<decimal> builder)
    {
        return builder.HasPrecision(19, 4);
    }

    // Money Nullable
    public static PropertyBuilder<decimal?> UseMoneyConfig(this PropertyBuilder<decimal?> builder)
    {
        return builder.HasPrecision(19, 4);
    }
}