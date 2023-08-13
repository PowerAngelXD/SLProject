using System.Text.Json.Serialization;
using SLCore.Commands;

namespace SLCore.Config;

/// <summary>
/// 配置文件的段
/// </summary>
public interface IConfigSection
{
    [Newtonsoft.Json.JsonIgnore]
    public string ConfigId { get; }
    [Newtonsoft.Json.JsonIgnore]
    public string ConfigAliase { get; }
    /// <summary>
    /// 当启动器在Setup方法中检查配置中的字段是否合法时调用这个方法
    /// </summary>
    public void OnChecking();
}