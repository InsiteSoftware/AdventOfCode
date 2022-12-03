namespace AOC_2022._1;

public class Day1Tests
{
    [Test]
    public void Part1()
    {
        var lines = File.ReadAllLines(@"1\SampleInput.txt")
            .ToArray();

        var answer = Day1.GetPart1Answer(lines);
        
        Assert.AreEqual(24000, answer);
    }
    
    [Test]
    public void Part1Real()
    {
        var lines = File.ReadAllLines(@"1\RealInput.txt")
            .ToArray();

        var answer = Day1.GetPart1Answer(lines);
        
        Console.WriteLine(answer);
    }
    
    [Test]
    public void Part2()
    {
        var lines = File.ReadAllLines(@"1\SampleInput.txt")
            .ToArray();

        var answer = Day1.GetPart2Answer(lines);
        
        Assert.AreEqual(45000, answer);
    }
    
    [Test]
    public void Part2Real()
    {
        var lines = File.ReadAllLines(@"1\RealInput.txt")
            .ToArray();

        var answer = Day1.GetPart2Answer(lines);
        
        Console.WriteLine(answer);
    }
}