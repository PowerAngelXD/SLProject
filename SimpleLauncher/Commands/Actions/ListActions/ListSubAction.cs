using ProjBobcat.Class.Helper;
using System.Collections;
using MinecraftLaunch.Modules.Installer;
using SLCore;
using SLCore.Errors;

public class ListSubAction
{
    public static async void SUB_CMD_JAVA(string[] args)
    {
        if (args.Length != 0)
            throw new CommandArgumentError(CommandArgumentErrorOptions.TooManyParametersError);

        var javas = SystemInfoHelper.FindJava(true);
        SLCore.Utils.SLOutput.Print("正在深度搜索您系统内的所有java环境，这会需要一些时间，请您耐心等待.\n" +
                                    "Tips: 搜索时间取决于您的系统的java个数，如果java过多会导致等待时间过长，届时您可以干点其他的事情或者运行其他的命令",
            ConsoleColor.Yellow);
        ArrayList content = new ArrayList();
        await foreach (var java in javas)
        {
            content.Add(java);
        }

        System.Console.Clear();

        Console.WriteLine("java搜索完成，所有java环境搜索结果如下:");

        foreach (var j in content)
        {
            Console.WriteLine((j as string));
        }

        Console.WriteLine();
        SLCore.Utils.SLOutput.Prompt();
    }

    public static async void SUB_CMD_CORE(string[] args)
    {
        if (args.Length != 0)
            throw new CommandArgumentError(CommandArgumentErrorOptions.TooManyParametersError);

        SLCore.Utils.SLOutput.Print("正在获取游戏核心列表，这可能会耗一些时间，请您耐心等待...\n", ConsoleColor.Yellow);

        ArrayList content = new ArrayList();
        
        if (Core.CoreToolKit == null)
        {
            throw new Exception("怎么不初始化coreToolKit啊傻逼");
            //TODO: throw custom error
        }

        GameCoreInstaller installer = new(Core.CoreToolKit, "1.12.2");
        var res = (await GameCoreInstaller.GetGameCoresAsync()).Cores;
        res.ToList().ForEach(x => { content.Add(x.Type + ": " + x.Time + " " + x.Id); });

        Console.WriteLine("游戏核心搜索已完成，已获取核心列表: ");

        foreach (var j in content)
        {
            Console.WriteLine((j as string));
        }
    }
}