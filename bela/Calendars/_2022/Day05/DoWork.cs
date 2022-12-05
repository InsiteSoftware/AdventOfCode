namespace Calendars._2022.Day05;

public static class DoWork
{
    public static string FirstPart(string input, bool moveOneAtTime = true)
    {
        var lines = input.SplitLines();
        var stacks = new Stack<char>[(lines.First().Length + 1) / 4];

        void ForEachStack(Action<int> action)
        {
            for (var x = 0; x < stacks.Length; x++)
            {
                action(x);
            }
        }

        ForEachStack(x =>
        {
            stacks[x] = new Stack<char>();
        });

        var buildingStacks = true;
        foreach (var line in lines)
        {
            if (buildingStacks)
            {
                for (var x = 1; x < line.Length; x += 4)
                {
                    var next = line[x];
                    if (next == '1')
                    {
                        ForEachStack(x =>
                        {
                            stacks[x] = new Stack<char>(stacks[x]);
                        });
                        buildingStacks = false;
                        break;
                    }
                    if (next == ' ')
                    {
                        continue;
                    }
                    stacks[x / 4].Push(next);
                }
            }
            else
            {
                if (!line.StartsWith("move"))
                {
                    continue;
                }

                var moves = line.Split(' ');
                var number = int.Parse(moves[1]);
                var from = int.Parse(moves[3]) - 1;
                var to = int.Parse(moves[5]) - 1;

                if (moveOneAtTime)
                {
                    for (var x = 0; x < number; x++)
                    {
                        var moving = stacks[from].Pop();
                        stacks[to].Push(moving);
                    }
                }
                else
                {
                    var movingStack = new Stack<char>();
                    for (var x = 0; x < number; x++)
                    {
                        movingStack.Push(stacks[from].Pop());
                    }

                    while (movingStack.Count > 0)
                    {
                        stacks[to].Push(movingStack.Pop());
                    }
                }
            }
        }

        return string.Join("", stacks.Select(o => o.Pop()).ToArray());
    }

    public static string SecondPart(string input)
    {
        return FirstPart(input, false);
    }
}
