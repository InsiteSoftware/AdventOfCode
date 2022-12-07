namespace Calendars._2022.Day04;

public static class DoWork
{
    public static int FirstPart(string input) =>
        RunLogic(
            input,
            numbers =>
                (numbers[0] >= numbers[2] && numbers[1] <= numbers[3])
                || (numbers[2] >= numbers[0] && numbers[3] <= numbers[1])
                    ? 1
                    : 0
        );

    public static int SecondPart(string input) =>
        RunLogic(input, numbers => numbers[1] < numbers[2] || numbers[0] > numbers[3] ? 0 : 1);

    private static int RunLogic(string input, Func<List<int>, int> func) =>
        input
            .Replace(",", "-")
            .SplitLines()
            .Select(o => func(o.Split('-').Select(int.Parse).ToList()))
            .Sum();
}
