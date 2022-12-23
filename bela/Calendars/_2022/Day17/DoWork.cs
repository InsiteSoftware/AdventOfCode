namespace Calendars._2022.Day17;

public static class DoWork
{
    public static long FirstPart(string input, long totalRocks = 2022)
    {
        var chamber = new bool[7, 1000];

        for (var x = 0; x < 7; x++)
        {
            chamber[x, 0] = true;
        }

        var gusts = input.ToCharArray().Select(o => o == '<').ToArray();
        var nextGust = 0;
        var highPoint = 1;
        var offset = 0L;
        var gustsCycled = false;
        var gustsAtRock0 = new HashSet<int>();
        var startOfCycle = 0L;
        var gustAtStart = 0;
        var heightAtStart = 0L;
        for (var rockNumber = 0L; rockNumber < totalRocks; rockNumber++)
        {
            if (gustsCycled && rockNumber % 5 == 0)
            {
                if (startOfCycle == 0)
                {
                    if (gustsAtRock0.Contains(nextGust))
                    {
                        startOfCycle = rockNumber;
                        gustAtStart = nextGust;
                        heightAtStart = offset + highPoint;
                    }
                    else
                    {
                        gustsAtRock0.Add(nextGust);
                    }
                }
                else if (nextGust == gustAtStart)
                {
                    var cycleSize = rockNumber - startOfCycle;
                    var offsetSize = offset + highPoint - heightAtStart;

                    // could be faster, but it had a bug, good enough!
                    while (rockNumber + cycleSize < totalRocks)
                    {
                        offset += offsetSize;
                        rockNumber += cycleSize;
                    }
                }
            }

            if (highPoint > 900)
            {
                highPoint -= 800;
                offset += 800;
                var newChamber = new bool[7, 1000];
                for (var x = 0; x < chamber.GetLength(0); x++)
                {
                    Buffer.BlockCopy(
                        chamber,
                        (800 + (x * chamber.GetLength(1))) * sizeof(bool),
                        newChamber,
                        (x * chamber.GetLength(1)) * sizeof(bool),
                        200 * sizeof(bool)
                    );
                }

                chamber = newChamber;
            }

            var nextShape = Shape.GetNext(rockNumber, highPoint + 3);

            while (true)
            {
                var moveLeft = gusts[nextGust];
                nextGust = (nextGust + 1) % gusts.Length;
                if (nextGust == 0)
                {
                    gustsCycled = true;
                }
                if (moveLeft)
                {
                    var canMove = true;
                    if (nextShape.FarLeft == 0)
                    {
                        canMove = false;
                    }
                    else
                    {
                        for (var x = 0; x < nextShape.Points.Count; x++)
                        {
                            if (chamber[nextShape.Points[x].X - 1, nextShape.Points[x].Y])
                            {
                                canMove = false;
                                break;
                            }
                        }
                    }

                    if (canMove)
                    {
                        nextShape.MoveLeft();
                    }
                }
                else
                {
                    var canMove = true;
                    if (nextShape.FarRight == 6)
                    {
                        canMove = false;
                    }
                    else
                    {
                        for (var x = 0; x < nextShape.Points.Count; x++)
                        {
                            if (chamber[nextShape.Points[x].X + 1, nextShape.Points[x].Y])
                            {
                                canMove = false;
                                break;
                            }
                        }
                    }

                    if (canMove)
                    {
                        nextShape.MoveRight();
                    }
                }

                var canFall = true;
                for (var x = 0; x < nextShape.Points.Count; x++)
                {
                    if (chamber[nextShape.Points[x].X, nextShape.Points[x].Y - 1])
                    {
                        canFall = false;
                        break;
                    }
                }

                if (canFall)
                {
                    nextShape.MoveDown();
                }
                else
                {
                    for (var x = 0; x < nextShape.Points.Count; x++)
                    {
                        highPoint = Math.Max(highPoint, nextShape.Points[x].Y + 1);
                        chamber[nextShape.Points[x].X, nextShape.Points[x].Y] = true;
                    }

                    break;
                }
            }
        }

        return highPoint + offset - 1;
    }

    public static long SecondPart(string input)
    {
        return FirstPart(input, 1_000_000_000_000);
    }

    private class Shape
    {
        public int FarLeft;
        public int FarRight;

        public static Shape GetNext(long blockNumber, int startingY)
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

            shape.FarLeft = 2;
            shape.FarRight = 5;
            return shape;
        }

        public static Shape BuildVLine(int startingY)
        {
            var shape = new Shape();
            shape.Points.Add(new Point(2, startingY));
            shape.Points.Add(new Point(2, startingY + 1));
            shape.Points.Add(new Point(2, startingY + 2));
            shape.Points.Add(new Point(2, startingY + 3));
            shape.FarLeft = 2;
            shape.FarRight = 2;
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
            shape.FarLeft = 2;
            shape.FarRight = 4;
            return shape;
        }

        public static Shape BuildBox(int startingY)
        {
            var shape = new Shape();
            shape.Points.Add(new Point(2, startingY + 1));
            shape.Points.Add(new Point(3, startingY + 1));
            shape.Points.Add(new Point(2, startingY));
            shape.Points.Add(new Point(3, startingY));
            shape.FarLeft = 2;
            shape.FarRight = 3;
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
            shape.FarLeft = 2;
            shape.FarRight = 4;
            return shape;
        }

        public readonly List<Point> Points = new(5);

        public void MoveLeft()
        {
            for (var x = 0; x < this.Points.Count; x++)
            {
                this.Points[x].X--;
            }
            this.FarLeft--;
            this.FarRight--;
        }

        public void MoveRight()
        {
            for (var x = 0; x < this.Points.Count; x++)
            {
                this.Points[x].X++;
            }
            this.FarLeft++;
            this.FarRight++;
        }

        public void MoveDown()
        {
            for (var x = 0; x < this.Points.Count; x++)
            {
                this.Points[x].Y--;
            }
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
