using Shell.Samples;
using Xunit;

namespace Shell.EntityFrameworkCore.Applications;

[Collection(ShellTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ShellEntityFrameworkCoreTestModule>
{

}
