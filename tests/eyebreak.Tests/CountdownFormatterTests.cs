namespace eyebreak.Tests;

public class CountdownFormatterTests
{
    [Theory]
    [InlineData(0, 0, 0, "0:00")]
    [InlineData(0, 5, 9, "5:09")]
    [InlineData(0, 59, 59, "59:59")]
    [InlineData(1, 0, 0, "1:00:00")]
    [InlineData(2, 5, 7, "2:05:07")]
    public void Format_ReturnsExpectedRepresentation(int hours, int minutes, int seconds, string expected)
    {
        TimeSpan remaining = new TimeSpan(hours, minutes, seconds);

        string actual = CountdownFormatter.Format(remaining);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Format_ClampsNegativeValuesToZero()
    {
        TimeSpan remaining = TimeSpan.FromSeconds(-30);

        string actual = CountdownFormatter.Format(remaining);

        Assert.Equal("0:00", actual);
    }
}
