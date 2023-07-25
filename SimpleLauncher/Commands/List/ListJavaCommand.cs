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

namespace SimpleLauncher.Commands.List;
internal sealed class ListJavaCommand : ISLCommand
{
    public string Id => "";

    public IEnumerable<string> Aliases { get; } = new string[] {
        "-java", "-j", "-Java"
    };

    public string HelpContent => "";

    public async Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        if (args.Any())
            throw CommandArgumentError.TooManyParameters;

        var javas = SystemInfoHelper.FindJava(true);
        SLOutput.Print(
            $"正在深度搜索您系统内的所有java环境，这会需要一些时间，请您耐心等待.{Environment.NewLine}" +
            $"Tips: 搜索时间取决于您的系统的java个数，如果java过多会导致等待时间过长，届时您可以干点其他的事情",
            ConsoleColor.Yellow);

        await foreach (var java in javas)
        {
            SLOutput.Print(java);
        }

        return null;
    }
}
