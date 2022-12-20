namespace Calendars._2022.Day15;

using System.Numerics;

public static class DoWork
{
    public static int FirstPart(string input, int row)
    {
        var sensorsAndDistances = new List<SensorBeaconData>();
        var beacons = new HashSet<Point>();

        input = input
            .Replace("Sensor at x=", "")
            .Replace(" y=", "")
            .Replace("x=", "")
            .Replace(": closest beacon is at ", ",");

        var smallestX = int.MaxValue;
        var largestX = int.MinValue;

        foreach (var line in input.SplitLines())
        {
            var inputs = line.Split(",");
            var sensor = new Point(int.Parse(inputs[0]), int.Parse(inputs[1]));
            var beacon = new Point(int.Parse(inputs[2]), int.Parse(inputs[3]));

            var distanceToBeacon = sensor.DistanceTo(beacon);

            smallestX = Math.Min(smallestX, sensor.X - distanceToBeacon);
            largestX = Math.Max(largestX, sensor.X + distanceToBeacon);

            sensorsAndDistances.Add(new(sensor, beacon, distanceToBeacon));

            beacons.Add(beacon);
        }

        var notPossibles = 0;
        for (var x = smallestX; x <= largestX; x++)
        {
            var y = row;

            if (beacons.Contains(new Point(x, y)))
            {
                continue;
            }

            foreach (var (sensor, beacon, distanceToSensor) in sensorsAndDistances)
            {
                if (distanceToSensor >= sensor.DistanceTo(x, y))
                {
                    notPossibles++;
                    break;
                }
            }
        }

        return notPossibles;
    }

    public static string SecondPart(string input, int max)
    {
        var sensorsAndDistances = new List<SensorBeaconData>();
        var beacons = new HashSet<Point>();

        input = input
            .Replace("Sensor at x=", "")
            .Replace(" y=", "")
            .Replace("x=", "")
            .Replace(": closest beacon is at ", ",");

        var smallestX = int.MaxValue;
        var largestX = int.MinValue;

        foreach (var line in input.SplitLines())
        {
            var inputs = line.Split(",");
            var sensor = new Point(int.Parse(inputs[0]), int.Parse(inputs[1]));
            var beacon = new Point(int.Parse(inputs[2]), int.Parse(inputs[3]));

            var distanceToBeacon = sensor.DistanceTo(beacon);

            smallestX = Math.Min(smallestX, sensor.X - distanceToBeacon);
            largestX = Math.Max(largestX, sensor.X + distanceToBeacon);

            sensorsAndDistances.Add(new(sensor, beacon, distanceToBeacon));

            beacons.Add(beacon);
        }

        Point? solution = null;

        void FindStuff(int startingY, int increment)
        {
            for (var y = startingY; y <= max; y += increment)
            {
                for (var x = 0; x <= max; x++)
                {
                    if (beacons.Contains(new Point(x, y)))
                    {
                        continue;
                    }

                    var foundInvalidSpace = false;
                    Point? furthestSensor = null;
                    var furthestDistance = int.MinValue;
                    foreach (var (sensor, beacon, distanceToSensor) in sensorsAndDistances)
                    {
                        var distanceTo = sensor.DistanceTo(x, y);
                        if (distanceToSensor >= distanceTo)
                        {
                            if (distanceTo > furthestDistance && sensor.X > x)
                            {
                                furthestDistance = distanceTo;
                                furthestSensor = sensor;
                            }
                            foundInvalidSpace = true;
                        }
                    }

                    if (furthestSensor != null)
                    {
                        x += (furthestSensor.X - x) * 2;
                    }

                    if (!foundInvalidSpace)
                    {
                        solution = new Point(x, y);
                    }
                }
            }
        }

        var threadCount = 16;
        var waitHandles = new WaitHandle[threadCount];
        for (var x = 0; x < threadCount; x++)
        {
            var handle = new EventWaitHandle(false, EventResetMode.ManualReset);
            var thread = new Thread(() =>
            {
                FindStuff(x, threadCount);
                handle.Set();
            });
            waitHandles[x] = handle;
            thread.Start();
        }

        WaitHandle.WaitAll(waitHandles);

        return (
            BigInteger.Multiply(new BigInteger(solution!.X), new BigInteger(4000000)) + solution!.Y
        ).ToString();
    }

    private record SensorBeaconData(Point Sensor, Point Beacon, int Distance);
}

public record Point(int X, int Y)
{
    public int DistanceTo(Point otherPoint)
    {
        return DistanceTo(otherPoint.X, otherPoint.Y);
    }

    public int DistanceTo(int x, int y)
    {
        return Math.Abs(X - x) + Math.Abs(Y - y);
    }
}
