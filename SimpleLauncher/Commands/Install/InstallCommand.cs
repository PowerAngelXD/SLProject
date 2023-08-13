using SLCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLCore.Errors;

namespace SimpleLauncher.Commands.Install;
internal sealed class InstallCommand : ISLCommand
{
    public string Id => "simplelauncher:install";

    public IEnumerable<string> Aliases { get; } = new string[] 
    {
        "install", "i", "Install"
    };

    public string HelpContent =>
        $"install | i | Install: 下载指定的资源 (目前仅限于: 原版核心，Forge，Fabric，Quilt，Java，Optifine){Environment.NewLine}" +
        $"  |子命令1: java [--<version>] | j | Java: 下载指定的java (筛选器语法在'j' 与 'Java'子命令中也相同){Environment.NewLine}" +
        $"  |用法: 需求举例: 下载jdk17: {Environment.NewLine}" +
        $"  |  | install java --jdk17{Environment.NewLine}" +
        $"  |  | 注意事项: 如果所给筛选器指向不正确或者语法错误，SimpleLauncher会对您错误的操作报出错误{Environment.NewLine}" +
        $"  |  -{Environment.NewLine}" +
        $"  |子命令1 -- 附录: 筛选器语法: {Environment.NewLine}" +
        $"  | <version> 可选项: jdk8, jdk11, jdk17, jdk18{Environment.NewLine}" +
        $"  |{Environment.NewLine}" +
        $"  |子命令2: core [--filter <coreID>+<modifier>*] | c | Core: 下载根据筛选器修饰的版本，并按照筛选器对其进行配置 (筛选器语法在'c' 与 'Core'子命令中也相同){Environment.NewLine}" +
        $"  |用法: 需求举例1: 下载一个1.18.2的核心并使用Fabric安装器: {Environment.NewLine}" +
        $"  |  | install core --filter 1.18.2+fabric{Environment.NewLine}" +
        $"  | 需求举例2: 下载一个1.7.10的核心并使用Forge安装器，同时搭配Optifine: {Environment.NewLine}" +
        $"  |  | install core --filter 1.7.10+forge+optifine{Environment.NewLine}" +
        $"  -";

    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        var next = args.FirstOrDefault();

        return Task.FromResult<ISLCommand?>(next switch
        {
            null => throw CommandArgumentError.MissingParameter,
            "core" or "c" or "Core" => new InstallCoreCommand(),
            "java" or "j" or "Java" => new InstallJavaCommand(),
            _ => throw CommandArgumentError.WrongParameter
        });
    }
}
