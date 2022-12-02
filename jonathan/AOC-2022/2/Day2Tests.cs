namespace AOC_2022._2;

public class Day2Tests
{
    [Test]
    public void Part1()
    {
        var lines = File.ReadAllLines(@"2\SampleInput.txt")
            .ToArray();

        var answer = Day2.GetPart1Answer(lines);
        
        Assert.AreEqual(15, answer);
    }
    
    [Test]
    public void Part1Real()
    {
        var lines = File.ReadAllLines(@"2\RealInput.txt")
            .ToArray();
    
        var answer = Day2.GetPart1Answer(lines);
        
        Console.WriteLine(answer);
    }
    
    [Test]
    public void Part2()
    {
        var lines = File.ReadAllLines(@"2\SampleInput.txt")
            .ToArray();
    
        var answer = Day2.GetPart2Answer(lines);
        
        Assert.AreEqual(12, answer);
    }
    
    [Test]
    public void Part2Real()
    {
        var lines = File.ReadAllLines(@"2\RealInput.txt")
            .ToArray();
    
        var answer = Day2.GetPart2Answer(lines);
        
        Console.WriteLine(answer);
    }
}