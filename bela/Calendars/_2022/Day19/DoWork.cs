namespace Calendars._2022.Day19;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var blueprints = new List<Blueprint>();
        var blueprintId = 1;
        foreach (var line in input.SplitLines().Select(SanitizeLine))
        {
            var inputs = line.Split(",").Select(int.Parse).ToArray();
            blueprints.Add(
                new Blueprint
                {
                    Id = blueprintId,
                    OreRobotOreCost = inputs[0],
                    ClayRobotOreCost = inputs[1],
                    ObsidianRobotOreCost = inputs[2],
                    ObsidianRobotClayCost = inputs[3],
                    GeodeRobotOreCost = inputs[4],
                    GeodeRobotObsidianCost = inputs[5]
                }
            );

            blueprintId++;
        }

        foreach (var blueprint in blueprints)
        {
            var plan = new Plan();
            while (plan.MinutesLeft > 0)
            {
                Console.WriteLine($"== Minute {25 - plan.MinutesLeft} ==");

                var addGeode = false;

                if (
                    plan.Ore >= blueprint.GeodeRobotOreCost
                    && plan.Obsidian >= blueprint.GeodeRobotObsidianCost
                )
                {
                    Console.WriteLine("Building Geodebot");
                    addGeode = true;
                    plan.Ore -= blueprint.GeodeRobotOreCost;
                    plan.Obsidian -= blueprint.GeodeRobotObsidianCost;
                }

                var addObsidian = false;
                if (
                    plan.Ore >= blueprint.ObsidianRobotOreCost
                    && plan.Clay >= blueprint.ObsidianRobotClayCost
                )
                {
                    Console.WriteLine("Building Obsidianbot");
                    addObsidian = true;
                    plan.Ore -= blueprint.ObsidianRobotOreCost;
                    plan.Clay -= blueprint.ObsidianRobotClayCost;
                }

                var addClay = false;
                if (plan.Ore >= blueprint.ClayRobotOreCost)
                {
                    Console.WriteLine("Building Claybot");
                    addClay = true;
                    plan.Ore -= blueprint.ClayRobotOreCost;
                }

                plan.Ore += plan.OreRobots;
                plan.Clay += plan.ClayRobots;
                plan.Obsidian += plan.ObsidianRobots;
                plan.Geode += plan.GeodeRobots;

                Console.WriteLine(
                    $"You now have {plan.Ore} ore, {plan.Clay} clay, {plan.Obsidian} obsidian, and {plan.Geode} geode"
                );
                Console.WriteLine();

                if (addGeode)
                {
                    plan.GeodeRobots++;
                }

                if (addObsidian)
                {
                    plan.ObsidianRobots++;
                }

                if (addClay)
                {
                    plan.ClayRobots++;
                }

                plan.MinutesLeft--;
            }

            blueprint.MostGeodes = plan.Geode;
        }

        return blueprints.Sum(o => o.Id * o.MostGeodes);
    }

    private static string SanitizeLine(string line)
    {
        line = line.Substring(line.IndexOf(":") + 2)
            .Replace("Each ore robot costs ", "")
            .Replace(" ore. Each clay robot costs ", ",")
            .Replace(" ore. Each obsidian robot costs ", ",")
            .Replace(" ore and ", ",")
            .Replace(" clay. Each geode robot costs ", ",")
            .Replace(" obsidian.", "");

        return line;
    }

    public static int SecondPart(string input)
    {
        foreach (var line in input.SplitLines())
        {
            // stuff
        }

        return 0;
    }
}

public class Plan
{
    public int MinutesLeft = 24;
    public int OreRobots = 1;
    public int Ore;
    public int ClayRobots;
    public int Clay;
    public int ObsidianRobots;
    public int Obsidian;
    public int GeodeRobots;
    public int Geode;
}

public class Blueprint
{
    public int OreRobotOreCost;
    public int ClayRobotOreCost;
    public int ObsidianRobotOreCost;
    public int ObsidianRobotClayCost;
    public int GeodeRobotOreCost;
    public int GeodeRobotObsidianCost;
    public int Id;
    public int MostGeodes;
}
