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
        int TrimList(List<string> list, bool keepThingWithMore)
        {
            for (var i = 0; i < list[0].Length; i++)
            {
                if (list.Count == 1)
                {
                    break;
                }

                var ones = 0;
                var zeros = 0;
                foreach (var line in list)
                {
                    if (line[i] == '1')
                    {
                        ones += 1;
                    }
                    else
                    {
                        zeros += 1;
                    }
                }

                var character = '1';
                if ((keepThingWithMore && zeros > ones) || (!keepThingWithMore && zeros <= ones))
                {
                    character = '0';
                }

                list = list.Where(o => o[i] == character).ToList();
            }

            return Convert.ToInt32(list.First(), 2);
        }

        var numbers = input.Replace("\r", "").Split('\n');
        var oxygen = TrimList(numbers.ToList(), true);
        var co2 = TrimList(numbers.ToList(), false);

        return oxygen * co2;
    }
}
