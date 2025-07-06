namespace Notification;

public static class NotificationModule
{
    public static IServiceCollection AddNotificationModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register notification-related services here
        // For example, you might register a notification service or handlers

        // Example:
        // services.AddScoped<INotificationService, NotificationService>();

        return services;
    }

    public static IApplicationBuilder UseNotificationModule(this IApplicationBuilder app)
    {
        // Configure notification-related middleware here if needed
        // For example, you might add middleware for handling notifications

        return app;
    }
}