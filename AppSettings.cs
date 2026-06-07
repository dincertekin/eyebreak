using System.Text.Json;

namespace eyebreak;

public sealed class AppSettings
{
    public bool ShortBreakEnabled { get; set; } = true;
    public bool LongBreakEnabled { get; set; } = true;
    public int ShortBreakIntervalMinutes { get; set; } = BreakDefaults.ShortBreakIntervalMinutes;
    public int LongBreakIntervalMinutes { get; set; } = BreakDefaults.LongBreakIntervalMinutes;
    public bool RunAtStartup { get; set; } = true;
    public bool SoundEnabled { get; set; } = true;

    public static string DefaultFilePath { get; } = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "eyebreak", "settings.json");

    public static AppSettings Load(string? filePath = null)
    {
        filePath ??= DefaultFilePath;

        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                AppSettings? settings = JsonSerializer.Deserialize<AppSettings>(json);
                if (settings != null)
                {
                    return settings;
                }
            }
        }
        catch (Exception)
        {
            // A missing or corrupt settings file falls back to defaults rather than crashing the app.
        }

        return new AppSettings();
    }

    public void Save(string? filePath = null)
    {
        filePath ??= DefaultFilePath;

        string? directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
