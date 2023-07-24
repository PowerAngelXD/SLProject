using System.Diagnostics;
using SLCore.Command;
using SLCore.Command;

namespace SimpleLauncher.Commands;

public class SLCommands
{
    public static CommandInstance CMD_LIST = new CommandInstance(
        new string[3] { "list", "ls", "List" },
        "list | ls | List: 查找Java环境或者游戏核心等其他东西\n" +
        "  |子命令1: -java | -j | -Java: 列出本机所有的Java环境\n" +
        "  |用法: list -java | list -j | list -Java\n" +
        "  |\n" +
        "  |子命令2: -core | -c | -Core: 列出启动器路径下的\".minecraft\"文件夹中的所有核心\n" +
        "  |用法: list -core | list -c | list -Core\n" +
        "  |\n" +
        "  |注意事项: 该命令不可缺省子命令, 否则会报出错误\n" +
        "  |  | 举例: 'list' 用法会报错误: '对于该命令输入了过少的参数...'; 而 'list -java' 不会\n" +
        "  -\n",
        new CommandInstance[2]
        {
            new CommandInstance(
                new string[3] { "-java", "-j", "-Java" },
                "",
                null,
                new SLCore.Command.Action(ListSubAction.SUB_CMD_JAVA, ActionType.Full)
            ),
            new CommandInstance(
                new string[3] { "-core", "-c", "-Core" },
                "",
                null,
                new SLCore.Command.Action(null, ActionType.Full)
            )
        },
        new SLCore.Command.Action(null, ActionType.Seg)
    );

    public static CommandInstance CMD_INSTALL = new CommandInstance(
        new string[3] { "install", "i", "Install" },
        "install | i | Install: 下载指定的资源 (目前仅限于: 原版核心，Forge，Fabric，Quilt，Java，Optifine)\n" +
        "  |子命令1: -java[=<type>+<version>+<platform>(+kind)] | -j | -Java: 下载指定的java (筛选器语法在'-j' 与 '-Java'子命令中也相同)\n" +
        "  |用法: 需求举例: 下载jdk17, 目标平台为linux: \n" +
        "  |  | install -java=jdk+17+linux\n" +
        "  |  | 注意事项: 如果所给筛选器指向不正确或者语法错误，SimpleLauncher会对您错误的操作报出错误\n" +
        "  |  -\n" +
        "  |子命令1 -- 附录: 筛选器语法: \n" +
        "  | <type> 可选项: jdk, java\n" +
        "  | <version> 可选项: 所有已知的版本均可，注意不带小数点，均为正整数\n" +
        "  | <platform> 可选项: win, linux, mac\n" +
        "  | (kind) 可选项: installer, pkg\n" +
        "  |\n" +
        "  |子命令2: -core[=<coreID>+<modifier>*] | -c | -Core: 下载根据修饰器修饰的版本，并按照修饰器对其进行配置 (修饰器语法在'-c' 与 '-Core'子命令中也相同)\n" +
        "  |用法: 需求举例1: 下载一个1.18.2的核心并使用Fabric安装器: \n" +
        "  |  | install -core=1.18.2+fabric\n" +
        "  | 需求举例2: 下载一个1.7.10的核心并使用Forge安装器，同时搭配Optifine: \n" +
        "  |  | install -core=1.7.10+forge+optifine",
        new CommandInstance[1]
        {
            new CommandInstance(
                new string[3] { "game", "g", "Game" },
                "",
                null,
                new SLCore.Command.Action(null, ActionType.Full)
            ),
        },
        new SLCore.Command.Action(null, ActionType.Seg)
    );
}