using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Shell.Data;

/* This is used if database provider does't define
 * IShellDbSchemaMigrator implementation.
 */
public class NullShellDbSchemaMigrator : IShellDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
