using SLCore.Commands;
using SLCore.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace SimpleLauncher.Commands.List;
internal sealed class ListCommand : ISLCommand
{
    public string Id { get; } = "simplelauncher:list";

    public IEnumerable<string> Aliases { get; } = new string[] 
    {
        "list", "ls", "List"
    };

    public string HelpContent =>
        $"list | ls | List: 查找Java环境或者游戏核心等其他东西{Environment.NewLine}" +
        $"  |子命令1: java | j | Java: 列出本机所有的Java环境{Environment.NewLine}" +
        $"  |用法: list java | list j | list Java{Environment.NewLine}" +
        $"  |{Environment.NewLine}" +
        $"  |子命令2: core[--<type> --<search_kind>] | c | Core: 获得一个核心列表(本地或可下载) (筛选器语法在'c' 与 'Core'子命令中也相同){Environment.NewLine}" +
        $"  |用法: 需求举例1: 只列举出所有可下载的release版本{Environment.NewLine}" +
        $"  |  | list core --release{Environment.NewLine}" +
        $"  |需求举例2: 只列举出所有本地的snapshot版本{Environment.NewLine}" +
        $"  |  | list core --local --snapshot{Environment.NewLine}" +
        $"  |注意事项: 子命令参数 '--<type>' 一定在子命令参数 '--<search_kind>' 之前，否则会发生错误. 如果不指定<type>则默认为本地搜索{Environment.NewLine}" +
        $"  |子命令2 -- 附录1: --<type>子命令参数的可选值: {Environment.NewLine}" +
        $"  |  | local: 指定目标为本地{Environment.NewLine}" +
        $"  |  | ava: 指定目标为可下载版本{Environment.NewLine}" +
        $"  |子命令2 -- 附录2: --<filter>子命令参数的可选值: {Environment.NewLine}" +
        $"  |  | release: 只列出发行版{Environment.NewLine}" +
        $"  |  | snapshot: 只列出快照版{Environment.NewLine}" +
        $"  |  | old-alpha: 只列出远古版{Environment.NewLine}" +
        $"  |{Environment.NewLine}" +
        $"  |{Environment.NewLine}" +
        $"  |注意事项: 该命令不可缺省子命令, 否则会报出错误{Environment.NewLine}" +
        $"  |  | 举例: 'list' 用法会报错误: '对于该命令输入了过少的参数...'; 而 'list java' 不会{Environment.NewLine}" +
        $"  -{Environment.NewLine}";

    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        var next = args.FirstOrDefault();
        
        return Task.FromResult<ISLCommand?>(next switch
        {
            null => throw CommandArgumentError.MissingParameter,
            "core" or "c" or "Core" => new ListCoreCommand(),
            "java" or "j" or "Java" => new ListJavaCommand(),
            _ => throw CommandArgumentError.WrongParameter
        });
    }
}
