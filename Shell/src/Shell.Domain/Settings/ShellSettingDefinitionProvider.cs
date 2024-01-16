using Volo.Abp.Settings;

namespace Shell.Settings;

public class ShellSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ShellSettings.MySetting1));
    }
}
