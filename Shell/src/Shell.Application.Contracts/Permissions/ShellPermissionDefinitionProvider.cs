using Shell.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Shell.Permissions;

public class ShellPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ShellPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ShellPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ShellResource>(name);
    }
}
