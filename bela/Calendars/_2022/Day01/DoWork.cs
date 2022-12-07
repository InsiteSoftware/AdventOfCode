namespace Calendars._2022.Day01;

public static class DoWork
{
    public static int FirstPart(string input, int take = 1)
    {
        return input
            .SplitChunks()
            .Select(o => o.SplitLines().Select(int.Parse).Sum())
            .OrderDescending()
            .Take(take)
            .Sum();
    }

    public static int SecondPart(string input) => FirstPart(input, 3);
}
