using SLCore.Commands;

namespace SimpleLauncher.Commands.Install;

public class InstallCoreCommand: ISLCommand
{
    public string Id => "simplelauncher:install:core";

    public IEnumerable<string> Aliases { get; } = new string[3] 
    {
        "core", "c", "Core"
    };

    public string HelpContent => "";
    
    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        
        
        return null;
    }
}