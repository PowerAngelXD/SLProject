using SLCore.Utils;

namespace SLCore.Commands.Prefabs;
internal sealed class HelpCommand : ISLCommand
{
    private readonly SimpleLauncherCore core;
    public HelpCommand(SimpleLauncherCore core)
    {
        this.core = core;
    }

    public string Id { get; } = "simplelauncher:help";

    public IEnumerable<string> Aliases { get; } = new string[]
    {
        "help", "h", "hp"
    };

    public string HelpContent =>
        $"help: 查看SimpleLauncher的帮助{Environment.NewLine}" +
        $"  |子命令: 所有已经注册的命令均为该命令的子命令{Environment.NewLine}" +
        $"  |用法: help [sub command]{Environment.NewLine}" +
        $"  |注意事项: 在输入该命令的子命令时，不需要输入对应命令的参数，直接输入该命令即可{Environment.NewLine}" +
        $"  |  |{Environment.NewLine}" +
        $"  |  | 举例: 'help find' 就是查找关于命令find的帮助，不需要填写find的参数{Environment.NewLine}" +
        $"  -  -{Environment.NewLine}";

    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        if (args.Any())
        {
            var command = this.core.SlCommandManager.FindExactlyMatched(args.First());
            SLOutput.Print(command?.HelpContent);
        }
        else
        {
            SLOutput.Print(
                $"SimpleLauncher帮助文档{Environment.NewLine}" +
                $"本文档主要内容为启动器支持的所有命令的用法，以及一些其他的小技巧{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"{Environment.NewLine}");
            foreach (var command in this.core.SlCommandManager.Commands)
            {
                SLOutput.Print(command.HelpContent);
            }
        }
        return Task.FromResult<ISLCommand?>(null);
    }
}
