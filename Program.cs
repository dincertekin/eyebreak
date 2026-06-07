namespace eyebreak;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // WinForms dark-mode support (SetColorMode/SystemColorMode) is still an evaluation API in .NET 9
        // (WFO5001) and may change or be removed in a future SDK update.
#pragma warning disable WFO5001
        Application.SetColorMode(SystemColorMode.System);
#pragma warning restore WFO5001

        Application.Run(new MainForm());
    }
}
