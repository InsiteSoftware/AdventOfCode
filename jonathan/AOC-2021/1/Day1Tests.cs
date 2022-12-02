namespace AOC_2021;

public class Day1Tests
{
    [Test]
    public void Part1()
    {
        var lines = File.ReadAllLines(@"1\SampleInput.txt")
            .Select(o => Convert.ToInt32(o))
            .ToArray();

        var answer = Day1.GetPart1Answer(lines);
        
        Assert.AreEqual(7, answer);
    }
    
    [Test]
    public void Part1Real()
    {
        var lines = File.ReadAllLines(@"1\RealInput.txt")
            .Select(o => Convert.ToInt32(o))
            .ToArray();

        var answer = Day1.GetPart1Answer(lines);
        
        Console.WriteLine(answer);
    }
    
    [Test]
    public void Part2()
    {
        var lines = File.ReadAllLines(@"1\SampleInput.txt")
            .Select(o => Convert.ToInt32(o))
            .ToArray();

        var answer = Day1.GetPart2Answer(lines);
        
        Assert.AreEqual(5, answer);
    }
    
    [Test]
    public void Part2Real()
    {
        var lines = File.ReadAllLines(@"1\RealInput.txt")
            .Select(o => Convert.ToInt32(o))
            .ToArray();

        var answer = Day1.GetPart2Answer(lines);
        
        Console.WriteLine(answer);
    }
}