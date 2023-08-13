using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SLCore.Config.ConfigPrefabs;
using SLCore.Errors;

namespace SLCore.Config;

public class ConfigManager
{
    private List<IConfigSection> _configs;

    public ConfigManager()
    {
        _configs = new List<IConfigSection>();

        Register(new JavaPathConfig());
        
        if (!Directory.Exists(@"./.sl_settings"))
            Directory.CreateDirectory(@"./.sl_settings");
        if (!File.Exists(@"./.sl_settings/config.json"))
        {
            JObject obj = new JObject();

            foreach (var config in _configs)
            {
                obj[config.ConfigId] = JsonConvert.SerializeObject(config);
            }

            FileStream file = new FileStream(@"./.sl_settings/config.json", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(obj.ToString());
            writer.Close();
            file.Close();
        }
    }

    public void Register(IConfigSection config)
    {
        if (_configs.Contains(config))
            throw new MultiConfigSectionError(config.ConfigId);
        
        _configs?.Add(config);
    }

    public IConfigSection GetConfig(string idOrAliase)
    {
        foreach (var config in _configs)
        {
            if (config.ConfigAliase == idOrAliase || config.ConfigId == idOrAliase)
                return config;
        }

        throw new WrongConfigSectionError($"指定了错误的配置段: {idOrAliase}; 这个问题也可能是您的拼写错误导致的，请您检查您的拼写");
    }

    public List<IConfigSection> GetConfigs() => _configs;
}