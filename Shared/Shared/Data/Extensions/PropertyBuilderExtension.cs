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

    public static PropertyBuilder<string?> UseShortStringConfig(this PropertyBuilder<string?> builder)
    {
        return builder.HasMaxLength(25);
    }

    public static PropertyBuilder<string?> UseSubStringConfig(this PropertyBuilder<string?> builder)
    {
        return builder.HasMaxLength(50);
    }

    public static PropertyBuilder<string?> UseNameConfig(this PropertyBuilder<string?> builder)
    {
        return builder.HasMaxLength(100);
    }

    public static PropertyBuilder<decimal?> UseAreaConfig(this PropertyBuilder<decimal?> builder)
    {
        return builder.HasPrecision(5, 2);
    }

    public static PropertyBuilder<decimal?> UseSizeConfig(this PropertyBuilder<decimal?> builder)
    {
        return builder.HasPrecision(7, 2);
    }

    public static PropertyBuilder<decimal?> UseLatLonConfig(this PropertyBuilder<decimal?> builder)
    {
        return builder.HasPrecision(9, 6);
    }
}