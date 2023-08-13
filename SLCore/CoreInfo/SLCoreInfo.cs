namespace SLCore.CoreInfo;

public sealed class SLCoreInfo
{
    private readonly ILauncher launcher;
    internal SLCoreInfo(ILauncher launcher)
    {
        this.launcher = launcher;
    }
    public string CoreVersion => "RELEASE-2023722-0100";
    public string LauncherVersion => this.launcher.LauncherVersion;
    public string License => "MIT";
}