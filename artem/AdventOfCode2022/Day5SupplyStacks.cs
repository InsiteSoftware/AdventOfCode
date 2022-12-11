using NUnit.Framework;

namespace AdventOfCode2022;

public class Day5SupplyStacks
{
    private string[] GetInput()
    {
        var lines = File.ReadLines("../../../Inputs/Day5Input.txt").ToArray();
        
        return lines;
    }

    private List<Stack<char>> containers;

    private string GetTopCrates(string[] crates, string[] operations)
    {
        containers = new List<Stack<char>>(crates.Length);

        FillContainers(crates);
        
        var result = MakeOperations(operations);

        return result;
    }

    private void FillContainers(string[] crates)
    {
        for (var i = 0; i < crates.Length; i++)
        {
            for (var j = 0; j < crates[i].Length; j++)
            {
                if (containers.Count <= i)
                {
                    containers.Add(new Stack<char>());
                }
                containers[i].Push(crates[i][j]);
            }
        }
    }

    private string MakeOperations(string[] operations)
    {
        for (int i = 0; i < operations.Length; i++)
        {
            var tokens = operations[i].Split(" ");
            var count = int.Parse(tokens[1]);
            var source = int.Parse(tokens[3]) - 1;
            var target = int.Parse(tokens[5]) - 1;

            var mediator = new Stack<char>();
            for (int j = 0; j < count; j++)
            {
                var crate = containers[source].Pop();
                mediator.Push(crate);
            }
            for (int j = 0; j < count; j++)
            {
                var crate = mediator.Pop();
                containers[target].Push(crate);
            }
        }

        var result = containers.Aggregate(string.Empty, (current, t) => current + t.Peek());

        return result;
    }
    
    [Test]
    public void SimpleTest()
    {
        var crates = new[]
        {
            "ZN",
            "MCD",
            "P",
        };

        var operations = new[]
        {
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        };
        
        Assert.AreEqual("MCD", GetTopCrates(crates, operations));
    }
    
    [Test]
    public void PassingTest()
    {
        var crates = new[]
        {
            "GTRW",
            "GCHPMSVW",
            "CLTSGM",
            "JHDMWRF",
            "PQLHSWFJ",
            "PJDNFMS",
            "ZBDFGCSJ",
            "RTB",
            "HNWLC",
        };
        
        var operations = GetInput();
        
        Assert.AreEqual("LVMRWSSPZ", GetTopCrates(crates, operations));
    }
}