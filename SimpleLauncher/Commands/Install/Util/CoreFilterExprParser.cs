using MinecraftLaunch.Modules.Enum;
using MinecraftLaunch.Modules.Installer;

namespace SimpleLauncher.Commands.Install.Util;
public struct CoreFilterExprResult
{
    public string? RequireVersion;
    public List<ModLoaderType>? RequireTypes;

    public CoreFilterExprResult(string version, List<ModLoaderType> types)
    {
        RequireVersion = version;
        RequireTypes = types;
    }
}

public class CoreFilterExprParser
{
    public CoreFilterExprResult? Result;
    private readonly List<ICFEToken>? _tokens;

    /// <summary>
    /// 指向_tokens中当前的Token的量
    /// </summary>
    private int _pos = 0;

    public CoreFilterExprParser(CoreFilterReader reader)
    {
        _tokens = reader.GetTokens();
    }

    private ICFEToken Current() => _tokens[_pos];
    
    private ICFEToken Peek() => _tokens[_pos + 1];

    private ICFEToken Next() => _tokens[++_pos];

    private bool IsFabric() => Peek().Content == "fabric" || Peek().Content == "Fabric";
    private bool IsForge() => Peek().Content == "forge" || Peek().Content == "Forge";
    private bool IsOptifine() => Peek().Content == "optifine" || Peek().Content == "Optifine";
    private bool IsConnectOp() => Peek().Content == "+";

    private async Task<bool> IsVersionId()
    {
        var token = Current();
        var res_ava = (await GameCoreInstaller.GetGameCoresAsync()).Cores;
        
        foreach (var core in res_ava)
        {
            if (core.Id == token.Content)
                return true;
        }

        return false;
    }

    public void ProduceResult()
    {
        string versionId = String.Empty;
        List<ModLoaderType> types = new List<ModLoaderType>();
        
        for (int i = 0; i < _tokens?.Count; i++)
        {
            if (i == 0)
            {
                // 检查是否开头为版本号
                if (IsVersionId().Result)
                {
                    versionId = new String(_tokens[0].Content);
                }
                else
                    throw new HeadIsNotVersionException();
            }

            if (IsForge())
            {
                if (types.Contains(ModLoaderType.Forge))
                    throw new RepeatedInstallerException("Forge");
                
                types.Add(ModLoaderType.Forge);
            }
            else if (IsFabric())
            {
                if (types.Contains(ModLoaderType.Fabric))
                    throw new RepeatedInstallerException("Fabric");
                else if (types.Contains(ModLoaderType.Forge))
                    throw new ConflictingInstallersException("Fabric", "Forge");
                else if (types.Contains(ModLoaderType.OptiFine))
                    throw new ConflictingInstallersException("Fabric", "Optifine");
                
                types.Add(ModLoaderType.Fabric);
            }
            else if (IsOptifine())
            {
                if (types.Contains(ModLoaderType.OptiFine))
                    throw new RepeatedInstallerException("Optifine");
                else if (types.Contains(ModLoaderType.Fabric))
                    throw new ConflictingInstallersException("Optifine", "Fabric");
                
                types.Add(ModLoaderType.OptiFine);
            }
            else if (IsConnectOp()) continue;
        }

        Result = new CoreFilterExprResult(versionId, types);
    }
}