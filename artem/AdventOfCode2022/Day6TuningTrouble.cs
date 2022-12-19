using NUnit.Framework;

namespace AdventOfCode2022;

public class Day6TuningTrouble
{
    private class CharIndexPair
    {
        public CharIndexPair(char c, int index)
        {
            C = c;
            Index = index;
        }
        public char C { get; set; }
        public int Index { get; set; }
    };
    
    private string[] GetInput()
    {
        var lines = File.ReadLines("../../../Inputs/Day6Input.txt").ToArray();
        
        return lines;
    }

    private int GetFirstMarket(string str)
    {
        List<CharIndexPair> charWindow = new();

        for (var i = 0; i < str.Length; i++)
        {
            var match = charWindow.FirstOrDefault(pair => pair.C == str[i]);
            if (match is not null)
                charWindow = charWindow.Where(pair => pair.Index > match.Index).ToList();
            
            charWindow.Add(new CharIndexPair(str[i], i));
            
            if (charWindow.Count >= 14)
            {
                return i + 1;
            }
        }

        return 0;
    }
    
    [Test]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void SimpleTest(string input, int position)
    {
        Assert.AreEqual(position, GetFirstMarket(input));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(3037, GetFirstMarket(input.First()));
    }
}