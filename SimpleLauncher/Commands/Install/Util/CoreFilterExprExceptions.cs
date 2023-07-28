using SLCore.Errors;

namespace SimpleLauncher.Commands.Install.Util;

public class UnknownIcfeTokenException : Exception, IError
{
    public UnknownIcfeTokenException(): 
        base("位于命令：install core --filter <filter>, 即<filter>处有未知的Token，请查阅帮助手册以检查是否有错误的输入") {}
}