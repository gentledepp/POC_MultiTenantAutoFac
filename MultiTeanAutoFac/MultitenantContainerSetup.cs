using Autofac;
using Autofac.Multitenant;
using Microsoft.Extensions.Primitives;

public static class MultitenantContainerSetup
{
    public static MultitenantContainer ConfigureMultitenantContainer(IContainer container)
    {
        // Define how you're going to identify tenants.
        var strategy = new QueryStringTenantIdentificationStrategy(
            container.Resolve<IHttpContextAccessor>(),
            container.Resolve<ICurrentTenant>(),
            container.Resolve<ILogger<QueryStringTenantIdentificationStrategy>>());

        // Create the multitenant container.
        var multitenantContainer = new MultitenantContainer(strategy, container);

        // Register tenant overrides.
        multitenantContainer.ConfigureTenant(
            "Alex",
            cb => cb
                .RegisterType<OverriddenDependency>()
                .As<IDependency>()
                .WithProperty("Id", "Alex")
                .InstancePerLifetimeScope());

        // Return the built container for use in the app.
        return multitenantContainer;
    }
}

public class OverriddenDependency : IDependency
{
    public OverriddenDependency()
    {
        
    }
    
    public string Postfix()
    {
        return "[tenant container]";
    }
}

public class QueryStringTenantIdentificationStrategy : ITenantIdentificationStrategy
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ICurrentTenant _currentTenant;
    private readonly ILogger _logger;

    public QueryStringTenantIdentificationStrategy(IHttpContextAccessor contextAccessor, ICurrentTenant currentTenant, ILogger logger)
    {
        _contextAccessor = contextAccessor;
        _currentTenant = currentTenant;
        _logger = logger;
    }
    
    public bool TryIdentifyTenant(out object tenantId)
    {
        if (_contextAccessor.HttpContext is { } ctx)
        {
            tenantId = ctx.Request.Query.TryGetValue("tenantId", out var tid) ? tid.ToString() : null;
            _currentTenant.TenantId = tenantId;
        }
        else
            tenantId = null;

        
        return true;
    }
}

public class CurrentTenant : ICurrentTenant
{
    private AsyncLocal<object> _currentTenant = new AsyncLocal<object>();

    public object TenantId
    {
        get
        {
            return _currentTenant.Value;
        }
        set
        {
            _currentTenant.Value = value;
        }
    }
}

public interface ICurrentTenant
{
    object TenantId { get; set; }
}