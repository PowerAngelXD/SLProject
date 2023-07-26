using MinecraftLaunch.Modules.Installer;
using SLCore;
using SLCore.Commands;
using SLCore.Errors;
using SLCore.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLauncher.Commands.List;
internal sealed class ListCoreCommand : ISLCommand
{
    public string Id => "simplelauncher:list:core";

    public IEnumerable<string> Aliases { get; } = new string[] 
    {
        "core", "c", "Core"
    };

    public string HelpContent => "";

    public async Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        SLOutput.Print("正在获取游戏核心列表，这可能会耗一些时间，请您耐心等待...\n", ConsoleColor.Yellow);

        var res = (await GameCoreInstaller.GetGameCoresAsync()).Cores;
        
        if (!args.Any())
        {
            Console.WriteLine("游戏核心搜索已完成，已获取核心列表: ");

            foreach (var c in res)
                Console.WriteLine($"{c.Type}: {c.Time} {c.Id}");
        }
        else
        {
            if (args.ToArray().Length > 1)
                throw CommandArgumentError.TooManyParameters;
            
            if (args.ToArray()[0] == "--release")
            {
                Console.WriteLine($"游戏核心搜索已完成，已获取核心列表(您指定了筛选器: {args.ToArray()[0]}): ");
                
                res.ToList().ForEach(x =>
                {
                    if (x.Type == "release")
                    {
                        Console.WriteLine($"{x.Type}: {x.Time} {x.Id}");
                    }
                });
            }
            else if (args.ToArray()[0] == "--snapshot")
            {
                Console.WriteLine($"游戏核心搜索已完成，已获取核心列表(您指定了筛选器: {args.ToArray()[0]}): ");
                
                res.ToList().ForEach(x =>
                {
                    if (x.Type == "snapshot")
                    {
                        Console.WriteLine($"{x.Type}: {x.Time} {x.Id}");
                    }
                });
            }
            else if (args.ToArray()[0] == "--old-alpha")
            {
                Console.WriteLine($"游戏核心搜索已完成，已获取核心列表(您指定了筛选器: {args.ToArray()[0]}): ");

                res.ToList().ForEach(x =>
                {
                    if (x.Type == "old_alpha")
                    {
                        Console.WriteLine($"{x.Type}: {x.Time} {x.Id}");
                    }
                });
            }
            else
                throw CommandArgumentError.WrongParameter;
        }

        return null;
    }
}
