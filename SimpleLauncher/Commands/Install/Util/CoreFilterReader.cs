namespace SimpleLauncher.Commands.Install.Util;


public enum TokenType
{
    VersionId,   // 版本说明符
    Identifier,  // 标识符，比如fabric，forge这种
    ConnectOp,    // 连接符，特指 ‘+’
    End
}

/// <summary>
/// ICFE: Install-Core Filter Expression的缩写
/// </summary>
public class ICFEToken
{
    public string? Content { get; set; }
    public TokenType Type { get; set; }

    public ICFEToken(string content, TokenType type)
    {
        Content = content;
        Type = type;
    }
}

public class CoreFilterReader
{
    private List<ICFEToken>? _tokens;

    private string? _res;

    public CoreFilterReader(string resource)
    {
        _res = resource;
        _tokens = new List<ICFEToken>();
    }

    public void GenerateTokenGroup()
    {
        for (int i = 0; i < _res?.Length; i++)
        {
            var ch = _res[i];
            if (Char.IsDigit(ch))
            {
                // 生成VersionId的Token
                string content = new string(ReadOnlySpan<char>.Empty);
                
                while (ch != '+')
                {
                    content += ch;
                    i++;
                    ch = _res[i];
                }

                _tokens?.Add(new ICFEToken(content, TokenType.VersionId));
            }
            else if (Char.IsLetter(ch))
            {
                // 生成标识符的Token
                string content = new string(ReadOnlySpan<char>.Empty);

                while (Char.IsLetter(ch))
                {
                    content += ch;
                    i++;
                    ch = _res[i];
                }
                
                _tokens?.Add(new ICFEToken(content, TokenType.Identifier));
            }
            else if (ch == '+')
            {
                _tokens?.Add(new ICFEToken("+", TokenType.ConnectOp));
            }
            else if (ch == ' ') continue;
            else
                throw new UnknownIcfeTokenException();
        }
        _tokens?.Add(new ICFEToken("END", TokenType.End));
    }

    public List<ICFEToken>? GetTokens() => _tokens;
}