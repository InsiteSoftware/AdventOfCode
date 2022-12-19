using NUnit.Framework;

namespace AdventOfCode2022;

public class Day4CampCleanup
{
    private string[] GetInput()
    {
        var lines = File.ReadLines("../../../Inputs/Day4Input.txt").ToArray();
        
        return lines;
    }

    private int FindFUllContains(string[] input)
    {
        var counter = 0;
        
        for (int i = 0; i < input.Length; i++)
        {
            if (IsOneContainsAnother(input[i]))
                counter++;
        }

        return counter;

        // return input.Count(IsOneContainsAnother);
    }

    private bool IsOneContainsAnother(string pair)
    {
        var borders = pair.Split(new []{',', '-'});
        var start1 = int.Parse(borders[0]);
        var end1 = int.Parse(borders[1]);
        var start2 = int.Parse(borders[2]);
        var end2 = int.Parse(borders[3]);

        return (start1 <= start2 && end1 >= start2) ||
               (start2 <= start1 && end2 >= start1);
    }
    
    [Test]
    public void SimpleTest()
    {
        var input = new[]
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8"
        };
        
        Assert.AreEqual(4, FindFUllContains(input));
    }
    
    [Test]
    public void SimpleTest1()
    {
        var input = new[] { "1-2,4-6", };
        Assert.AreEqual(0, FindFUllContains(input));
        
        input = new[] { "1-2,2-3", };
        Assert.AreEqual(1, FindFUllContains(input));

        input = new[] { "1-5,3-4", };
        Assert.AreEqual(1, FindFUllContains(input));

        input = new[] { "1-5,5-6", };
        Assert.AreEqual(1, FindFUllContains(input));

        input = new[] { "1-5,3-4", };
        Assert.AreEqual(1, FindFUllContains(input));

        input = new[] { "1-5,123-345", };
        Assert.AreEqual(0, FindFUllContains(input));

        
        input = new[] { "4-6,1-2", };
        Assert.AreEqual(0, FindFUllContains(input));
        
        input = new[] { "2-3,1-2", };
        Assert.AreEqual(1, FindFUllContains(input));

        input = new[] { "3-4,1-5", };
        Assert.AreEqual(1, FindFUllContains(input));

        input = new[] { "5-6,1-5", };
        Assert.AreEqual(1, FindFUllContains(input));

        input = new[] { "3-4,1-5", };
        Assert.AreEqual(1, FindFUllContains(input));

        input = new[] { "123-345,1-5", };
        Assert.AreEqual(0, FindFUllContains(input));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(801, FindFUllContains(input));
    }
}