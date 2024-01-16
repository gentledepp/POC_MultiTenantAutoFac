using Shell.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Shell.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ShellController : AbpControllerBase
{
    protected ShellController()
    {
        LocalizationResource = typeof(ShellResource);
    }
}
