using MinecraftLaunch.Modules.Enum;
using MinecraftLaunch.Modules.Installer;
using SimpleLauncher.Exceptions;
using SLCore.Commands;
using SLCore.Errors;

namespace SimpleLauncher.Commands.Install;

public class InstallJavaCommand: ISLCommand
{
    public string Id => "simplelauncher:install:java";

    public IEnumerable<string> Aliases { get; } = new string[3]
    {
        "java", "j", "Java"
    };

    public string HelpContent => "";
    
    public async Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        if (!args.Any())
            throw CommandArgumentError.MissingParameter;
        
        var paras = args.ToArray()[0].Split('=');
        
        if (args.ToArray().Length > 1)
            throw CommandArgumentError.TooManyParameters;

        if (paras[0] == "--jdk8")
        {
            if (Directory.Exists(@".minecraft_env\jdk8"))
                throw new ExistDirectoryException(@".minecraft_env\jdk8");
            
            JavaInstaller installer = new JavaInstaller(JdkDownloadSource.JdkJavaNet, OpenJdkType.OpenJdk8, @".minecraft_env\jdk8");

            Console.WriteLine("已开始下载，请您等待一段时间...");
            installer.ProgressChanged += (_, x) => {
                Console.WriteLine(x.ProgressDescription);
            };
            var res = await installer.InstallAsync();

            if(res.Success)
                SLCore.Utils.SLOutput.Print($"下载到{res.JavaInfo.JavaPath}的任务成功！", ConsoleColor.Green);
            else
                SLCore.Utils.SLOutput.Print($"下载到{res.JavaInfo.JavaPath}的任务失败，请检查您的设置", ConsoleColor.Red);
        }
        else if (paras[0] == "--jdk11")
        {
            if (Directory.Exists(@".minecraft_env\jdk11"))
                throw new ExistDirectoryException(@".minecraft_env\jdk11");
            
            JavaInstaller installer = new JavaInstaller(JdkDownloadSource.JdkJavaNet, OpenJdkType.OpenJdk11, @".minecraft_env\jdk11");
            
            Console.WriteLine("已开始下载，请您等待一段时间...");
            var res = await installer.InstallAsync();

            if(res.Success)
                SLCore.Utils.SLOutput.Print($"下载到{res.JavaInfo.JavaPath}的任务成功！", ConsoleColor.Green);
            else
                SLCore.Utils.SLOutput.Print($"下载到{res.JavaInfo.JavaPath}的任务失败，请检查您的设置", ConsoleColor.Red);
        }
        else if (paras[0] == "--jdk17")
        {
            if (Directory.Exists(@".minecraft_env\jdk17"))
                throw new ExistDirectoryException(@".minecraft_env\jdk17");
            
            JavaInstaller installer = new JavaInstaller(JdkDownloadSource.JdkJavaNet, OpenJdkType.OpenJdk17, @".minecraft_env\jdk17");
            
            Console.WriteLine("已开始下载，请您等待一段时间...");
            var res = await installer.InstallAsync();

            if(res.Success)
                SLCore.Utils.SLOutput.Print($"下载到{res.JavaInfo.JavaPath}的任务成功！", ConsoleColor.Green);
            else
                SLCore.Utils.SLOutput.Print($"下载到{res.JavaInfo.JavaPath}的任务失败，请检查您的设置", ConsoleColor.Red);
        }
        else if (paras[0] == "--jdk18")
        {
            if (Directory.Exists(@".minecraft_env\jdk18"))
                throw new ExistDirectoryException(@".minecraft_env\jdk18");

            JavaInstaller installer = new JavaInstaller(JdkDownloadSource.JdkJavaNet, OpenJdkType.OpenJdk18,
                @".minecraft_env\jdk18");

            Console.WriteLine("已开始下载，请您等待一段时间...");
            var res = await installer.InstallAsync();

            if (res.Success)
                SLCore.Utils.SLOutput.Print($"下载到{res.JavaInfo.JavaPath}的任务成功！", ConsoleColor.Green);
            else
                SLCore.Utils.SLOutput.Print($"下载到{res.JavaInfo.JavaPath}的任务失败，请检查您的设置", ConsoleColor.Red);
        }
        else
            throw CommandArgumentError.WrongParameter;
        
        return null;
    }
}