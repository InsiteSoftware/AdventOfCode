using System.Text.RegularExpressions;

namespace AOC_2022._10;

public class Tests
{
    private static string Day => Regex.Match(typeof(Tests).Namespace!, @"AOC_(?<year>\d+)\._(?<day>\d+)").Groups["day"].Value;
    
    [Test]
    public void Part1()
    {
        var lines = File.ReadAllLines($@"{Day}\SampleInput.txt")
            .ToArray();

        var answer = Code.GetPart1Answer(lines);
        Console.WriteLine(answer);
        Assert.That(answer, Is.EqualTo(13140));
    }
    
    [Test]
    public void Part1Real()
    {
        var lines = File.ReadAllLines($@"{Day}\RealInput.txt")
            .ToArray();
    
        var answer = Code.GetPart1Answer(lines);
        
        Console.WriteLine(answer);
    }
    
    [Test]
    public void Part2()
    {
        var lines = File.ReadAllLines($@"{Day}\SampleInput.txt")
            .ToArray();
    
        Code.GetPart2Answer(lines);
    }
    
    [Test]
    public void Part2Real()
    {
        var lines = File.ReadAllLines($@"{Day}\RealInput.txt")
            .ToArray();
    
        Code.GetPart2Answer(lines);
    }
}
