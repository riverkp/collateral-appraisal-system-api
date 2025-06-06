// Removed: using Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

// Common services: carter, mediatR, fluentvalidators, etc.
var requestAssembly = typeof(RequestModule).Assembly;
// Removed: var authAssembly = typeof(AuthModule).Assembly;

builder.Services.AddCarterWithAssemblies(requestAssembly /*, authAssembly */);
builder.Services.AddMediatRWithAssemblies(requestAssembly /*, authAssembly */);

builder.Services.AddControllers();
builder.Services.AddRazorPages();
//.AddApplicationPart(typeof(Test).Assembly)
//.AddRazorPagesOptions(options => { options.Conventions.AddPageRoute("/test", "/test"); });


builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddMassTransitWithAssemblies(builder.Configuration, requestAssembly /*, authAssembly */);

//builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration);
// builder.Services.AddAuthorization();

// Module services: request, etc.
builder.Services
    .AddRequestModule(builder.Configuration);
// Removed: .AddAuthModule(builder.Configuration);

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
// Removed: app.UseAuthentication();
// Removed: app.UseAuthorization();
//app.MapControllers();
app.MapRazorPages();
app.MapCarter();

app.UseSerilogRequestLogging();
app.UseExceptionHandler(options => { });

app
    .UseRequestModule();
    // .UseAuthModule();

app.Run();