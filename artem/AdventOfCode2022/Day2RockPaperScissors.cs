using NUnit.Framework;

namespace AdventOfCode2022;

public class Day2RockPaperScissors
{
    private string[] GetInput()
    {
        var lines = File.ReadLines("../../../Inputs/Day2Input.txt").ToArray();
        
        return lines;
    }

    private int CalculateScore(string[] input)
    {
        return input.Sum(CalculateGameRound);
    }

    private int CalculateGameRound(string gameInput)
    {
        return GameScore(gameInput[2]) + ShapeScore(gameInput[0], gameInput[2]);
    }

    private int GameScore(char c) => c switch
    {
        'X' => 0,
        'Y' => 3,
        'Z' => 6,
        _ => throw new ArgumentOutOfRangeException(nameof(c), $"Not expected direction value: {c}"),
    };

    private int ShapeScore(char first, char second) => (first, second) switch
    {
        ('A', 'X') => 3,
        ('A', 'Y') => 1,
        ('A', 'Z') => 2,
        ('B', 'X') => 1,
        ('B', 'Y') => 2,
        ('B', 'Z') => 3,
        ('C', 'X') => 2,
        ('C', 'Y') => 3,
        ('C', 'Z') => 1,
        (_, _) => throw new ArgumentOutOfRangeException(),
    };
    
    [Test]
    public void SimpleTest()
    {
        var input = new[]
        {
            "A Y",
            "B X",
            "C Z"
        };
        
        Assert.AreEqual(12, CalculateScore(input));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(12316, CalculateScore(input));
    }
}