namespace SLCore.Errors;

public class CommandArgumentError : Exception, IError
{
    public static CommandArgumentError TooManyParameters => new("对于该命令输入了过多的参数，请检查帮助手册并对该命令输入正确个数的参数。");
    public static CommandArgumentError WrongParameter => new("所输入的参数与该命令要求的不符，请查阅帮助列表以获取帮助。");
    public static CommandArgumentError MissingParameter => new("对于该命令输入了过少的参数，请检查帮助手册并对该命令输入正确个数的参数。");

    public CommandArgumentError(string details) : base(details) { }
}