namespace AOC_2022._3;

public class Day3Tests
{
    [Test]
    public void Part1()
    {
        var lines = File.ReadAllLines(@"3\SampleInput.txt")
            .ToArray();

        var answer = Day3.GetPart1Answer(lines);
        
        Assert.AreEqual(157, answer);
    }
    
    [Test]
    public void Part1Real()
    {
        var lines = File.ReadAllLines(@"3\RealInput.txt")
            .ToArray();
    
        var answer = Day3.GetPart1Answer(lines);
        
        Console.WriteLine(answer);
    }
    
    [Test]
    public void Part2()
    {
        var lines = File.ReadAllLines(@"3\SampleInput.txt")
            .ToArray();
    
        var answer = Day3.GetPart2Answer(lines);
        
        Assert.AreEqual(70, answer);
    }
    
    [Test]
    public void Part2Real()
    {
        var lines = File.ReadAllLines(@"3\RealInput.txt")
            .ToArray();
    
        var answer = Day3.GetPart2Answer(lines);
        
        Console.WriteLine(answer);
    }
}