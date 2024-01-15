var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacMultitenantServiceProviderFactory(MultitenantContainerSetup.ConfigureMultitenantContainer));

builder.Services.AddSingleton<ICurrentTenant, CurrentTenant>();
builder.Services
    .AddAutofacMultitenantRequestServices()
    .AddControllers();


// Register tenant-shared dependencies and defaults.
builder.Services.AddScoped<IDependency, CommonDependency>();

var app = builder.Build();

app.UseRouting();

app.MapGet("/", (ICurrentTenant currentTenant, IDependency dependency) => $"Hello World, '{currentTenant.TenantId}'! {dependency.Postfix()}");

app.UseEndpoints(builder => {});

app.Run();