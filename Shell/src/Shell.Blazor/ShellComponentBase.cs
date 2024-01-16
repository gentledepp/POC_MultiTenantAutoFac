using Shell.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Shell.Blazor;

public abstract class ShellComponentBase : AbpComponentBase
{
    protected ShellComponentBase()
    {
        LocalizationResource = typeof(ShellResource);
    }
}
