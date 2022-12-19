using System.Buffers;
using System.Collections;
using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AOC_2022._15;

public static partial class Code
{
    private static Regex SensorRegex = MyRegex();

    public static int GetPart1Answer(string[] lines, int rowToCheck)
    {
        var impossibleBeacons = new HashSet<int>();
        foreach (var line in lines)
        {
            var matches = SensorRegex.Match(line);
            var sx = int.Parse(matches.Groups["sx"].Value);
            var sy = int.Parse(matches.Groups["sy"].Value);
            var bx = int.Parse(matches.Groups["bx"].Value);
            var by = int.Parse(matches.Groups["by"].Value);

            var distance = Math.Abs(sx - bx) + Math.Abs(sy - by);

            if (Math.Abs(sy - rowToCheck) <= distance)
            {
                var impossibleBeaconsLeftOrRight = Math.Abs(Math.Abs(sy - rowToCheck) - distance);

                for (var i = sx - impossibleBeaconsLeftOrRight; i <= sx + impossibleBeaconsLeftOrRight; i++)
                {
                    if (by != rowToCheck || bx != i)
                    {
                        impossibleBeacons.Add(i);
                    }
                }
            }
        }
        
        return impossibleBeacons.Count;
    }

    public static BigInteger GetPart2Answer(string[] lines, int maxDimension)
    {
        var sensors = new List<(int sx, int sy, int bx, int by, int distance)>();

        foreach (var line in lines)
        {
            var matches = SensorRegex.Match(line);
            var sx = int.Parse(matches.Groups["sx"].Value);
            var sy = int.Parse(matches.Groups["sy"].Value);
            var bx = int.Parse(matches.Groups["bx"].Value);
            var by = int.Parse(matches.Groups["by"].Value);

            var distance = Math.Abs(sx - bx) + Math.Abs(sy - by);
            sensors.Add((sx, sy, bx, by, distance));
        }

        // only need to search for points on the radius of each sensor position + distance
        // iterate over circle (diamond) + 1 of each sensor and see if it is in another known
        // beacon free area. Only one point should exist, ignore invalid points
        // 0 <= x <= maxDistance
        // 0 <= y <= maxDistance
        foreach (var sensor in sensors)
        {
            var foundPoint = (x: -1, y: -1);
            var j = sensor.distance + 1;
            for (var i = 0; i < sensor.distance + 1; i++, j--)
            {
                foundPoint = ProcessPoint((     i + sensor.sx,      j + sensor.sy), sensors, maxDimension);
                if (foundPoint.x != -1)
                    break;
                foundPoint = ProcessPoint((-1 * i + sensor.sx,      j + sensor.sy), sensors, maxDimension);
                if (foundPoint.x != -1)
                    break;
                foundPoint = ProcessPoint((     i + sensor.sx, -1 * j + sensor.sy), sensors, maxDimension);
                if (foundPoint.x != -1)
                    break;
                foundPoint = ProcessPoint((-1 * i + sensor.sx, -1 * j + sensor.sy), sensors, maxDimension);
                if (foundPoint.x != -1)
                    break;
            }

            if (foundPoint.x != -1)
            {
                return BigInteger.Multiply(new BigInteger(foundPoint.x), new BigInteger(4000000)) + foundPoint.y;
            }
        }

        return -1;
    }

    private static (int x, int y) ProcessPoint((int x, int y) point, List<(int sx, int sy, int bx, int by, int distance)> sensors, int maxDimension = 20)
    {
        if (point.x < 0 || point.y < 0 || point.x > maxDimension || point.y > maxDimension)
            return (-1, -1);

        foreach (var sensor in sensors)
        {
            var distance = Math.Abs(sensor.sx - point.x) + Math.Abs(sensor.sy - point.y);
            if (distance <= sensor.distance)
                return (-1, -1);
        }

        return (point.x, point.y);
    }

    private static int ProcessRow(int maxDimension, List<(int sx, int sy, int bx, int by, int distance)> sensors, int row)
    {
        var impossibleBeacons = ArrayPool<bool>.Shared.Rent(maxDimension + 1);
        Array.Clear(impossibleBeacons, 0, maxDimension + 1);

        try
        {
            foreach (var sensor in sensors)
            {
                if (Math.Abs(sensor.sy - row) > sensor.distance)
                    continue;

                var impossibleBeaconsLeftOrRight = Math.Abs(Math.Abs(sensor.sy - row) - sensor.distance);

                for (var j = sensor.sx - impossibleBeaconsLeftOrRight; j <= sensor.sx + impossibleBeaconsLeftOrRight; j++)
                {
                    if (j < 0 || j > maxDimension)
                        continue;

                    impossibleBeacons[j] = true;
                }
            }
            
            return impossibleBeacons.Take(maxDimension + 1).ToList().IndexOf(false);
        }
        finally
        {
            ArrayPool<bool>.Shared.Return(impossibleBeacons);
        }
    }

    [GeneratedRegex(@"Sensor at x=(?<sx>\-?\d+), y=(?<sy>\-?\d+): closest beacon is at x=(?<bx>\-?\d+), y=(?<by>\-?\d+)")]
    private static partial Regex MyRegex();
}