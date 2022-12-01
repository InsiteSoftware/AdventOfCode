namespace Calendars._2022.Day01;
public static class DoWork {
    public static int FirstPart(string input, int take = 1) {
        var elves = new List<int>();
        var current = 0;
        input.Split('\n').Select(o => o.Trim()).Select(o => o == string.Empty ? -1 : int.Parse(o)).ToList().ForEach(o => {
            if (o == -1)
                elves.Add(current);
            current = o == -1 ? 0 : current + o;
        });
        return elves.Concat(new [] { current }).OrderByDescending(o => o).Take(take).Sum();
    }
    public static int SecondPart(string input) => FirstPart(input, 3);
}
