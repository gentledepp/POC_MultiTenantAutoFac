using Volo.Abp.Modularity;

namespace Shell;

/* Inherit from this class for your domain layer tests. */
public abstract class ShellDomainTestBase<TStartupModule> : ShellTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
