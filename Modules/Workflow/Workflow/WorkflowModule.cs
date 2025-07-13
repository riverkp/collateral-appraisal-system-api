using Elsa.Extensions;
using Elsa.EntityFrameworkCore.Extensions;
using Elsa.EntityFrameworkCore.Modules.Management;
using Elsa.EntityFrameworkCore.Modules.Runtime;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workflow.Data;
using Workflow.Services;
using Workflow.Workflow.AppraisalWorkflow;


namespace Workflow;

public static class WorkflowModule
{
    public static IServiceCollection AddWorkflowModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IWorkflowService, WorkflowService>();

        services.AddElsa(elsa =>
        {
            elsa.UseWorkflowManagement(management => management.UseEntityFrameworkCore(ef =>
                ef.UseSqlServer(configuration.GetConnectionString("Database") ??
                                throw new InvalidOperationException("Database connection string is not configured.")))
            );

            elsa.UseWorkflowRuntime(runtime => runtime.UseEntityFrameworkCore(ef =>
                ef.UseSqlServer(configuration.GetConnectionString("Database") ??
                                throw new InvalidOperationException("Database connection string is not configured."))));

            elsa.UseIdentity(identity =>
            {
                identity.TokenOptions =
                    options => options.SigningKey =
                        "sufficiently-large-secret-signing-key"; // This key needs to be at least 256 bits long.
                identity.UseAdminUserProvider();
            });

            // Configure ASP.NET authentication/authorization.
            elsa.UseDefaultAuthentication(auth => auth.UseAdminApiKey());

            // Enable Elsa API endpoints for Studio integration
            //elsa.UseWorkflowsApi();

            // Enable JavaScript workflow expressions.
            elsa.UseJavaScript();

            // Enable C# workflow expressions.
            elsa.UseCSharp();

            // Enable Liquid workflow expressions.
            elsa.UseLiquid();

            // Enable HTTP activities.
            elsa.UseHttp();

            // elsa.UseMassTransit(massTransit =>
            // {
            //     massTransit.UseRabbitMq(rabbitMq =>
            //     {
            //         rabbitMq.ConfigureTransportBus = (context, configurator) =>
            //         {
            //             configurator.Host(new Uri(configuration["RabbitMQ:Host"]!), host =>
            //             {
            //                 host.Username(configuration["RabbitMQ:Username"]!);
            //                 host.Password(configuration["RabbitMQ:Password"]!);
            //                 
            //                 configurator.ConfigureEndpoints(context);
            //             });
            //         };
            //     });
            // });

            elsa.AddWorkflow<InternalAppraisalWorkflow>();
            //elsa.UseHttp(http => http.ConfigureHttpOptions = options => { options.BasePath = "/workflows"; });
        });

        return services;
    }

    public static IApplicationBuilder UseWorkflowModule(this IApplicationBuilder app)
    {
        //app.UseMigration<AppraisalSagaDbContext>();

        // Enable Elsa API endpoints for Studio integration
        //app.UseWorkflowsApi();

        // Use Elsa middleware to handle HTTP requests mapped to HTTP Endpoint activities
        app.UseWorkflows();

        return app;
    }
}