using ProjBobcat.Class.Helper;
using SLCore.Commands;
using SLCore.Errors;
using SLCore.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftLaunch.Modules.Utils;

namespace SimpleLauncher.Commands.List;
internal sealed class ListJavaCommand : ISLCommand
{
    public string Id => "simplelauncher:list:java";

    public IEnumerable<string> Aliases { get; } = new string[] 
    {
        "java", "j", "Java"
    };

    public string HelpContent => "";

    public async Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        if (args.Any())
            throw CommandArgumentError.TooManyParameters;

        var javas = JavaUtil.GetJavas();
        
        Console.WriteLine("已为您获取到您系统上的标准java环境:");
        
        foreach (var java in javas)
        {
            SLOutput.Print(java.JavaVersion + ": " + java.JavaPath);
        }

        return null;
    }
}
