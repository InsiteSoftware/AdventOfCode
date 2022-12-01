namespace Calendars._2021.Day03;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var stringReader = new StringReader(input);
        var line = stringReader.ReadLine();

        var ones = new int[line.Length];
        var zeros = new int[line.Length];

        while (line != null)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '1')
                {
                    ones[i] += 1;
                }
                else
                {
                    zeros[i] += 1;
                }
            }

            line = stringReader.ReadLine();
        }

        var gamma = "";
        var epsilon = "";

        for (var i = 0; i < ones.Length; i++)
        {
            if (ones[i] > zeros[i])
            {
                gamma += "1";
                epsilon += "0";
            }
            else
            {
                gamma += "0";
                epsilon += "1";
            }
        }

        return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
    }

    public static int SecondPart(string input)
    {
        var stringReader = new StringReader(input);
        var line = stringReader.ReadLine();

        while (line != null)
        {
            line = stringReader.ReadLine();
        }

        return 0;
    }
}
