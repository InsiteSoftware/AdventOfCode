namespace Calendars._2022.Day06;

public static class DoWork
{
    public static int FirstPart(string input, int size = 4) =>
        input
            .Select((o, index) => new { o, index })
            .First(
                o =>
                    o.index >= size
                    && input[(o.index - size)..(o.index)].ToCharArray().Distinct().Count() == size
            )
            .index;

    public static int SecondPart(string input) => FirstPart(input, 14);
}
