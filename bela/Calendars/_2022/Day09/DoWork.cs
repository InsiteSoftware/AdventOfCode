namespace Calendars._2022.Day09;

public static class DoWork
{
    private record Knot(int x, int y);

    public static int FirstPart(string input, int numberOfKnots = 2)
    {
        var tailPositions = new List<(int, int)>();

        var knots = new List<(int x, int y)>();

        for (var x = 0; x < numberOfKnots; x++)
        {
            knots.Add((0, 0));
        }

        void MoveTo((int x, int y) newPosition, int knotIndex = 0)
        {
            var tailPosition = knots[knotIndex + 1];
            var headPosition = knots[knotIndex] = newPosition;
            if (headPosition.x == tailPosition.x)
            {
                if (headPosition.y - tailPosition.y > 1)
                {
                    tailPosition.y += 1;
                }
                else if (tailPosition.y - headPosition.y > 1)
                {
                    tailPosition.y -= 1;
                }
            }
            else if (headPosition.y == tailPosition.y)
            {
                if (headPosition.x - tailPosition.x > 1)
                {
                    tailPosition.x += 1;
                }
                else if (tailPosition.x - headPosition.x > 1)
                {
                    tailPosition.x -= 1;
                }
            }
            else
            {
                if (headPosition.x - tailPosition.x == 2)
                {
                    tailPosition.x += 1;
                    if (headPosition.y - tailPosition.y == 2)
                    {
                        tailPosition.y += 1;
                    }
                    else if (tailPosition.y - headPosition.y == 2)
                    {
                        tailPosition.y -= 1;
                    }
                    else
                    {
                        tailPosition.y = headPosition.y;
                    }
                }
                else if (tailPosition.x - headPosition.x == 2)
                {
                    tailPosition.x -= 1;
                    if (headPosition.y - tailPosition.y == 2)
                    {
                        tailPosition.y += 1;
                    }
                    else if (tailPosition.y - headPosition.y == 2)
                    {
                        tailPosition.y -= 1;
                    }
                    else
                    {
                        tailPosition.y = headPosition.y;
                    }
                }
                else if (headPosition.y - tailPosition.y == 2)
                {
                    tailPosition.y += 1;
                    if (headPosition.x - tailPosition.x == 2)
                    {
                        tailPosition.x += 1;
                    }
                    else if (tailPosition.x - headPosition.x == 2)
                    {
                        tailPosition.x -= 1;
                    }
                    else
                    {
                        tailPosition.x = headPosition.x;
                    }
                }
                else if (tailPosition.y - headPosition.y == 2)
                {
                    tailPosition.y -= 1;
                    if (headPosition.x - tailPosition.x == 2)
                    {
                        tailPosition.x += 1;
                    }
                    else if (tailPosition.x - headPosition.x == 2)
                    {
                        tailPosition.x -= 1;
                    }
                    else
                    {
                        tailPosition.x = headPosition.x;
                    }
                }
            }

            knots[knotIndex + 1] = tailPosition;
            if (knotIndex + 2 < knots.Count)
            {
                MoveTo(tailPosition, knotIndex + 1);
            }
            else
            {
                tailPositions.Add(tailPosition);
            }
        }

        foreach (var line in input.SplitLines())
        {
            Console.WriteLine(line);
            var inputs = line.Split(' ');
            var direction = inputs[0];
            var spaces = int.Parse(inputs[1]);

            if (direction == "R")
            {
                for (var x = 0; x < spaces; x++)
                {
                    MoveTo((knots[0].x + 1, knots[0].y));
                }
            }
            else if (direction == "L")
            {
                for (var x = 0; x < spaces; x++)
                {
                    MoveTo((knots[0].x - 1, knots[0].y));
                }
            }
            else if (direction == "U")
            {
                for (var x = 0; x < spaces; x++)
                {
                    MoveTo((knots[0].x, knots[0].y + 1));
                }
            }
            else if (direction == "D")
            {
                for (var x = 0; x < spaces; x++)
                {
                    MoveTo((knots[0].x, knots[0].y - 1));
                }
            }
        }

        return tailPositions.Distinct().Count();
    }

    public static int SecondPart(string input)
    {
        return FirstPart(input, 10);
    }
}
