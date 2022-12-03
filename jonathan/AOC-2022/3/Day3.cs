namespace AOC_2022._3;

public static class Day3
{
    private static int GetValue(char character)
    {
        return character <= 'Z' ? character - 'A' + 27 : character - 'a' + 1;
    }
    
    public static int GetPart1Answer(string[] lines)
    {
        var badItems = new List<char>();
        foreach (var line in lines)
        {
            var part1 = line[..(line.Length / 2)];
            var part2 = line[(line.Length / 2)..];
            badItems.Add(part1.Intersect(part2).First());
        }
        
        return badItems.Select(GetValue).Sum();
    }
    
    public static int GetPart2Answer(string[] lines)
    {
        var badges = new List<char>();
        var groups = lines.Length / 3;
        for (var i = 0; i < groups; i++)
        {
            var rucksacks = lines.Skip(i * 3).Take(3).ToArray();
            badges.Add(rucksacks[0].Intersect(rucksacks[1]).Intersect(rucksacks[2]).First());
        }

        return badges.Select(GetValue).Sum();
    }
}