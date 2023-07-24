using ProjBobcat.Class.Helper;
using System.Collections;

public class ListSubAction
{
    public static async void SUB_CMD_JAVA(string[] subs)
    {
        var javas = SystemInfoHelper.FindJava(true);
        SLCore.Utils.SLOutput.Print("正在深度搜索您系统内的所有java环境，这会需要一些时间，请您耐心等待.\n" +
                                    "Tips: 搜索时间取决于您的系统的java个数，如果java过多会导致等待时间过长，届时您可以干点其他的事情或者运行其他的命令", ConsoleColor.Yellow);
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
}