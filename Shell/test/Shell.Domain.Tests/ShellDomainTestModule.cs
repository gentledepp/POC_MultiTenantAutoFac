using Volo.Abp.Modularity;

namespace Shell;

[DependsOn(
    typeof(ShellDomainModule),
    typeof(ShellTestBaseModule)
)]
public class ShellDomainTestModule : AbpModule
{

}
