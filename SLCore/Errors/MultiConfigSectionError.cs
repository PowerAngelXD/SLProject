namespace SLCore.Errors;

public class MultiConfigSectionError : Exception, IError
{
    public MultiConfigSectionError(string configId) : 
        base($"已经存在的配置段(或别名): {configId}, 但仍要注册一个与之相同的配置段; 或可能是因为别名重复") { }
}