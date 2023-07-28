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
using MinecraftLaunch.Modules.Utils;

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
        GameCoreUtil util = new GameCoreUtil();
        var res = util.GetGameCores();
        
        if (!args.Any())
        {
            if (res.ToArray().Length == 0)
            {
                SLCore.Utils.SLOutput.Print("搜索结果为空，您貌似还没有安装任何一个版本", ConsoleColor.Green);
                return null;
            }
            
            foreach (var c in res)
                Console.WriteLine($"{c.Type}: {c.Id}");
        }
        else 
        {
            if (res.ToArray().Length == 0)
            {
                if (args.ToArray().Any() && args.ToArray()[0] == "--ava") ;
                else
                {
                    SLCore.Utils.SLOutput.Print("搜索结果为空，您貌似还没有安装任何一个版本", ConsoleColor.Green);
                    return null;
                }
            }
            
            if (args.ToArray().Length > 2)
                throw CommandArgumentError.TooManyParameters;
            
            if (args.ToArray()[0] == "--release")
            {
                res.ToList().ForEach(x =>
                {
                    if (x.Type == "release")
                    {
                        Console.WriteLine($"{x.Type}: {x.Id}");
                    }
                });
            }
            else if (args.ToArray()[0] == "--snapshot")
            {
                res.ToList().ForEach(x =>
                {
                    if (x.Type == "snapshot")
                    {
                        Console.WriteLine($"{x.Type}: {x.Id}");
                    }
                });
            }
            else if (args.ToArray()[0] == "--old-alpha")
            {
                res.ToList().ForEach(x =>
                {
                    if (x.Type == "old_alpha")
                    {
                        Console.WriteLine($"{x.Type}: {x.Id}");
                    }
                });
            }
            else
            {
                if (args.ToArray()[0] == "--ava")
                {
                    var res_ava = (await GameCoreInstaller.GetGameCoresAsync()).Cores;

                    if (args.ToArray().Length == 1)
                    {
                        foreach (var c in res_ava)
                            Console.WriteLine($"{c.Type}: {c.Time} - {c.Id}");
                        return null;
                    }

                    if (args.ToArray()[1] == "--release")
                    {
                        res_ava.ToList().ForEach(x =>
                        {
                            if (x.Type == "release")
                            {
                                Console.WriteLine($"{x.Type}: {x.Time} - {x.Id}");
                            }
                        });
                    }
                    else if (args.ToArray()[1] == "--snapshot")
                    {
                        res_ava.ToList().ForEach(x =>
                        {
                            if (x.Type == "snapshot")
                            {
                                Console.WriteLine($"{x.Type}: {x.Time} - {x.Id}");
                            }
                        });
                    }
                    else if (args.ToArray()[1] == "--old-alpha")
                    {
                        res_ava.ToList().ForEach(x =>
                        {
                            if (x.Type == "old_alpha")
                            {
                                Console.WriteLine($"{x.Type}: {x.Time} - {x.Id}");
                            }
                        });
                    }
                    else
                        throw CommandArgumentError.WrongParameter;
                }
                else if (args.ToArray()[0] == "--local")
                {
                    if (res.ToArray().Length == 0)
                    {
                        SLCore.Utils.SLOutput.Print("搜索结果为空，您貌似还没有安装任何一个版本", ConsoleColor.Green);
                        return null;
                    }
                    
                    if (args.ToArray().Length == 1)
                    {
                        foreach (var c in res)
                            Console.WriteLine($"{c.Type}: {c.Id}");
                        return null;
                    }
                    
                    
                    if (args.ToArray()[1] == "--release")
                    {
                        res.ToList().ForEach(x =>
                        {
                            if (x.Type == "release")
                            {
                                Console.WriteLine($"{x.Type}: {x.Id}");
                            }
                        });
                    }
                    else if (args.ToArray()[1] == "--snapshot")
                    {
                        res.ToList().ForEach(x =>
                        {
                            if (x.Type == "snapshot")
                            {
                                Console.WriteLine($"{x.Type}: {x.Id}");
                            }
                        });
                    }
                    else if (args.ToArray()[1] == "--old-alpha")
                    {
                        res.ToList().ForEach(x =>
                        {
                            if (x.Type == "old_alpha")
                            {
                                Console.WriteLine($"{x.Type}: {x.Id}");
                            }
                        });
                    }
                    else
                        throw CommandArgumentError.WrongParameter;
                }
            }
        }

        return null;
    }
}
