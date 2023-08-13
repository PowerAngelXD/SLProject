using System.Collections;
using SimpleLauncher.Commands;
using SLCore;
using SLCore.Utils;
using Color = System.Drawing.Color;
using Console = Colorful.Console;
using System.Linq;
using ShellProgressBar;
using SLCore.Errors;
using SimpleLauncher.Commands.List;
using SimpleLauncher.Commands.Install;

namespace SimpleLauncher;

public sealed class SLauncher : ILauncher
{
    public static SimpleLauncherCore LauncherCore;
    public SLauncher()
    {
        LauncherCore = new SimpleLauncherCore(this);
        Setup();

        // 在此处注册启动器的命令
        LauncherCore.SlCommandManager.Register(new ListCommand());
        LauncherCore.SlCommandManager.Register(new InstallCommand());
    }

    private void Setup()
    {
        if (!Directory.Exists(".minecraft"))
            Directory.CreateDirectory(".minecraft");
        if (!Directory.Exists(".minecraft_env"))
            Directory.CreateDirectory(".minecraft_env");
        
        // 检测配置工作
        foreach (var config in LauncherCore.ConfigManager.GetConfigs())
        {
            config.OnChecking();
        }
    }

    public async ValueTask RunAsync(string[] args)
    {
        if (args.Length == 0)
        {
            await this.RunConsole();
        }
        else
        {
            var stringArgs = string.Join(' ', args);
            await LauncherCore.SlCommandManager.ExecuteAsync(stringArgs);
        }
    }

    public string LauncherVersion => "ALPHA 0.1";

    private bool closeRequired = false;

    public void RequestClose()
    {
        this.closeRequired = true;
    }

    private async ValueTask RunConsole()
    {
        Console.WriteLine(
            $"欢迎使用SimpleLauncher{Environment.NewLine}" +
            $"不了解命令？您可以输入 'help' 来查看命令帮助文档{Environment.NewLine}" +
            $"如果您要退出，您可以输入 'q'{Environment.NewLine}" +
            $"当前启动器核心版本: {LauncherCore.CoreInfo.CoreVersion}{Environment.NewLine}" +
            $"    启动器本体版本: {this.LauncherVersion}{Environment.NewLine}");
        
        while (!closeRequired)
        {
            try
            {
                Console.Write("launcher >> ");
                var input = Console.ReadLine();
                Console.Out.WriteLine();

                if (string.IsNullOrEmpty(input))
                    continue;

                await LauncherCore.SlCommandManager.ExecuteAsync(input);
            }
            catch (Exception ex) when (ex is IError error)
            {
                SLOutput.Print("初始化程序或完成指令输入后出现了错误", ConsoleColor.Yellow);
                SLOutput.Print(error.Message, ConsoleColor.Red);
            }
            finally
            {
                SLOutput.Print("");
            }
        }
    }
}