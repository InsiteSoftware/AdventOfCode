using System.Numerics;
using System.Text.RegularExpressions;

namespace AOC_2022._15;

public class Tests
{
    private static string Day => Regex.Match(typeof(Tests).Namespace!, @"AOC_(?<year>\d+)\._(?<day>\d+)").Groups["day"].Value;
    
    [Test]
    public void Part1()
    {
        var lines = File.ReadAllLines($@"{Day}\SampleInput.txt")
            .ToArray();

        var answer = Code.GetPart1Answer(lines, 10);
        Console.WriteLine(answer);
        Assert.That(answer, Is.EqualTo(26));
    }
    
    [Test]
    public void Part1Real()
    {
        var lines = File.ReadAllLines($@"{Day}\RealInput.txt")
            .ToArray();
    
        var answer = Code.GetPart1Answer(lines, 2000000);
        
        Console.WriteLine(answer);
    }
    
    [Test]
    public void Part2()
    {
        var lines = File.ReadAllLines($@"{Day}\SampleInput.txt")
            .ToArray();
    
        var answer = Code.GetPart2Answer(lines, 20);
        Console.WriteLine(answer);
        Assert.That(answer, Is.EqualTo(new BigInteger(56000011)));
    }
    
    [Test]
    public void Part2Real()
    {
        var lines = File.ReadAllLines($@"{Day}\RealInput.txt")
            .ToArray();
    
        var answer = Code.GetPart2Answer(lines, 4000000);
        
        Console.WriteLine(answer);
    }
}
