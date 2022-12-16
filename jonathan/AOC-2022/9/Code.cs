namespace AOC_2022._9;

public static class Code
{
    public static int GetPart1Answer(string[] lines)
    {
        var head = (x: 0, y: 0);
        var tail = (x: 0, y: 0);
        var tailPositions = new HashSet<(int x, int y)> {(0, 0)};

        (int x, int y) MoveTail()
        {
            var xDistance = Math.Abs(head.x - tail.x);
            var yDistance = Math.Abs(head.y - tail.y);
            var needsToMove = xDistance > 1 || yDistance > 1;

            if (needsToMove || yDistance > 1)
            {
                if (head.y > tail.y)
                {
                    tail.y++;
                }
                else if (head.y < tail.y)
                {
                    tail.y--;
                }
            }
            
            if (needsToMove || xDistance > 1)
            {
                if (head.x > tail.x)
                {
                    tail.x++;
                }
                else if (head.x < tail.x)
                {
                    tail.x--;
                }
            }
            
            return tail;
        }
        
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            var direction = parts[0];
            var distance = int.Parse(parts[1]);

            for (var i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case "U":
                        head.y++;
                        break;
                    case "D":
                        head.y--;
                        break;
                    case "L":
                        head.x--;
                        break;
                    case "R":
                        head.x++;
                        break;
                    default:
                        throw new Exception("shit got fucky");
                }

                tailPositions.Add(MoveTail());
            }
        }
        
        return tailPositions.Count;
    }

    public static int GetPart2Answer(string[] lines)
    {
        var knots = new (int x, int y)[10];
        var tailPositions = new HashSet<(int x, int y)> {(0, 0)};

        void MoveKnot((int x, int y) leadKnot, ref (int x, int y) movingKnot)
        {
            
            var xDistance = Math.Abs(leadKnot.x - movingKnot.x);
            var yDistance = Math.Abs(leadKnot.y - movingKnot.y);
            var needsToMove = xDistance > 1 || yDistance > 1;

            if (needsToMove || yDistance > 1)
            {
                if (leadKnot.y > movingKnot.y)
                {
                    movingKnot.y++;
                }
                else if (leadKnot.y < movingKnot.y)
                {
                    movingKnot.y--;
                }
            }
            
            if (needsToMove || xDistance > 1)
            {
                if (leadKnot.x > movingKnot.x)
                {
                    movingKnot.x++;
                }
                else if (leadKnot.x < movingKnot.x)
                {
                    movingKnot.x--;
                }
            }
        }
        
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            var direction = parts[0];
            var distance = int.Parse(parts[1]);

            for (var i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case "U":
                        knots[0].y++;
                        break;
                    case "D":
                        knots[0].y--;
                        break;
                    case "L":
                        knots[0].x--;
                        break;
                    case "R":
                        knots[0].x++;
                        break;
                    default:
                        throw new Exception("shit got fucky");
                }

                for (var knotIndex = 1; knotIndex < knots.Length; knotIndex++)
                {
                    MoveKnot(knots[knotIndex - 1], ref knots[knotIndex]);
                }

                tailPositions.Add(knots[^1]);
            }
        }
        
        return tailPositions.Count;
    }
}