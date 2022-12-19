using NUnit.Framework;

namespace AdventOfCode2022;

public class Day3RucksackReorganization
{
    private string[] GetInput()
    {
        var lines = File.ReadLines("../../../Inputs/Day3Input.txt").ToArray();
        
        return lines;
    }

    private int CalculatePriorities(string[] input)
    {
        var result = 0;
        
        for (var i = 0; i < input.Length - 2; i+=3)
        {
            var c = FindMatching(input[i], input[i+1], input[i+2]);
            result += GetCharScore(c);
        }
        return result;
    }

    private char FindMatching(string str1, string str2, string str3)
    {
        var charDict = new Dictionary<char, int>();

        for (var i = 0; i < str1.Length; i++)
        {
            if(!charDict.ContainsKey(str1[i]))
                charDict.Add(str1[i], 1);
        }

        for (var i = 0; i < str2.Length; i++)
        {
            if (charDict.ContainsKey(str2[i]))
                charDict[str2[i]] = 2;
        }
        
        for (var i = 0; i < str3.Length; i++)
        {
            if (charDict.ContainsKey(str3[i]) && charDict[str3[i]] == 2)
                return str3[i];
        }

        throw new AggregateException($"no maches found for str1 = {str1} str2 = {str2} str3 = {str3} ");
        // return '?';
    }

    private int GetCharScore(char c)
    {
        return c > 'a' ? c - 'a' + 1 : c - 'A' + 27;
    }
    
    [Test]
    public void SimpleTest()
    {
        var input = new[]
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };
        
        Assert.AreEqual(70, CalculatePriorities(input));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(2497, CalculatePriorities(input));
    }
}