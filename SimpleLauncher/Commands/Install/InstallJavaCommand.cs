using SLCore.Commands;

namespace SimpleLauncher.Commands.Install;

public class InstallJavaCommand: ISLCommand
{
    public string Id => "simplelauncher:install:java";

    public IEnumerable<string> Aliases { get; } = new string[3]
    {
        "java", "j", "Java"
    };

    public string HelpContent => "";
    
    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        
        return null;
    }
}