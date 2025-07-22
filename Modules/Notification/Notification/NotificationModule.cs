namespace Notification;

public static class NotificationModule
{
    public static IServiceCollection AddNotificationModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }

    public static IApplicationBuilder UseNotificationModule(this IApplicationBuilder app)
    {
        return app;
    }
}