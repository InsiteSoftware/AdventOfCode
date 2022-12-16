namespace Calendars._2022.Day12;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var lines = input.SplitLines();
        var width = lines[0].Length;
        var height = lines.Length;
        var map = new int[width, height];
        (int X, int Y) start = (0, 0);
        (int X, int Y) end = (0, 0);

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var current = lines[y][x];
                if (current == 'S')
                {
                    start = (x, y);
                }
                else if (current == 'E')
                {
                    end = (x, y);
                    map[x, y] = 'z' - 'a';
                }
                else
                {
                    map[x, y] = current - 'a';
                }
            }
        }

        var moves = new Queue<((int X, int Y), int Steps)>();
        var nextMoves = new Queue<((int X, int Y), int Steps)>();
        var bestPathTo = new Dictionary<(int X, int Y), int> { [(0, 0)] = 0 };

        void AddMoves(int x1, int y1, int x2, int y2, int steps)
        {
            if (x2 < 0 || x2 >= width || y2 < 0 || y2 >= height)
            {
                return;
            }

            if (!bestPathTo.TryGetValue((x2, y2), out var currentBest))
            {
                currentBest = int.MaxValue;
            }

            if (steps + 1 >= currentBest)
            {
                return;
            }

            if (map[x1, y1] + 1 >= map[x2, y2])
            {
                bestPathTo[(x2, y2)] = steps + 1;
                nextMoves.Enqueue(((x2, y2), steps + 1));
            }
        }

        moves.Enqueue((start, 0));
        while (moves.Count > 0)
        {
            var (current, steps) = moves.Dequeue();
            AddMoves(current.X, current.Y, current.X + 1, current.Y, steps);
            AddMoves(current.X, current.Y, current.X + 1, current.Y, steps);
            AddMoves(current.X, current.Y, current.X, current.Y + 1, steps);
            AddMoves(current.X, current.Y, current.X, current.Y - 1, steps);

            if (moves.Count == 0)
            {
                (moves, nextMoves) = (nextMoves, moves);
            }
        }

        return bestPathTo[end];
    }

    public static int SecondPart(string input)
    {
        var lines = input.SplitLines();
        var width = lines[0].Length;
        var height = lines.Length;
        var map = new int[width, height];
        (int X, int Y) end = (0, 0);

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var current = lines[y][x];
                if (current == 'E')
                {
                    end = (x, y);
                    map[x, y] = 'z' - 'a';
                }
                else
                {
                    map[x, y] = current - 'a';
                }
            }
        }

        int FindBest((int X, int Y) start)
        {
            var moves = new Queue<((int X, int Y), int Steps)>();
            var nextMoves = new Queue<((int X, int Y), int Steps)>();
            var bestPathTo = new Dictionary<(int X, int Y), int> { [(0, 0)] = 0 };

            void AddMoves(int x1, int y1, int x2, int y2, int steps)
            {
                if (x2 < 0 || x2 >= width || y2 < 0 || y2 >= height)
                {
                    return;
                }

                if (!bestPathTo.TryGetValue((x2, y2), out var currentBest))
                {
                    currentBest = int.MaxValue;
                }

                if (steps + 1 >= currentBest)
                {
                    return;
                }

                if (map[x1, y1] + 1 >= map[x2, y2])
                {
                    bestPathTo[(x2, y2)] = steps + 1;
                    nextMoves.Enqueue(((x2, y2), steps + 1));
                }
            }

            moves.Enqueue((start, 0));
            while (moves.Count > 0)
            {
                var (current, steps) = moves.Dequeue();
                AddMoves(current.X, current.Y, current.X + 1, current.Y, steps);
                AddMoves(current.X, current.Y, current.X + 1, current.Y, steps);
                AddMoves(current.X, current.Y, current.X, current.Y + 1, steps);
                AddMoves(current.X, current.Y, current.X, current.Y - 1, steps);

                if (moves.Count == 0)
                {
                    (moves, nextMoves) = (nextMoves, moves);
                }
            }

            return bestPathTo.ContainsKey(end) ? bestPathTo[end] : int.MaxValue;
        }

        var best = int.MaxValue;
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                if (map[x, y] == 0)
                {
                    best = int.Min(best, FindBest((x, y)));
                }
            }
        }

        return best;
    }
}
