using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Shell;

[Dependency(ReplaceServices = true)]
public class ShellBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Shell";
}
