namespace Calendars._2022.Day14;

public static class DoWork
{
    public static int FirstPart(string input, bool part2 = false)
    {
        input = input.Replace(" -> ", "-");
        var allLeftDigits = string.Join("-", input.SplitLines())
            .Split("-")
            .Select(o => int.Parse(o.Split(",")[0]))
            .ToList();
        var allRightDigits = string.Join("-", input.SplitLines())
            .Split("-")
            .Select(o => int.Parse(o.Split(",")[1]))
            .ToList();
        var height = part2 ? allRightDigits.Max() + 3 : 200;
        var farthestLeft = allLeftDigits.Min() - 1;
        var farthestRight = allLeftDigits.Max() + 2;
        if (part2)
        {
            farthestLeft = farthestLeft - height;
            farthestRight = farthestRight + height;
        }
        var width = farthestRight - farthestLeft;
        var stuff = new string?[width, height];

        if (part2)
        {
            for (var x = 0; x < width; x++)
            {
                stuff[x, height - 1] = "#";
            }
        }

        foreach (var line in input.SplitLines())
        {
            var sections = line.Split("-");

            (int x, int y) GetCoords(string value)
            {
                var digits = value.Split(",");
                return (int.Parse(digits[0]) - farthestLeft, int.Parse(digits[1]));
            }

            var current = GetCoords(sections[0]);

            for (var index = 1; index < sections.Length; index++)
            {
                var next = GetCoords(sections[index]);

                for (var x = Math.Min(next.x, current.x); x <= Math.Max(next.x, current.x); x++)
                {
                    for (var y = Math.Min(next.y, current.y); y <= Math.Max(next.y, current.y); y++)
                    {
                        stuff[x, y] = "#";
                    }
                }

                current = next;
            }
        }

        var canMove = true;
        while (canMove)
        {
            (int x, int y) sandPosition = (500 - farthestLeft, 0);
            if (stuff[sandPosition.x, sandPosition.y] == "o")
            {
                canMove = false;
                break;
            }
            while (true)
            {
                if (sandPosition.y + 1 == height)
                {
                    canMove = false;
                    break;
                }
                var down = stuff[sandPosition.x, sandPosition.y + 1];
                if (down == null)
                {
                    sandPosition.y++;
                }
                else if (down is "o" or "#")
                {
                    if (stuff[sandPosition.x - 1, sandPosition.y + 1] == null)
                    {
                        sandPosition.x--;
                        sandPosition.y++;
                    }
                    else if (stuff[sandPosition.x + 1, sandPosition.y + 1] == null)
                    {
                        sandPosition.x++;
                        sandPosition.y++;
                    }
                    else
                    {
                        stuff[sandPosition.x, sandPosition.y] = "o";
                        break;
                    }
                }
            }
        }

        var totalSand = 0;
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                if (stuff[x, y] == "o")
                {
                    totalSand++;
                }
                Console.Write(stuff[x, y] ?? ".");
            }
            Console.WriteLine();
        }

        return totalSand;
    }

    public static int SecondPart(string input)
    {
        return FirstPart(input, true);
    }
}
