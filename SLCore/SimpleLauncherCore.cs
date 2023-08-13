using MinecraftLaunch.Modules.Models.Launch;
using MinecraftLaunch.Modules.Utils;
using SLCore.Commands;
using SLCore.Commands.Prefabs;
using SLCore.Config;
using SLCore.CoreInfo;

namespace SLCore;

public sealed class SimpleLauncherCore : IDisposable
{
    public GameCoreUtil CoreToolKit { get; }
    public SLCommandManager SlCommandManager { get; }
    public SLCoreInfo CoreInfo { get; }
    public LaunchConfig LaunchConfig { get; set; }
    public ConfigManager ConfigManager { get; set; }

    public SimpleLauncherCore(ILauncher launcher)
    {
        this.CoreToolKit = new(".minecraft");
        this.LaunchConfig = new LaunchConfig();
        this.SlCommandManager = new SLCommandManager(this);
        this.ConfigManager = new ConfigManager();
        this.CoreInfo = new SLCoreInfo(launcher);

        this.SlCommandManager.Register(new HelpCommand(this));
        this.SlCommandManager.Register(new VersionCommand(this));
        this.SlCommandManager.Register(new ExitCommand(launcher));
    }

    public void Dispose()
    {
        // TODO: 需要把插件 Dispose 了
    }
}