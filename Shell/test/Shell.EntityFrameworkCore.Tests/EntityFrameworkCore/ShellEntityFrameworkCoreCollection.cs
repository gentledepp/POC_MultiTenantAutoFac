using Xunit;

namespace Shell.EntityFrameworkCore;

[CollectionDefinition(ShellTestConsts.CollectionDefinitionName)]
public class ShellEntityFrameworkCoreCollection : ICollectionFixture<ShellEntityFrameworkCoreFixture>
{

}
