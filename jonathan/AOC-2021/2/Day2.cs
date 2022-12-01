namespace AOC_2021;

public static class Day2
{
    public static int GetPart1Answer((string direction, int distance)[] lines)
    {
        var position = (x: 0, y: 0);
        foreach (var line in lines)
        {
            switch (line.direction)
            {
                case "up":
                    position.y += line.distance;
                    break;
                
                case "down":
                    position.y -= line.distance;
                    break;
                
                case "forward":
                    position.x += line.distance;
                    break;

                default:
                    throw new Exception($"Where the fuck you going? {line.direction}");
            }

            if (position.y > 0)
                throw new Exception("Submarines can't fly");
        }

        return position.x * -1 * position.y;
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