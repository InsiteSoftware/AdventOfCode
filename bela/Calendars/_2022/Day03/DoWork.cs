namespace Calendars._2022.Day03;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        return input
            .SplitLines()
            .Select(
                line =>
                    GetValue(line[..(line.Length / 2)].First(line[(line.Length / 2)..].Contains))
            )
            .Sum();
    }

    public static int SecondPart(string input)
    {
        return input
            .SplitLines()
            .Select(
                (line, index) =>
                    index % 3 != 0
                        ? 0
                        : GetValue(
                            line.First(
                                character =>
                                    input.SplitLines()[index + 1].Contains(character)
                                    && input.SplitLines()[index + 2].Contains(character)
                            )
                        )
            )
            .Sum();
    }

    private static int GetValue(int value) => value - (value > 96 ? 96 : 38);
}
