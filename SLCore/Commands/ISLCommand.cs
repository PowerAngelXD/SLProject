namespace SLCore.Commands;

/// <summary>
/// SLCore的指令实例，用于实现自定义的指令及其功能
/// </summary>
public interface ISLCommand
{
    /// <summary>
    /// 命令ID，格式： namespace:id
    /// </summary>
    string Id { get; }
    /// <summary>
    /// 别名，一般用户通过别名输入
    /// </summary>
    IEnumerable<string> Aliases { get; }
    /// <summary>
    /// 帮助文档，所有命令的帮助文档会通过help输出
    /// </summary>
    string HelpContent { get; }
    /// <summary>
    /// 运行命令，这里是命令的运行方法
    /// </summary>
    /// <param name="args">命令参数</param>
    /// <returns>如果有子命令，则需要配置子命令筛选器并返回子命令，如果没有则返回null</returns>
    Task<ISLCommand?> ExecuteAsync(IEnumerable<string> args);
}