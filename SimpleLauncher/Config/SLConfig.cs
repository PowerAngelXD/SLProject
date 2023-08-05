namespace SimpleLauncher.Config;

public struct SLConfig
{
    public FileInfo? JavaPath;

    public SLConfig(string path)
    {
        JavaPath = new FileInfo(path);
    }
}