namespace AOC_2021;

public class Day3Tests
{
    private string[] GetLines(string path)
    {
        return File.ReadAllLines(path)
            .ToArray();
    }
    
    [Test]
    public void Part1()
    {
        var answer = Day3.GetPart1Answer(this.GetLines(@"3\SampleInput.txt"));
        
        Console.WriteLine(answer);
        Assert.AreEqual(198, answer);
    }
    
    [Test]
    public void Part1Real()
    {
        var answer = Day3.GetPart1Answer(this.GetLines(@"3\RealInput.txt"));
        
        Console.WriteLine(answer);
    }
    
    // [Test]
    // public void Part2()
    // {
    //     var answer = Day3.GetPart2Answer(this.GetLines(@"2\SampleInput.txt"));
    //     
    //     Console.WriteLine(answer);
    //     Assert.AreEqual(900, answer);
    // }
    //
    // [Test]
    // public void Part2Real()
    // {
    //     var answer = Day3.GetPart2Answer(this.GetLines(@"2\RealInput.txt"));
    //     
    //     Console.WriteLine(answer);
    // }
}