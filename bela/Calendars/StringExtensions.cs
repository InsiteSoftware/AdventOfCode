namespace Calendars;

public static class StringExtensions
{
    public static string[] SplitLines(this string value)
    {
        return value.Split(Environment.NewLine);
    }

    public static string[] SplitChunks(this string value)
    {
        return value.Split(Environment.NewLine + Environment.NewLine);
    }
}
