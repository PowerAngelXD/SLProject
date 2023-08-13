namespace SLCore.Errors;

public class UnknownCommandError : Exception, IError
{
    public UnknownCommandError(string command)
        : base($"输入了未知的命令, 您的输入：{command}") { }
}