namespace Calendars._2022.Day16;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var (valvesByName, valvesWithFlow) = BuildValves(input);

        var possiblePaths = new Queue<PossiblePath>();
        var currentBest = 0;

        var firstPath = new PossiblePath
        {
            Pressure = 0,
            MinutesLeft = 30,
            CurrentValve = "AA",
            ValvesToVisit = valvesWithFlow.Select(o => o.Name).ToList()
        };

        firstPath.CalculateTheoreticalBest(valvesByName);
        possiblePaths.Enqueue(firstPath);

        while (possiblePaths.Any())
        {
            var possiblePath = possiblePaths.Dequeue();
            foreach (var valveToVisit in possiblePath.ValvesToVisit)
            {
                var newPath = new PossiblePath
                {
                    MinutesLeft =
                        possiblePath.MinutesLeft
                        - valvesByName[possiblePath.CurrentValve].DistancesTo[valveToVisit]
                        - 1,
                    CurrentValve = valveToVisit,
                    ValvesToVisit = possiblePath.ValvesToVisit
                        .Where(o => o != valveToVisit)
                        .ToList()
                };
                newPath.Pressure =
                    possiblePath.Pressure
                    + (newPath.MinutesLeft * valvesByName[valveToVisit].FlowRate);
                newPath.CalculateTheoreticalBest(valvesByName);

                if (newPath.TheoreticalBest < currentBest)
                {
                    continue;
                }
                currentBest = Math.Max(currentBest, newPath.Pressure);
                possiblePaths.Enqueue(newPath);
            }
        }

        return currentBest;
    }

    public static int SecondPart(string input)
    {
        var (valvesByName, valvesWithFlow) = BuildValves(input);

        var possiblePaths = new Queue<PossiblePath>();
        var currentBest = 0;

        var firstPath = new PossiblePath
        {
            Pressure = 0,
            MinutesLeft = 30,
            CurrentValve = "AA",
            ElephantValve = "AA",
            ValvesToVisit = valvesWithFlow.Select(o => o.Name).ToList()
        };

        firstPath.CalculateTheoreticalBest(valvesByName);
        possiblePaths.Enqueue(firstPath);

        while (possiblePaths.Any())
        {
            var possiblePath = possiblePaths.Dequeue();
            // need separate minutes for you and elephant?
            // for (var x = 0; x < possiblePath.ValvesToVisit.Count - 1; x++)
            // {
            //     for (var y = x + 1; y < possiblePath.ValvesToVisit; y++)
            //     {
            //         var newPath = new PossiblePath
            //         {
            //             MinutesLeft =
            //                 possiblePath.MinutesLeft
            //                 - valvesByName[possiblePath.CurrentValve].DistancesTo[valveToVisit]
            //                 - 1,
            //             CurrentValve = valveToVisit,
            //             ValvesToVisit = possiblePath.ValvesToVisit
            //                 .Where(o => o != valveToVisit)
            //                 .ToList()
            //         };
            //         newPath.Pressure =
            //             possiblePath.Pressure
            //             + (newPath.MinutesLeft * valvesByName[valveToVisit].FlowRate);
            //         newPath.CalculateTheoreticalBest(valvesByName);
            //
            //         if (newPath.TheoreticalBest < currentBest)
            //         {
            //             continue;
            //         }
            //         currentBest = Math.Max(currentBest, newPath.Pressure);
            //         possiblePaths.Enqueue(newPath);
            //     }
            // }
        }

        return currentBest;
    }

    private static (Dictionary<string, Valve>, List<Valve>) BuildValves(string input)
    {
        input = input
            .Replace("Valve ", "")
            .Replace(" has flow rate=", ",")
            .Replace("; tunnels lead to valves ", ",")
            .Replace("; tunnel leads to valve ", ",")
            .Replace(", ", ",");

        var valvesByName = new Dictionary<string, Valve>();

        foreach (var line in input.SplitLines())
        {
            var info = line.Split(",");
            var node = new Valve { Name = info[0], FlowRate = int.Parse(info[1]) };

            for (var x = 2; x < info.Length; x++)
            {
                node.ConnectsTo.Add(info[x]);
            }

            valvesByName.Add(node.Name, node);
        }

        void FillDistances(Valve startingVale)
        {
            foreach (var (name, _) in valvesByName)
            {
                if (name == startingVale.Name)
                {
                    continue;
                }
                startingVale.DistancesTo.Add(name, int.MaxValue);
            }

            var moves = new Queue<(Valve valve, int steps)>();
            moves.Enqueue((startingVale, 0));

            while (moves.Any())
            {
                var (current, steps) = moves.Dequeue();
                foreach (var valveName in current.ConnectsTo)
                {
                    if (
                        valveName == startingVale.Name
                        || steps + 1 >= startingVale.DistancesTo[valveName]
                    )
                    {
                        continue;
                    }

                    startingVale.DistancesTo[valveName] = steps + 1;
                    moves.Enqueue((valvesByName[valveName], steps + 1));
                }
            }
        }

        FillDistances(valvesByName["AA"]);
        var valvesWithFlow = new List<Valve>();
        foreach (var (_, valve) in valvesByName)
        {
            if (valve.FlowRate == 0)
            {
                continue;
            }

            valvesWithFlow.Add(valve);
            FillDistances(valve);
        }

        return (valvesByName, valvesWithFlow);
    }

    private class PossiblePath
    {
        public int Pressure { get; set; }
        public int MinutesLeft { get; set; }
        public List<string> ValvesToVisit { get; set; }
        public string CurrentValve { get; set; }
        public string ElephantValve { get; set; }
        public int TheoreticalBest { get; set; }

        public void CalculateTheoreticalBest(Dictionary<string, Valve> valvesByName)
        {
            this.TheoreticalBest = this.Pressure;
            foreach (var valve in this.ValvesToVisit)
            {
                this.TheoreticalBest += MinutesLeft * valvesByName[valve].FlowRate;
            }
        }
    }

    private class Valve
    {
        public string Name { get; set; }
        public int FlowRate { get; set; }
        public List<string> ConnectsTo { get; set; } = new();
        public Dictionary<string, int> DistancesTo { get; set; } = new();
    }
}
