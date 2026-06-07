namespace eyebreak;

internal static class CountdownFormatter
{
    public static string Format(TimeSpan remaining)
    {
        if (remaining < TimeSpan.Zero)
        {
            remaining = TimeSpan.Zero;
        }

        return remaining.TotalHours >= 1
            ? $"{(int)remaining.TotalHours}:{remaining.Minutes:D2}:{remaining.Seconds:D2}"
            : $"{remaining.Minutes}:{remaining.Seconds:D2}";
    }
}
