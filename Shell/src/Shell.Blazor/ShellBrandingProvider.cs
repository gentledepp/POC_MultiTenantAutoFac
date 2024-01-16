using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Shell.Blazor;

[Dependency(ReplaceServices = true)]
public class ShellBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Shell";
}
