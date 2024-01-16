var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacMultitenantServiceProviderFactory(MultitenantContainerSetup.ConfigureMultitenantContainer));

IApplicationBuilder appBuilder = null;

builder.Services.AddSingleton<IApplicationBuilder>((sp) => appBuilder);
builder.Services.AddSingleton<ICurrentTenant, CurrentTenant>();
builder.Services
    .AddAutofacMultitenantRequestServices()
    .AddControllers();

builder.Services.AddScoped<EndpointMiddleware>();
// Register tenant-shared dependencies and defaults.
builder.Services.AddScoped<IDependency, CommonDependency>();


var app = builder.Build();
appBuilder = app;

app.UseRouting();

app.MapGet("/", (ICurrentTenant currentTenant, IDependency dependency) => $"Hello World, '{currentTenant.TenantId}'! {dependency.Postfix()}");

// app.UseEndpoints(builder => {});

app.UseMiddleware<EndpointMiddleware>();
app.UseEndpoints(builder => {});

app.Run();


public class EndpointMiddleware : IMiddleware
{
    private readonly IEnumerable<IConfigureEndpoints> _endpointConfigurators;
    private readonly IApplicationBuilder _builder;

    public EndpointMiddleware(IEnumerable<IConfigureEndpoints> endpointConfigurators, IApplicationBuilder builder)
    {
        _endpointConfigurators = endpointConfigurators;
        _builder = builder;
    }
    
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (_endpointConfigurators.Any())
        {
            var builder = _builder.New();

            var pipeline = builder.UseRouting()
                .UseEndpoints(endpoints =>
            {
                foreach (var ec in _endpointConfigurators)
                {
                    ec.Configure(endpoints, endpoints.ServiceProvider);
                }
            })
            .Build();

            return pipeline(context);
        }

        return next(context);
    }
}