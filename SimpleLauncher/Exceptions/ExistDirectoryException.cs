using System.Runtime.CompilerServices;
using SLCore.Errors;

namespace SimpleLauncher.Exceptions;

public class ExistDirectoryException: Exception, IError
{
    public ExistDirectoryException(string path)
        : base($"已存在的文件夹: {path}, 请调整后重试") {}
}