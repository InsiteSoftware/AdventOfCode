namespace Calendars.Template;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var lines = input.Replace("\r", "").Split('\n');

        foreach (var line in lines)
        {
            // stuff
        }

        return 0;
    }

    public static int SecondPart(string input)
    {
        var lines = input.Replace("\r", "").Split('\n');

        foreach (var line in lines)
        {
            // stuff
        }

        return 0;
    }
}
