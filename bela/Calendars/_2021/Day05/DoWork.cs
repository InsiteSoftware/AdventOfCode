namespace Calendars._2021.Day05;

public static class DoWork
{
    public static int FirstPart(string input, bool useDiagonals = false)
    {
        var length = 1000;
        var points = new Dictionary<int, int>();

        foreach (var line in input.Replace(" -> ", ",").SplitLines())
        {
            var inputs = line.Split(',').Select(int.Parse).ToArray();
            var x1 = inputs[0];
            var y1 = inputs[1];
            var x2 = inputs[2];
            var y2 = inputs[3];
            if (x1 != x2 && y1 != y2 && !useDiagonals)
            {
                continue;
            }

            var x = x1;
            var y = y1;
            while (true)
            {
                var point = x + (y * length);
                if (!points.ContainsKey(point))
                {
                    points[point] = 0;
                }
                points[point] += 1;

                x +=
                    x1 == x2
                        ? 0
                        : x1 < x2
                            ? 1
                            : -1;
                y +=
                    y1 == y2
                        ? 0
                        : y1 < y2
                            ? 1
                            : -1;

                if (
                    (x > x1 && x > x2 || x < x1 && x < x2) || (y > y1 && y > y2 || y < y1 && y < y2)
                )
                {
                    break;
                }
            }
        }

        return points.Values.Count(o => o > 1);
    }

    public static int SecondPart(string input)
    {
        return FirstPart(input, true);
    }
}
