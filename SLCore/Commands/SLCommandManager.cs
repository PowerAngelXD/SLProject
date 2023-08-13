using System.Collections.ObjectModel;

namespace SLCore.Commands;

public sealed class SLCommandManager
{
    private readonly List<ISLCommand> commands;
    public IReadOnlyList<ISLCommand> Commands { get; }

    public SLCommandManager(SimpleLauncherCore core)
    {
        this.commands = new List<ISLCommand>();
        this.Commands = new ReadOnlyCollection<ISLCommand>(this.commands);
    }

    public void Register(ISLCommand command)
    {
        this.commands.Add(command);
    }

    public void Remove(ISLCommand command)
    {
        _ = this.commands.Remove(command);
    }

    private static async ValueTask ExecuteRecursivelyAsync(ISLCommand? command, IEnumerable<string> args)
    {
        for (; command is not null;)
        {
            command = await command.ExecuteAsync(args);
            args = args.Skip(1);
        }
    }
    
    /// <summary>
    /// 找到匹配的指令
    /// </summary>
    /// <param name="commandIdOrAlias">命令的ID或者是别名</param>
    /// <returns>如果找到了返回该命令实例，否则返回null</returns>
    public ISLCommand? FindExactlyMatched(string commandIdOrAlias)
    {
        ISLCommand? result = null;
        foreach (var command in this.commands)
        {
            if (command.Id == commandIdOrAlias)
                return command;

            if (command.Aliases.Contains(commandIdOrAlias))
            {
                result = command;
                continue;
            }
        }
        return result;
    }

    public ISLCommand? FindExactlyMatched(string[] targets)
    {
        ISLCommand? result = null;
        foreach (var target in targets)
        {
            foreach (var command in this.commands)
            {
                if (command.Id == target)
                    return command;

                if (command.Aliases.Contains(target))
                {
                    result = command;
                    continue;
                }
            }
        }
        return result;
    }
    
    /// <summary>
    /// 运行一条指令
    /// </summary>
    /// <param name="commandText">输入内容，或者传入的字符串供解析</param>
    public async ValueTask ExecuteAsync(string commandText)
    {
        string[] args = commandText.Split(
            new char[] { ' ', '\t' },
            StringSplitOptions.RemoveEmptyEntries);
        if (args.Length is 0)
            return;

        var command = this.FindExactlyMatched(args[0]);
        await ExecuteRecursivelyAsync(command, args.Skip(1));
    }
}
