namespace Calendars._2022.Day17;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        // 3 units above last rock/floor
        // air pushes if it can
        // then rock falls one unit
        // repeat
        // if at fall step, there is something blocking it, then it comes to rest
        var chamber = new bool[7, 2022 * 4];

        var gusts = input.ToCharArray().Select(o => o == '<').ToArray();
        var nextGust = 0;
        var highPoint = 3;
        for (var x = 0; x < 2022; x++)
        {
            var nextShape = Shape.GetNext(x, highPoint);
            while (true)
            {
                var moveLeft = gusts[nextGust % gusts.Length];
                if (moveLeft)
                {
                    // check if can move left
                    nextShape.MoveLeft();
                }
                else if (!moveLeft)
                {
                    // check if can move right
                    nextShape.MoveRight();
                }

                // check if can move down, if can't, go to next
            }
        }

        return 0;
    }

    public static int SecondPart(string input)
    {
        foreach (var line in input.SplitLines())
        {
            // stuff
        }

        return 0;
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
