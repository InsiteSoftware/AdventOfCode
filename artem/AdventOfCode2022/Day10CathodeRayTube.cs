using NUnit.Framework;

namespace AdventOfCode2022;

public class Day10CathodeRayTube
{
    private Dictionary<int, int> Strengths;
    private int X;
    private int CycleCounter;

    private int GetSignalStrengths(string[] input)
    {
        Strengths = new();
        X = 1;
        CycleCounter = 1;

        for (int i = 0; i < input.Length; i++)
        {
            RunInstruction(input[i]);
        }

        return Strengths.Sum(x=> x.Value);
    }

    private void RunInstruction(string instruction)
    {
        switch (instruction)
        {
            case "noop":
                BumpCycle();
                break;
            case var add when add.StartsWith("addx "):
                AddValue(add);
                break;
        }
    }

    private void BumpCycle()
    {
        Console.Write(Math.Abs(X - CycleCounter % 40) < 2 ? '#' : '.');

        CycleCounter++;
        if((CycleCounter - 20)%40 == 0)
            Strengths.Add(CycleCounter, CycleCounter * X);

        if (CycleCounter % 40 == 0)
            Console.WriteLine();
    }

    private void AddValue(string addCommand)
    {
        var value = int.Parse(addCommand.Substring(5));

        BumpCycle();
        X += value;        
        BumpCycle();
    }
    
    private string[] GetTestInput(string inputType)
    {
        var lines = File.ReadLines($"../../../Inputs/{inputType}.txt").ToArray();
        
        return lines;
    }
    
    [Test]
    public void SimpleTest()
    {
        var input = GetTestInput("Day10TestInput");

        Assert.AreEqual(13140, GetSignalStrengths(input));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetTestInput("Day10Input");
        
        Assert.AreEqual(13680, GetSignalStrengths(input));
    }
}