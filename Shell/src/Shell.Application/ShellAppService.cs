using System;
using System.Collections.Generic;
using System.Text;
using Shell.Localization;
using Volo.Abp.Application.Services;

namespace Shell;

/* Inherit your application services from this class.
 */
public abstract class ShellAppService : ApplicationService
{
    protected ShellAppService()
    {
        LocalizationResource = typeof(ShellResource);
    }
}
