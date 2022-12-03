namespace Calendars._2021.Day05;

public static class DoWork
{
    public static int FirstPart(string input, int length = 10, bool useDiagonals = false)
    {
        var points = new int[length * length];

        foreach (var line in input.R(" -> ", ",").SP())
        {
            var inputs = line.Split(',').I().ToArray();
            var x1 = inputs[0];
            var y1 = inputs[1];
            var x2 = inputs[2];
            var y2 = inputs[3];
            if (x1 != x2 && y1 != y2)
            {
                if (!useDiagonals)
                {
                    continue;
                }
                var x = x1;
                var y = y1;
                while(true)
                {
                    points[x + (y * length)] += 1;

                    x += x1 < x2 ? 1 : -1;
                    y += y1 < y2 ? 1 : -1;
                    if (x > x1 && x > x2 || x < x1 && x < x2)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (var x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                {
                    for (var y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                    {
                        points[x + (y * length)] += 1;
                    }
                }
            }
        }

        // for (var x = 0; x < length * length; x++)
        // {            
        //     if (x % length == 0)
        //     {
        //         Console.WriteLine();
        //     }
        //     Console.Write(points[x].ToString().PadRight(3));
        // }
        
        return points.Count(o => o > 1);
    }

    public static int SecondPart(string input, int length = 10)
    {
        return FirstPart(input, length, true);
    }
}
