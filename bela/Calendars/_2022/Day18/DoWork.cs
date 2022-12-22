namespace Calendars._2022.Day18;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        return DoStuff(input).sides;
    }

    public static int SecondPart(string input)
    {
        var (sides, possibleAirCubes, spaces) = DoStuff(input);

        while (possibleAirCubes.Any())
        {
            var sidesInPossibleCube = 0;
            var spacesInArea = new HashSet<(int x, int y, int z)>();
            var moves = new Queue<(int x, int y, int z)>();

            var firstSpot = possibleAirCubes.Dequeue();
            if (spaces[firstSpot.x, firstSpot.y, firstSpot.z] is 'R' or 'W' or 'A')
            {
                continue;
            }
            moves.Enqueue(firstSpot);
            spacesInArea.Add(firstSpot);

            var isWater = false;

            void FindArea((int x, int y, int z) coords)
            {
                if (
                    coords.x < 0
                    || coords.x == spaces.GetLength(0)
                    || coords.y < 0
                    || coords.y == spaces.GetLength(1)
                    || coords.z < 0
                    || coords.z == spaces.GetLength(1)
                )
                {
                    isWater = true;
                    return;
                }

                if (spacesInArea.Contains(coords))
                {
                    return;
                }

                if (spaces[coords.x, coords.y, coords.z] == 'R')
                {
                    sidesInPossibleCube++;
                }
                else
                {
                    spacesInArea.Add(coords);
                    moves.Enqueue(coords);
                }
            }

            while (moves.Any())
            {
                var (x, y, z) = moves.Dequeue();
                FindArea((x + 1, y, z));
                FindArea((x - 1, y, z));
                FindArea((x, y - 1, z));
                FindArea((x, y + 1, z));
                FindArea((x, y, z - 1));
                FindArea((x, y, z + 1));
            }

            if (isWater)
            {
                foreach (var (x, y, z) in spacesInArea)
                {
                    spaces[x, y, z] = 'W';
                }
            }
            else
            {
                foreach (var (x, y, z) in spacesInArea)
                {
                    spaces[x, y, z] = 'A';
                }

                sides -= sidesInPossibleCube;
            }
        }

        return sides;
    }

    private static (
        int sides,
        Queue<(int x, int y, int z)> possibleAirCubes,
        char[,,] spaces
    ) DoStuff(string input)
    {
        var spaces = new char[25, 25, 25];

        var cubes = new Queue<(int x, int y, int z)>();
        var possibleAirCubes = new Queue<(int x, int y, int z)>();
        foreach (var line in input.SplitLines())
        {
            var coords = line.Split(",").Select(int.Parse).ToArray();
            spaces[coords[0], coords[1], coords[2]] = 'R';
            cubes.Enqueue((coords[0], coords[1], coords[2]));
        }

        var sides = 0;

        void DoCheck((int x, int y, int z) coords)
        {
            if (coords.y == -1)
            {
                sides++;
                return;
            }

            if (spaces[coords.x, coords.y, coords.z] != 'R')
            {
                sides++;
                possibleAirCubes.Enqueue(coords);
            }
        }

        while (cubes.Any())
        {
            var (x, y, z) = cubes.Dequeue();

            DoCheck((x + 1, y, z));
            DoCheck((x - 1, y, z));
            DoCheck((x, y - 1, z));
            DoCheck((x, y + 1, z));
            DoCheck((x, y, z - 1));
            DoCheck((x, y, z + 1));
        }

        return (sides, possibleAirCubes, spaces);
    }
}
