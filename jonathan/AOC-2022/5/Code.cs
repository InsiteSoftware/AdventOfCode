using System.Text.RegularExpressions;

namespace AOC_2022._5;

public static class Code
{
    private static readonly Regex MoveRegex = new(@"move (?<count>\d+) from (?<src>\d+) to (?<dest>\d+)");
    
    public static string GetPart1Answer(string[] lines)
    {
        var numStacks = Convert.ToInt32(Math.Ceiling(lines[0].Length / 4.0));
        var stacks = new LinkedList<char>[numStacks];
        foreach (var line in lines)
        {
            if (line.Contains('['))
            {
                for (var i = 0; i < numStacks; i++)
                {
                    stacks[i] ??= new LinkedList<char>();
                    var letter = line[i * 4 + 1];
                    if (letter != ' ')
                    {
                        stacks[i].AddFirst(letter);
                    }
                }
            }

            if (line.StartsWith("move"))
            {
                var m = MoveRegex.Match(line);
                var count = Convert.ToInt32(m.Groups["count"].Value);
                var src = Convert.ToInt32(m.Groups["src"].Value) - 1;
                var dest = Convert.ToInt32(m.Groups["dest"].Value) - 1;
                for (var i = 0; i < count; i++)
                {
                    stacks[dest].AddLast(stacks[src].TakeLast(1).First());
                    stacks[src].RemoveLast();
                }
            }
        }
        
        return new string(stacks.Select(o => o.Last()).ToArray());
    }
    
    public static string GetPart2Answer(string[] lines)
    {
        var numStacks = Convert.ToInt32(Math.Ceiling(lines[0].Length / 4.0));
        var stacks = new LinkedList<char>[numStacks];
        foreach (var line in lines)
        {
            if (line.Contains('['))
            {
                for (var i = 0; i < numStacks; i++)
                {
                    stacks[i] ??= new LinkedList<char>();
                    var letter = line[i * 4 + 1];
                    if (letter != ' ')
                    {
                        stacks[i].AddFirst(letter);
                    }
                }
            }

            if (line.StartsWith("move"))
            {
                var m = MoveRegex.Match(line);
                var count = Convert.ToInt32(m.Groups["count"].Value);
                var src = Convert.ToInt32(m.Groups["src"].Value) - 1;
                var dest = Convert.ToInt32(m.Groups["dest"].Value) - 1;
                var movingStack = stacks[src].TakeLast(count).ToArray();
                Enumerable.Range(0, count).ToList().ForEach(o => stacks[src].RemoveLast());
                foreach (var letter in movingStack)
                {
                    stacks[dest].AddLast(letter);
                }
            }
        }
        
        return new string(stacks.Select(o => o.Last()).ToArray());
    }
}