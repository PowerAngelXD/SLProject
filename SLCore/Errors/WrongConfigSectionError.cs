namespace SLCore.Errors;

public class WrongConfigSectionError: Exception, IError
{
    public WrongConfigSectionError(string content) : 
        base(content) { }
}