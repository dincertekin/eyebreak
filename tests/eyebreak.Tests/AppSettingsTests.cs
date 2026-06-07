namespace eyebreak.Tests;

public class AppSettingsTests : IDisposable
{
    private readonly string _filePath;

    public AppSettingsTests()
    {
        _filePath = Path.Combine(Path.GetTempPath(), $"eyebreak-settings-{Guid.NewGuid():N}.json");
    }

    public void Dispose()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
        }
    }

    [Fact]
    public void Load_ReturnsDefaults_WhenFileDoesNotExist()
    {
        AppSettings settings = AppSettings.Load(_filePath);

        Assert.True(settings.ShortBreakEnabled);
        Assert.True(settings.LongBreakEnabled);
        Assert.True(settings.RunAtStartup);
        Assert.True(settings.SoundEnabled);
        Assert.Equal(BreakDefaults.ShortBreakIntervalMinutes, settings.ShortBreakIntervalMinutes);
        Assert.Equal(BreakDefaults.LongBreakIntervalMinutes, settings.LongBreakIntervalMinutes);
    }

    [Fact]
    public void Load_ReturnsDefaults_WhenFileIsCorrupt()
    {
        File.WriteAllText(_filePath, "{ not valid json");

        AppSettings settings = AppSettings.Load(_filePath);

        Assert.Equal(BreakDefaults.ShortBreakIntervalMinutes, settings.ShortBreakIntervalMinutes);
    }

    [Fact]
    public void SaveThenLoad_RoundTripsAllValues()
    {
        AppSettings original = new AppSettings
        {
            ShortBreakEnabled = false,
            LongBreakEnabled = true,
            ShortBreakIntervalMinutes = 25,
            LongBreakIntervalMinutes = 90,
            RunAtStartup = false,
            SoundEnabled = false,
        };

        original.Save(_filePath);
        AppSettings loaded = AppSettings.Load(_filePath);

        Assert.Equal(original.ShortBreakEnabled, loaded.ShortBreakEnabled);
        Assert.Equal(original.LongBreakEnabled, loaded.LongBreakEnabled);
        Assert.Equal(original.ShortBreakIntervalMinutes, loaded.ShortBreakIntervalMinutes);
        Assert.Equal(original.LongBreakIntervalMinutes, loaded.LongBreakIntervalMinutes);
        Assert.Equal(original.RunAtStartup, loaded.RunAtStartup);
        Assert.Equal(original.SoundEnabled, loaded.SoundEnabled);
    }

    [Fact]
    public void Save_CreatesParentDirectory_WhenMissing()
    {
        string nestedPath = Path.Combine(Path.GetTempPath(), $"eyebreak-settings-dir-{Guid.NewGuid():N}", "settings.json");

        try
        {
            new AppSettings().Save(nestedPath);

            Assert.True(File.Exists(nestedPath));
        }
        finally
        {
            string? directory = Path.GetDirectoryName(nestedPath);
            if (directory != null && Directory.Exists(directory))
            {
                Directory.Delete(directory, recursive: true);
            }
        }
    }
}
