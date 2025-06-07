using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth;

public static class AuthModule
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddOpenIddictModule(configuration);
        return services;
    }

    public static IApplicationBuilder UseAuthModule(this IApplicationBuilder app)
    {
        // Configure your module's middleware here
        // For example:
        // app.UseMiddleware<YourMiddleware>();

        //app.UseMigration<AuthDbContext>();
        //app.UseOpenIddictModule();

        return app;
    }
}