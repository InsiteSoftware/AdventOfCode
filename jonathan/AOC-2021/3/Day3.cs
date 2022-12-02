namespace AOC_2021;

public static class Day3
{
    public static int GetPart1Answer(string[] lines)
    {
        var numberWidth = lines[0].Length;
        var totals = new int[numberWidth];
        foreach (var line in lines)
        {
            for (var i = 0; i < numberWidth; i++)
            {
                totals[i] = line[i] == '1' ? totals[i] + 1 : totals[i];
            }
        }

        var minValue = lines.Length / 2;
        var gamma = string.Empty;
        var epsilon = string.Empty;
        
        for (var i = 0; i < numberWidth; i++)
        {
            gamma += totals[i] > minValue ? "1" : "0";
            epsilon += totals[i] <= minValue ? "1" : "0";
        }

        var gammaNum = Convert.ToInt32(gamma, 2);
        var epsilonNum = Convert.ToInt32(epsilon, 2);
        return gammaNum * epsilonNum;
    }

    public static int GetPart2Answer((string direction, int distance)[] lines)
    {
        var position = (x: 0, y: 0, aim: 0);
        foreach (var line in lines)
        {
            switch (line.direction)
            {
                case "up":
                    position.aim -= line.distance;
                    break;

                case "down":
                    position.aim += line.distance;
                    break;

                case "forward":
                    position.x += line.distance;
                    position.y -= position.aim * line.distance;
                    break;

                default:
                    throw new Exception($"Where the fuck you going? {line.direction}");
            }

            if (position.y > 0)
                throw new Exception("Submarines can't fly");
        }

        return position.x * -1 * position.y;
    }
}