namespace Day1;

using FluentAssertions;
using NUnit.Framework;

[TestFixture]
public class Run
{
    [Test]
    public void Test()
    {
        var input = @"199
200
208
210
200
207
240
269
260
263";
        var result = DoStuff.Run(input);
        result.Should().Be(7);
    }
    
    [Test]
    public void Test2()
    {
        var input = File.ReadAllText("../../../Input.txt");
        var result = DoStuff.Run(input);
        Console.WriteLine(result);
    }
}