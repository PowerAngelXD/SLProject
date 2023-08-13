using SimpleLauncher.Commands.Install;
using SLCore.Commands;
using SLCore.Errors;

namespace SimpleLauncher.Commands.Setting;

public class SettingCommand : ISLCommand
{
    public string Id => "simplelauncher:setting";

    public IEnumerable<string> Aliases { get; } = new string[]
    {
        "setting", "st", "Setting"
    };

    public string HelpContent =>
        $"setting | st | Setting: 编辑，查看启动器设置{Environment.NewLine}" +
        $"  |子命令1: setting [--list] | st | Setting: 列出所有配置项 (子命令\"--list\"在其他命令形式中通用){Environment.NewLine}" +
        $"  |子命令2: setting [--edit <index> <content>] | st | Setting: 编辑对应索引的配置项(索引可以通过子命令\"--list\"查看){Environment.NewLine}" +
        $"  -{Environment.NewLine}";
    
    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        var newArgs = args.ToArray();
        string settingList = $"设置列表:{Environment.NewLine}" +
                             $"[0] javaPth: 游戏启动的java环境(指定到bin目录){Environment.NewLine}";

        if (newArgs[0] == "--list")
        {
            Console.WriteLine(settingList);
        }
        else if (newArgs[0] == "--edit")
        {
            if (newArgs.Length < 3)
                throw CommandArgumentError.MissingParameter;
            else if (newArgs.Length > 3)
                throw CommandArgumentError.TooManyParameters;

            switch (newArgs[1])
            {
                case "0":
                {
                    var content = newArgs[2];
                    
                    break;
                }
                    
                default: break;
            }
        }

        return null;
    }
}