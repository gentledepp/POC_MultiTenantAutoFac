using Volo.Abp.Modularity;

namespace Shell;

[DependsOn(
    typeof(ShellApplicationModule),
    typeof(ShellDomainTestModule)
)]
public class ShellApplicationTestModule : AbpModule
{

}
