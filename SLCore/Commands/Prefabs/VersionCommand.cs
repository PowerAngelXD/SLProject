using SLCore.Utils;

namespace SLCore.Commands.Prefabs;
internal sealed class VersionCommand : ISLCommand
{
    private readonly SimpleLauncherCore core;
    public VersionCommand(SimpleLauncherCore core)
    {
        this.core = core;
    }

    public string Id { get; } = "simplelauncher:version";

    public IEnumerable<string> Aliases { get; } = new string[]
    {
        "version", "ver"
    };

    public string HelpContent => $"version | ver: 查看启动器及其核心版本{Environment.NewLine}";

    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        SLOutput.Print("当前核心版本: " + this.core.CoreInfo.CoreVersion, ConsoleColor.Green);
        SLOutput.Print("当前启动器版本: " + this.core.CoreInfo.LauncherVersion, ConsoleColor.Green);
        SLOutput.Print("程序使用许可证: " + this.core.CoreInfo.License, ConsoleColor.Cyan);
        return Task.FromResult<ISLCommand?>(null);
    }
}
