using SLCore.Utils;

namespace SLCore.Commands.Prefabs;
internal sealed class ExitCommand : ISLCommand
{
    private readonly ILauncher launcher;
    public ExitCommand(ILauncher launcher)
    {
        this.launcher = launcher;
    }

    public string Id { get; } = "simplelauncher:exit";

    public IEnumerable<string> Aliases { get; } = new string[]
    {
        "exit", "quit", "q"
    };

    public string HelpContent => $"exit | quit | q: 退出启动器{Environment.NewLine}";

    public Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args)
    {
        SLOutput.Print("正在退出程序...");
        this.launcher.RequestClose();
        return Task.FromResult<ISLCommand?>(null);
    }
}
