using SLCore.Errors;

namespace SimpleLauncher.Commands.Install.Util;

public class UnknownIcfeTokenException : Exception, IError
{
    public UnknownIcfeTokenException(): 
        base("位于命令：install core --filter <filter>, 即<filter>处有未知的Token，请查阅帮助手册以检查是否有错误的输入") {}
}

public class HeadIsNotVersionException : Exception, IError
{
    public HeadIsNotVersionException(): 
        base("位于命令：install core --filter <filter>, 即<filter>处; 筛选器的开头必须为版本号，或者版本号不正确，未检索到该版本，请检查自己的输入并重试") {}
}

public class RepeatedInstallerException : Exception, IError
{
    public RepeatedInstallerException(string installer): 
        base($"位于命令：install core --filter <filter>, 即<filter>处; 重复的安装器指定: {installer}") {}
}

public class ConflictingInstallersException : Exception, IError
{
    public ConflictingInstallersException(string installer, string conflict): 
        base($"位于命令：install core --filter <filter>, 即<filter>处; 冲突的安装器指定: {installer} 与 {conflict}冲突") {}
}