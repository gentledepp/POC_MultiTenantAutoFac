using Volo.Abp.Modularity;

namespace Shell;

public abstract class ShellApplicationTestBase<TStartupModule> : ShellTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
