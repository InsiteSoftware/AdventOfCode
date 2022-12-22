namespace Calendars._2022.Day17;

public static class DoWork
{
    public static long FirstPart(string input, long totalRocks = 2022)
    {
        // 3 units above last rock/floor
        // air pushes if it can
        // then rock falls one unit
        // repeat
        // if at fall step, there is something blocking it, then it comes to rest
        var chamber = new List<List<bool>>
        {
            new(200),
            new(200),
            new(200),
            new(200),
            new(200),
            new(200),
            new(200)
        };

        foreach (var stack in chamber)
        {
            for (var x = 0; x < 200; x++)
            {
                stack.Add(false);
            }
        }

        var gusts = input.ToCharArray().Select(o => o == '<').ToArray();
        var nextGust = 0;
        var highPoint = 0;
        var offset = 0L;
        for (var rockNumber = 0; rockNumber < totalRocks; rockNumber++)
        {
            while (highPoint > 100)
            {
                offset++;
                highPoint--;
                chamber.ForEach(o => o.RemoveAt(1));
                chamber.ForEach(o => o.Add(false));
            }

            var nextShape = Shape.GetNext(rockNumber, highPoint + 3);

            bool CheckCollisions()
            {
                foreach (var point in nextShape.Points)
                {
                    if (point.X is < 0 or > 6 || point.Y < 0)
                    {
                        return true;
                    }

                    if (chamber[point.X][point.Y])
                    {
                        return true;
                    }
                }

                return false;
            }

            while (true)
            {
                var moveLeft = gusts[nextGust];
                nextGust = (nextGust + 1) % gusts.Length;
                if (moveLeft)
                {
                    nextShape.MoveLeft();
                    if (CheckCollisions())
                    {
                        nextShape.MoveRight();
                    }
                }
                else if (!moveLeft)
                {
                    nextShape.MoveRight();
                    if (CheckCollisions())
                    {
                        nextShape.MoveLeft();
                    }
                }

                nextShape.MoveDown();
                if (CheckCollisions())
                {
                    nextShape.MoveUp();
                    foreach (var point in nextShape.Points)
                    {
                        highPoint = Math.Max(highPoint, point.Y + 1);
                        chamber[point.X][point.Y] = true;
                    }

                    break;
                }
            }
        }

        return highPoint + offset;
    }

    public static long SecondPart(string input)
    {
        return FirstPart(input, 1000000000000);
    }

    private class Shape
    {
        public static Shape GetNext(int blockNumber, int startingY)
        {
            return (blockNumber % 5) switch
            {
                0 => BuildHLine(startingY),
                1 => BuildCross(startingY),
                2 => BuildBackwardL(startingY),
                3 => BuildVLine(startingY),
                4 => BuildBox(startingY),
            };
        }

        public static Shape BuildHLine(int startingY)
        {
            var shape = new Shape();
            shape.Points.Add(new Point(2, startingY));
            shape.Points.Add(new Point(3, startingY));
            shape.Points.Add(new Point(4, startingY));
            shape.Points.Add(new Point(5, startingY));
            return shape;
        }

        public static Shape BuildVLine(int startingY)
        {
            var shape = new Shape();
            shape.Points.Add(new Point(2, startingY));
            shape.Points.Add(new Point(2, startingY + 1));
            shape.Points.Add(new Point(2, startingY + 2));
            shape.Points.Add(new Point(2, startingY + 3));
            return shape;
        }

        public static Shape BuildCross(int startingY)
        {
            var shape = new Shape();
            shape.Points.Add(new Point(2, startingY + 1));
            shape.Points.Add(new Point(3, startingY + 1));
            shape.Points.Add(new Point(4, startingY + 1));
            shape.Points.Add(new Point(3, startingY));
            shape.Points.Add(new Point(3, startingY + 2));
            return shape;
        }

        public static Shape BuildBox(int startingY)
        {
            var shape = new Shape();
            shape.Points.Add(new Point(2, startingY + 1));
            shape.Points.Add(new Point(3, startingY + 1));
            shape.Points.Add(new Point(2, startingY));
            shape.Points.Add(new Point(3, startingY));
            return shape;
        }

        public static Shape BuildBackwardL(int startingY)
        {
            var shape = new Shape();
            shape.Points.Add(new Point(2, startingY));
            shape.Points.Add(new Point(3, startingY));
            shape.Points.Add(new Point(4, startingY));
            shape.Points.Add(new Point(4, startingY + 1));
            shape.Points.Add(new Point(4, startingY + 2));
            return shape;
        }

        public List<Point> Points = new();

        public void MoveLeft()
        {
            this.Points.ForEach(o => o.X--);
        }

        public void MoveRight()
        {
            this.Points.ForEach(o => o.X++);
        }

        public void MoveDown()
        {
            this.Points.ForEach(o => o.Y--);
        }

        public void MoveUp()
        {
            this.Points.ForEach(o => o.Y++);
            ;
        }
    }

    private class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;
    }
}
