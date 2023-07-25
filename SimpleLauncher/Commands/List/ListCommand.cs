using SLCore.Commands;
using SLCore.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLauncher.Commands.List;
internal sealed class ListCommand : ISLCommand
{
    public string Id { get; } = "simplelauncher:list";

    public IEnumerable<string> Aliases { get; } = new string[] {
        "list", "ls", "List"
    };

    public string HelpContent =>
        $"list | ls | List: 查找Java环境或者游戏核心等其他东西{Environment.NewLine}" +
        $"  |子命令1: -java | -j | -Java: 列出本机所有的Java环境{Environment.NewLine}" +
        $"  |用法: list -java | list -j | list -Java{Environment.NewLine}" +
        $"  |{Environment.NewLine}" +
        $"  |子命令2: -core[=<filter>] | -c | -Core: 列出启动器路径下的\".minecraft\"文件夹中的所有核心 (筛选器语法在'-c' 与 '-Core'子命令中也相同){Environment.NewLine}" +
        $"  |用法: 需求举例: 只列举出所有release版本{Environment.NewLine}" +
        $"  |  | list -core=release{Environment.NewLine}" +
        $"  |{Environment.NewLine}" +
        $"  |注意事项: 该命令不可缺省子命令, 否则会报出错误{Environment.NewLine}" +
        $"  |  | 举例: 'list' 用法会报错误: '对于该命令输入了过少的参数...'; 而 'list -java' 不会{Environment.NewLine}" +
        $"  -{Environment.NewLine}";

    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        var next = args.FirstOrDefault();
        return Task.FromResult<ISLCommand?>(next switch
        {
            null => throw CommandArgumentError.MissingParameter,
            "-core" or "-c" or "-Core" => new ListCoreCommand(),
            "-java" or "-j" or "-Java" => new ListJavaCommand(),
            _ => throw CommandArgumentError.WrongParameter
        });
    }
}
