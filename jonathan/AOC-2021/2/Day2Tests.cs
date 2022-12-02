namespace AOC_2021;

public class Day2Tests
{
    private (string direction, int distance)[] GetLines(string path)
    {
        return File.ReadAllLines(path)
            .Select(o =>
            {
                var parts = o.Split(' ');
                return (direction: parts[0], distance: Convert.ToInt32(parts[1]));
            })
            .ToArray();
    }
    
    [Test]
    public void Part1()
    {
        var answer = Day2.GetPart1Answer(this.GetLines(@"2\SampleInput.txt"));
        
        Console.WriteLine(answer);
        Assert.AreEqual(150, answer);
    }
    
    [Test]
    public void Part1Real()
    {
        var lines = GetLines(@"2\RealInput.txt");
    
        var answer = Day2.GetPart1Answer(lines);
        
        Console.WriteLine(answer);
    }
    
    [Test]
    public void Part2()
    {
        var answer = Day2.GetPart2Answer(this.GetLines(@"2\SampleInput.txt"));
        
        Console.WriteLine(answer);
        Assert.AreEqual(900, answer);
    }
    
    [Test]
    public void Part2Real()
    {
        var answer = Day2.GetPart2Answer(this.GetLines(@"2\RealInput.txt"));
        
        Console.WriteLine(answer);
    }
}