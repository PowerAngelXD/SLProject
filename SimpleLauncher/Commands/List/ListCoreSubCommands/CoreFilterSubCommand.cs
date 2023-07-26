using SLCore.Commands;

namespace SimpleLauncher.Commands.List.ListCoreSubCommands;

public class CoreFilterSubCommand: ISLCommand
{
    public string Id => "simplelauncher:list:core:filter";

    public IEnumerable<string> Aliases { get; } = new string[1] { "--filter" };
    
    public string HelpContent => "";
    
    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        throw new NotImplementedException();
    }
}