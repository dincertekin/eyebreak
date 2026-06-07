using Microsoft.Win32;

namespace eyebreak;

internal static class StartupManager
{
    private const string RunKeyPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
    private const string AppName = "eyebreak";

    public static void SetEnabled(bool enabled)
    {
        using RegistryKey? key = Registry.CurrentUser.OpenSubKey(RunKeyPath, writable: true);
        if (key == null)
        {
            return;
        }

        if (enabled)
        {
            key.SetValue(AppName, Application.ExecutablePath);
        }
        else if (key.GetValue(AppName) != null)
        {
            key.DeleteValue(AppName, throwOnMissingValue: false);
        }
    }
}
