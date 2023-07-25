using SLCore.Commands;

namespace SimpleLauncher.Commands;

public class ListCommand : ISLCommand
{
    private readonly SLCore.SimpleLauncherCore slc;

    public ListCommand(SLCore.SimpleLauncherCore core)
    {
        this.slc = core;
    }

    public string Id { get; } = "simplelauncher:list";

    public IEnumerable<string> Aliases { get; } = new string[2]
    {
        "list", "ls"
    };

    public string HelpContent { get; } =
        "list | ls | List: 查找Java环境或者游戏核心等其他东西\n" +
        "  |子命令1: -java | -j | -Java: 列出本机所有的Java环境\n" +
        "  |用法: list -java | list -j | list -Java\n" +
        "  |\n" +
        "  |子命令2: -core[=<filter>] | -c | -Core: 列出启动器路径下的\".minecraft\"文件夹中的所有核心 (筛选器语法在'-c' 与 '-Core'子命令中也相同)\n" +
        "  |用法: 需求举例: 只列举出所有release版本\n" +
        "  |  | list -core=release\n" +
        "  |\n" +
        "  |注意事项: 该命令不可缺省子命令, 否则会报出错误\n" +
        "  |  | 举例: 'list' 用法会报错误: '对于该命令输入了过少的参数...'; 而 'list -java' 不会\n" +
        "  -\n";

    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        return new Task<ISLCommand?>(null);
    }
}