namespace Calendars;

public static class StringExtensions {
    public static string R(this string value, string oldValue, string newValue)
    {
        return value.Replace(oldValue, newValue);
    }
    
    public static string[] SP(this string value, string? separator = null)
    {
        return value.Split(separator ?? Environment.NewLine);
    }

    public static IEnumerable<int> I(this string[] value)
    {
        return value.Select(int.Parse);
    }
}