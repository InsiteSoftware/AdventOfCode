namespace Calendars._2022.Day08;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var reader = new StringReader(input);
        var line = reader.ReadLine();
        var width = line.Length;
        var height = input.SplitLines().Length;
        var trees = new int[width, height];
        var y = 0;
        while (line != null)
        {
            for (var x = 0; x < width; x++)
            {
                trees[x, y] = int.Parse(line[x].ToString());
            }

            line = reader.ReadLine();
            y++;
        }

        bool IsVisible(int x, int y)
        {
            var currentTree = trees[x, y];
            if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
            {
                return true;
            }

            var left = x - 1;
            while (left >= 0)
            {
                if (trees[left, y] >= currentTree)
                {
                    break;
                }
                left--;
            }

            if (left == -1)
            {
                return true;
            }
            var right = x + 1;
            while (right < width)
            {
                if (trees[right, y] >= currentTree)
                {
                    break;
                }
                right++;
            }

            if (right == width)
            {
                return true;
            }
            var up = y - 1;
            while (up >= 0)
            {
                if (trees[x, up] >= currentTree)
                {
                    break;
                }
                up--;
            }

            if (up == -1)
            {
                return true;
            }
            var down = y + 1;
            while (down < height)
            {
                if (trees[x, down] >= currentTree)
                {
                    break;
                }
                down++;
            }

            if (down == height)
            {
                return true;
            }

            return false;
        }

        var visibleTrees = 0;
        for (y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                if (IsVisible(x, y))
                {
                    Console.Write("Y");
                    visibleTrees++;
                }
                else
                {
                    Console.Write("N");
                }
            }
            Console.WriteLine();
        }

        return visibleTrees;
    }

    public static int SecondPart(string input)
    {
        var reader = new StringReader(input);
        var line = reader.ReadLine();
        var width = line.Length;
        var height = input.SplitLines().Length;
        var trees = new int[width, height];
        var y = 0;
        while (line != null)
        {
            for (var x = 0; x < width; x++)
            {
                trees[x, y] = int.Parse(line[x].ToString());
            }

            line = reader.ReadLine();
            y++;
        }

        int TreeScore(int x, int y)
        {
            var currentTree = trees[x, y];

            var left = x - 1;
            while (left >= 0)
            {
                if (trees[left, y] >= currentTree)
                {
                    break;
                }
                left--;
            }

            var right = x + 1;
            while (right < width)
            {
                if (trees[right, y] >= currentTree)
                {
                    break;
                }
                right++;
            }

            var up = y - 1;
            while (up >= 0)
            {
                if (trees[x, up] >= currentTree)
                {
                    break;
                }
                up--;
            }

            var down = y + 1;
            while (down < height)
            {
                if (trees[x, down] >= currentTree)
                {
                    break;
                }
                down++;
            }

            var leftScore =
                x == 0
                    ? 0
                    : left == -1
                        ? x
                        : x - left;
            var rightScore =
                x == width - 1
                    ? 0
                    : right == width
                        ? width - 1 - x
                        : right - x;
            var upScore =
                y == 0
                    ? 0
                    : up == -1
                        ? y
                        : y - up;
            var downScore =
                y == height - 1
                    ? 0
                    : down == height
                        ? height - 1 - y
                        : down - y;

            return leftScore * rightScore * upScore * downScore;
        }

        var bestScore = 0;
        for (y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var treeScore = TreeScore(x, y);
                bestScore = Math.Max(bestScore, treeScore);
            }
        }

        return bestScore;
    }
}
