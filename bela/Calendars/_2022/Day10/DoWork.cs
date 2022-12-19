namespace Calendars._2022.Day10;

using System.Text;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var cyclesWeCareAbout = new[] { 20, 60, 100, 140, 180, 220 };
        var sum = 0;

        DoStuff(
            input,
            (cycle, signalStrength) =>
            {
                if (cyclesWeCareAbout.Contains(cycle))
                {
                    sum += signalStrength * cycle;
                }
            }
        );

        return sum;
    }

    public static string SecondPart(string input)
    {
        var output = new StringBuilder();
        DoStuff(
            input,
            (cycle, signalStrength) =>
            {
                var pixel = (cycle - 1) % 40;
                output.Append(
                    pixel >= signalStrength - 1 && pixel <= signalStrength + 1 ? "#" : "."
                );

                if (cycle % 40 == 0)
                {
                    output.AppendLine();
                }
            }
        );

        Console.WriteLine(output);

        return output.ToString();
    }

    private static void DoStuff(string input, Action<int, int> stuffToDo)
    {
        input = input.Replace("noop", "").Replace("addx ", "");

        var signalStrength = 1;
        var cycle = 0;

        var reader = new StringReader(input);
        var line = reader.ReadLine();
        var addToSignal = 0;

        while (line != null)
        {
            cycle++;

            stuffToDo(cycle, signalStrength);

            if (addToSignal != 0)
            {
                signalStrength += addToSignal;
                addToSignal = 0;
                line = reader.ReadLine();
                continue;
            }

            if (string.IsNullOrEmpty(line))
            {
                line = reader.ReadLine();
            }
            else
            {
                addToSignal = int.Parse(line);
            }
        }

        cycle++;
        stuffToDo(cycle, signalStrength);
    }
}
