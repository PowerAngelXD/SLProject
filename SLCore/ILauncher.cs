namespace SLCore;
public interface ILauncher
{
    public string LauncherVersion { get; }

    public void RequestClose();
}
