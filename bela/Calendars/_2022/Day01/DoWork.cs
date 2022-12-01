namespace Calendars._2022.Day01;
public static class DoWork {
    public static int FirstPart(string input, int take = 1) {
        var elves = new List<int>();
        var current = 0;
        input.Split('\n').Select(o => o.Trim()).ToList().ForEach(o => {
            if (o == string.Empty)
                elves.Add(current);
            current = o == string.Empty ? 0 : current + int.Parse(o);
        });
        return elves.Concat(new [] { current }).OrderByDescending(o => o).Take(take).Sum();
    }
    public static int SecondPart(string input) => FirstPart(input, 3);
}