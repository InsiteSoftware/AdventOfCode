namespace Calendars._2022.Day02;

public static class DoWork
{
    public static int FirstPart(string o) =>
        o.Replace("A X", "4")
            .Replace("B X", "1")
            .Replace("C X", "7")
            .Replace("A Y", "8")
            .Replace("B Y", "5")
            .Replace("C Y", "2")
            .Replace("A Z", "3")
            .Replace("B Z", "9")
            .Replace("C Z", "6")
            .SplitLines()
            .Select(int.Parse)
            .Sum();

    public static int SecondPart(string o) =>
        o.Replace("A X", "3")
            .Replace("B X", "1")
            .Replace("C X", "2")
            .Replace("A Y", "4")
            .Replace("B Y", "5")
            .Replace("C Y", "6")
            .Replace("A Z", "8")
            .Replace("B Z", "9")
            .Replace("C Z", "7")
            .SplitLines()
            .Select(int.Parse)
            .Sum();
}
