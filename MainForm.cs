using System.Media;

namespace eyebreak;

public partial class MainForm : Form
{
    private static readonly TimeSpan TickInterval = TimeSpan.FromSeconds(1);

    private readonly AppSettings _settings;
    private TimeSpan _shortBreakRemaining;
    private TimeSpan _longBreakRemaining;
    private bool _isLoaded;

    public MainForm()
    {
        InitializeComponent();

        _settings = AppSettings.Load();
        ApplySettingsToControls();

        _shortBreakRemaining = TimeSpan.FromMinutes(_settings.ShortBreakIntervalMinutes);
        _longBreakRemaining = TimeSpan.FromMinutes(_settings.LongBreakIntervalMinutes);
        UpdateCountdownLabels();

        try
        {
            StartupManager.SetEnabled(_settings.RunAtStartup);
        }
        catch (Exception)
        {
            // Best-effort: failing to sync the startup registry entry should not prevent the app from launching.
        }

        notifyIcon.ContextMenuStrip = BuildTrayContextMenu();

        _isLoaded = true;
        countdownTimer.Start();
    }

    private void ApplySettingsToControls()
    {
        runAtStartupCheckBox.Checked = _settings.RunAtStartup;
        playSoundCheckBox.Checked = _settings.SoundEnabled;
        shortBreakEnabledCheckBox.Checked = _settings.ShortBreakEnabled;
        longBreakEnabledCheckBox.Checked = _settings.LongBreakEnabled;
        shortBreakIntervalNumericUpDown.Value = _settings.ShortBreakIntervalMinutes;
        longBreakIntervalNumericUpDown.Value = _settings.LongBreakIntervalMinutes;
    }

    private ContextMenuStrip BuildTrayContextMenu()
    {
        ToolStripMenuItem takeBreakNowItem = new ToolStripMenuItem("Take a break now");
        takeBreakNowItem.Click += TakeBreakNowMenuItem_Click;

        ToolStripMenuItem snoozeItem = new ToolStripMenuItem($"Snooze for {BreakDefaults.SnoozeMinutes} minutes");
        snoozeItem.Click += SnoozeMenuItem_Click;

        ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
        exitItem.Click += ExitMenuItem_Click;

        ContextMenuStrip menu = new ContextMenuStrip();
        menu.Items.Add(takeBreakNowItem);
        menu.Items.Add(snoozeItem);
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(exitItem);
        return menu;
    }

    private void notifyIcon_DoubleClick(object? sender, EventArgs e)
    {
        Show();
        WindowState = FormWindowState.Normal;
    }

    private void ExitMenuItem_Click(object? sender, EventArgs e)
    {
        notifyIcon.Visible = false;
        Application.Exit();
    }

    private void TakeBreakNowMenuItem_Click(object? sender, EventArgs e)
    {
        ShowReminder("Break Time!", "Step away from the screen for a moment and rest your eyes.");
    }

    private void SnoozeMenuItem_Click(object? sender, EventArgs e)
    {
        TimeSpan snooze = TimeSpan.FromMinutes(BreakDefaults.SnoozeMinutes);
        _shortBreakRemaining += snooze;
        _longBreakRemaining += snooze;
        UpdateCountdownLabels();
        ShowReminder("Reminders Snoozed", $"Break reminders are snoozed for {BreakDefaults.SnoozeMinutes} minutes.");
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
        notifyIcon.ShowBalloonTip(BreakDefaults.BalloonTipDurationMs, "eyebreak", "The application is still running in the system tray.", ToolTipIcon.Info);
    }

    private void countdownTimer_Tick(object? sender, EventArgs e)
    {
        if (shortBreakEnabledCheckBox.Checked)
        {
            _shortBreakRemaining -= TickInterval;
            if (_shortBreakRemaining <= TimeSpan.Zero)
            {
                ShowReminder("Short Break Time!", "20 minutes have passed! Take a 20-second break and look at something 20 feet away.");
                _shortBreakRemaining = TimeSpan.FromMinutes(_settings.ShortBreakIntervalMinutes);
            }
        }

        if (longBreakEnabledCheckBox.Checked)
        {
            _longBreakRemaining -= TickInterval;
            if (_longBreakRemaining <= TimeSpan.Zero)
            {
                ShowReminder("Long Break Time!", "It's been a while! Take a 15-minute break away from the screen.");
                _longBreakRemaining = TimeSpan.FromMinutes(_settings.LongBreakIntervalMinutes);
            }
        }

        UpdateCountdownLabels();
    }

    private void ShowReminder(string title, string message)
    {
        notifyIcon.BalloonTipTitle = title;
        notifyIcon.BalloonTipText = message;
        notifyIcon.ShowBalloonTip(BreakDefaults.BalloonTipDurationMs);

        if (_settings.SoundEnabled)
        {
            SystemSounds.Asterisk.Play();
        }
    }

    private void UpdateCountdownLabels()
    {
        nextShortBreakLabel.Text = shortBreakEnabledCheckBox.Checked
            ? $"Next short break in {CountdownFormatter.Format(_shortBreakRemaining)}"
            : "Short breaks are turned off";

        nextLongBreakLabel.Text = longBreakEnabledCheckBox.Checked
            ? $"Next long break in {CountdownFormatter.Format(_longBreakRemaining)}"
            : "Long breaks are turned off";
    }

    private void shortBreakEnabledCheckBox_CheckedChanged(object? sender, EventArgs e)
    {
        _settings.ShortBreakEnabled = shortBreakEnabledCheckBox.Checked;
        _shortBreakRemaining = TimeSpan.FromMinutes(_settings.ShortBreakIntervalMinutes);
        UpdateCountdownLabels();
        SaveSettings();
    }

    private void longBreakEnabledCheckBox_CheckedChanged(object? sender, EventArgs e)
    {
        _settings.LongBreakEnabled = longBreakEnabledCheckBox.Checked;
        _longBreakRemaining = TimeSpan.FromMinutes(_settings.LongBreakIntervalMinutes);
        UpdateCountdownLabels();
        SaveSettings();
    }

    private void shortBreakIntervalNumericUpDown_ValueChanged(object? sender, EventArgs e)
    {
        if (!_isLoaded)
        {
            return;
        }

        _settings.ShortBreakIntervalMinutes = (int)shortBreakIntervalNumericUpDown.Value;
        _shortBreakRemaining = TimeSpan.FromMinutes(_settings.ShortBreakIntervalMinutes);
        UpdateCountdownLabels();
        SaveSettings();
    }

    private void longBreakIntervalNumericUpDown_ValueChanged(object? sender, EventArgs e)
    {
        if (!_isLoaded)
        {
            return;
        }

        _settings.LongBreakIntervalMinutes = (int)longBreakIntervalNumericUpDown.Value;
        _longBreakRemaining = TimeSpan.FromMinutes(_settings.LongBreakIntervalMinutes);
        UpdateCountdownLabels();
        SaveSettings();
    }

    private void playSoundCheckBox_CheckedChanged(object? sender, EventArgs e)
    {
        _settings.SoundEnabled = playSoundCheckBox.Checked;
        SaveSettings();
    }

    private void runAtStartupCheckBox_CheckedChanged(object? sender, EventArgs e)
    {
        _settings.RunAtStartup = runAtStartupCheckBox.Checked;

        try
        {
            StartupManager.SetEnabled(_settings.RunAtStartup);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error accessing registry: {ex.Message}", "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        SaveSettings();
    }

    private void SaveSettings()
    {
        if (!_isLoaded)
        {
            return;
        }

        try
        {
            _settings.Save();
        }
        catch (Exception)
        {
            // Settings persistence is best-effort; failing to save should not interrupt the user.
        }
    }
}
