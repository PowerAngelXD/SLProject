using MinecraftLaunch.Modules.Installer;
using MinecraftLaunch.Modules.Models.Download;
using SimpleLauncher.Commands.Install.Util;
using SLCore.Commands;
using SLCore.Errors;

namespace SimpleLauncher.Commands.Install;

public class InstallCoreCommand: ISLCommand
{
    public string Id => "simplelauncher:install:core";

    public IEnumerable<string> Aliases { get; } = new string[3] 
    {
        "core", "c", "Core"
    };

    public string HelpContent => "";
    public async Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        var newArgs = args.ToArray();
        
        if (newArgs.Length > 2) 
            throw CommandArgumentError.TooManyParameters;
        else if (newArgs.Length < 2)
            throw CommandArgumentError.MissingParameter;
        
        if (newArgs[0] != "--filter")
            throw CommandArgumentError.WrongParameter;
        
        
        Console.WriteLine("正在解析您的筛选器...");
        
        var source = newArgs[1];
        CoreFilterReader reader = new CoreFilterReader(source);
        reader.GenerateTokenGroup();
        CoreFilterExprParser parser = new CoreFilterExprParser(reader);
        parser.ProduceResult();

        APIManager.Current = APIManager.Bmcl;
        
        Console.WriteLine("解析成功，正在通过您指定的正确的筛选器开始为您下载");
        if (parser.Result.RequireTypes == null)
        {
            GameCoreInstaller installer = new(SLauncher.LauncherCore.CoreToolKit, parser.Result.RequireVersion);
            installer.ProgressChanged += (_, x) =>
            {
                Console.WriteLine($"下载进度: {x.ProgressDescription}");
            };
            var result = await installer.InstallAsync();
            
            if (result.Success)
                SLCore.Utils.SLOutput.Print($"下载 {parser.Result.RequireVersion} 的任务已经完成！", ConsoleColor.Green);
        }
        else
        {
            // TODO
        }
        
        return null;
    }
}