using MinecraftLaunch.Modules.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SLCore.Errors;

namespace SLCore.Config.ConfigPrefabs;

public class JavaPathConfig: IConfigSection
{
    public string ConfigId => "simplelauncher:config:javaPath";
    public string ConfigAliase => "javaPath";
    public string javaPath => "null";
    public void OnChecking()
    {
        string rawContent = File.ReadAllText(@"./.sl_settings/config.json");
        
        JObject obj = JObject.Parse(rawContent);
        JObject checker = JsonConvert.DeserializeObject<JObject>(obj?[ConfigId]?.ToString());
        
        if (checker?[ConfigAliase]?.ToString() == "null")
        {
            Utils.SLOutput.Print("检测到您还未设置游戏运行环境，请您输入 'setting' 命令进行具体的设置", ConsoleColor.Yellow);
        }
    }
}