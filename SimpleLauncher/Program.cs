using SLCore.Command;
using System.Collections;
using MinecraftLaunch.Modules.Interface;
using MinecraftLaunch.Modules.Toolkits;
using SimpleLauncher.Commands;
using SLCore;
using Terminal.Gui;
using SLCore.Utils;
using Color = System.Drawing.Color;
using Console = Colorful.Console;

public class Program
{
    private static void RunConsole()
    {
        string? input = new string("");
        
        string start = "欢迎使用SimpleLauncher\n" +
                       "不了解命令？您可以输入 'help' 来查看命令帮助文档\n" +
                       "如果您要退出，您可以输入 'q'\n" +
                       "当前启动器核心版本: " + SLCore.CoreInfo.Info.CoreVersion + "\n" +
                       "    启动器本体版本: " + SLCore.CoreInfo.Info.LauncherVersion + "\n";
        
        Console.WriteLine(start);
        
        while (true)
        {
            try
            {
                SLCore.Utils.SLOutput.Prompt();
                input = System.Console.In.ReadLine();

                Console.Out.WriteLine();

                if (input == null) continue;

                
            }
            catch (SLCore.Errors.CommandArgumentError e)
            {
                SLOutput.Print("初始化程序或完成指令输入后出现了错误", ConsoleColor.Yellow);
                SLOutput.Print(e.Message, ConsoleColor.Red);
            }
            catch (SLCore.Errors.UnknownCommandError e)
            {
                SLOutput.Print("初始化程序或完成指令输入后出现了错误", ConsoleColor.Yellow);
                SLOutput.Print(e.Message, ConsoleColor.Red);
            }
            finally
            {
                Console.Out.WriteLine();
            }
        }
    }
    
    static int Main(string[] args)
    {
        Core.InitCore();

        // Register
        SLRegister.register(SLCommands.CMD_LIST);
        SLRegister.register(SLCommands.CMD_INSTALL);

        if (args.Length == 0)
        {
            RunConsole();
        }
        else
        {
            CommandHandler.HandCommand(args);
        }

        return 0;
    }
}