namespace Calendars._2022.Day01;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var stringReader = new StringReader(input);
        var line = stringReader.ReadLine();

        var max = 0;
        var current = 0;

        while (line != null)
        {
            if (line == string.Empty)
            {
                max = Math.Max(max, current);
                current = 0;
            }
            else
            {
                current += int.Parse(line);
            }

            line = stringReader.ReadLine();
        }

        return Math.Max(max, current);
    }

    public static int SecondPart(string input)
    {
        var stringReader = new StringReader(input);
        var line = stringReader.ReadLine();

        var elves = new List<int>();
        var current = 0;

        while (line != null)
        {
            if (line == string.Empty)
            {
                elves.Add(current);
                current = 0;
            }
            else
            {
                current += int.Parse(line);
            }

            line = stringReader.ReadLine();
        }

        elves.Add(current);

        return elves.OrderByDescending(o => o).Take(3).Sum();
    }
}
