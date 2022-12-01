namespace Calendars._2021.Day02;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var stringReader = new StringReader(input);
        var line = stringReader.ReadLine();
        var x = 0;
        var y = 0;
        while (line != null)
        {
            var inputs = line.Split(' ');
            var distance = int.Parse(inputs[1]);
            if (inputs[0] == "forward")
            {
                x += distance;
            }
            else if (inputs[0] == "up")
            {
                y -= distance;
            }
            else if (inputs[0] == "down")
            {
                y += distance;
            }

            line = stringReader.ReadLine();
        }

        return x * y;
    }

    public static int SecondPart(string input)
    {
        var stringReader = new StringReader(input);
        var line = stringReader.ReadLine();
        var horizontal = 0;
        var depth = 0;
        var aim = 0;
        while (line != null)
        {
            var inputs = line.Split(' ');
            var distance = int.Parse(inputs[1]);
            if (inputs[0] == "forward")
            {
                horizontal += distance;
                depth += distance * aim;
            }
            else if (inputs[0] == "up")
            {
                aim -= distance;
            }
            else if (inputs[0] == "down")
            {
                aim += distance;
            }

            line = stringReader.ReadLine();
        }

        return horizontal * depth;
    }
}
