namespace Calendars._2022.Day11;

using System.Numerics;

public static class DoWork
{
    public static long FirstPart(string input, bool divideWorry = true, int rounds = 20)
    {
        var lines = input.SplitLines();
        var monkeys = new List<Monkey>();
        ulong testNumbers = 1;
        for (var x = 0; x < lines.Length; x += 7)
        {
            var operation = lines[x + 2];
            var add = operation.Contains("+");
            var thingie = operation.Split('+', '*')[1].Trim();
            var testNumber = ulong.Parse(lines[x + 3].Replace("  Test: divisible by ", ""));
            testNumbers *= testNumber;
            var trueMonkey = int.Parse(lines[x + 4].Replace("    If true: throw to monkey ", ""));

            var falseMonkey = int.Parse(lines[x + 5].Replace("    If false: throw to monkey ", ""));

            monkeys.Add(
                new Monkey
                {
                    Items = lines[x + 1]
                        .Replace("Starting items: ", "")
                        .Split(",")
                        .Select(o => ulong.Parse(o.Trim()))
                        .ToList(),
                    Operation = old =>
                    {
                        var number = thingie == "old" ? old : ulong.Parse(thingie);
                        return add ? old + number : old * number;
                    },
                    MoveTo = item => (item % testNumber == 0) ? trueMonkey : falseMonkey
                }
            );
        }

        for (var x = 0; x < rounds; x++)
        {
            for (var monkeyIndex = 0; monkeyIndex < monkeys.Count; monkeyIndex++)
            {
                var monkey = monkeys[monkeyIndex];
                monkey.Inspections += monkey.Items.Count;
                foreach (var item in monkey.Items)
                {
                    var newItem = monkey.Operation(item);
                    if (divideWorry)
                    {
                        newItem /= 3;
                    }
                    else
                    {
                        newItem %= testNumbers;
                    }
                    var newIndex = monkey.MoveTo(newItem);
                    monkeys[newIndex].Items.Add(newItem);
                }
                monkey.Items.Clear();
            }

            if (x is 0 or 19 or 999)
            {
                Console.WriteLine($"Round {x + 1}");
                for (var monkeyIndex = 0; monkeyIndex < monkeys.Count; monkeyIndex++)
                {
                    Console.WriteLine($"Monkey {monkeyIndex}: {monkeys[monkeyIndex].Inspections}");
                }

                Console.WriteLine();
            }
        }

        var bestTwo = monkeys
            .OrderByDescending(o => o.Inspections)
            .Take(2)
            .Select(o => o.Inspections)
            .ToArray();
        return bestTwo[0] * bestTwo[1];
    }

    public static long SecondPart(string input)
    {
        return FirstPart(input, false, 10000);
    }
}

public class Monkey
{
    public long Inspections { get; set; }
    public List<ulong> Items { get; set; }
    public Func<ulong, ulong> Operation { get; set; }
    public Func<ulong, int> MoveTo { get; set; }
}
