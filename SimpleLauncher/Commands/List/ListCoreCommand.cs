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
    public string Id => "";

    public IEnumerable<string> Aliases { get; } = new string[] {
        "-core", "-c", "-Core"
    };

    public string HelpContent => "";

    public async Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        if (args.Any())
            throw CommandArgumentError.TooManyParameters;

        SLOutput.Print("正在获取游戏核心列表，这可能会耗一些时间，请您耐心等待...\n", ConsoleColor.Yellow);

        var res = (await GameCoreInstaller.GetGameCoresAsync()).Cores;

        Console.WriteLine("游戏核心搜索已完成，已获取核心列表: ");

        foreach (var c in res)
            Console.WriteLine($"{c.Type}: {c.Time} {c.Id}");

        return null;
    }
}
