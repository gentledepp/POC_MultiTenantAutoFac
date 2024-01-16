using System.Threading.Tasks;

namespace Shell.Data;

public interface IShellDbSchemaMigrator
{
    Task MigrateAsync();
}
