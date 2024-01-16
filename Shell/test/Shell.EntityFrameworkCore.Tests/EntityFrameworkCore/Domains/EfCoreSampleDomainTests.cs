using Shell.Samples;
using Xunit;

namespace Shell.EntityFrameworkCore.Domains;

[Collection(ShellTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ShellEntityFrameworkCoreTestModule>
{

}
