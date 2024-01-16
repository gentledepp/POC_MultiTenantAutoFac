using Shell.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Shell.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ShellEntityFrameworkCoreModule),
    typeof(ShellApplicationContractsModule)
    )]
public class ShellDbMigratorModule : AbpModule
{
}
