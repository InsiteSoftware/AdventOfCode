namespace AOC_2022._4;

public class Tests
{
    [Test]
    public void Part1()
    {
        var lines = File.ReadAllLines(@"4\SampleInput.txt")
            .ToArray();

        var answer = Code.GetPart1Answer(lines);
        Console.WriteLine(answer);
        Assert.AreEqual(2, answer);
    }
    
    [Test]
    public void Part1Real()
    {
        var lines = File.ReadAllLines(@"4\RealInput.txt")
            .ToArray();
    
        var answer = Code.GetPart1Answer(lines);
        
        Console.WriteLine(answer);
    }
    
    [Test]
    public void Part2()
    {
        var lines = File.ReadAllLines(@"4\SampleInput.txt")
            .ToArray();
    
        var answer = Code.GetPart2Answer(lines);
        Console.WriteLine(answer);
        Assert.AreEqual(4, answer);
    }
    
    [Test]
    public void Part2Real()
    {
        var lines = File.ReadAllLines(@"4\RealInput.txt")
            .ToArray();
    
        var answer = Code.GetPart2Answer(lines);
        
        Console.WriteLine(answer);
    }
}