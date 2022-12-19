using NUnit.Framework;

namespace AdventOfCode2022;

public class Day13DistressSignal
{
    private class Signal
    {
        public Signal[] listOfVal { get; set; }
        public int[] vals { get; set; }
    }
    
    
    private List<string> GetInput()
    {
        var lines = File.ReadLines("../../../Inputs/Day13Input.txt").ToList();
        lines.Add(string.Empty);
        return lines;
    }

    private string etalon1 = "[[2]]";
    private string etalon2 = "[[6]]";
    
    private int SumRightIndexes(List<string> input)
    {
        var index1 = input.Where(s => s.Length > 0).Count(s => ComparePair(s, etalon1)) + 1;
        var index2 = input.Where(s => s.Length > 0).Count(s => ComparePair(s, etalon2)) + 2;

        return index1 * index2;
    }
    
    private bool ComparePair(string left, string right)
    {
        var il = 0;
        var ir = 0;
        
        do
        {
            var lnext = ReadNext(left, ref il);
            var rnext = ReadNext(right, ref ir);

            il++;
            ir++;
            
            if (lnext < rnext)
            {
                return true;
            }
            else if (lnext > rnext)
            {
                return false;
            }

        } while (il < left.Length && ir < right.Length);

        return left.Length < right.Length;
        
        throw new ArgumentException($"can't compare pair {left} and {right}");
    }

    private int ReadNext(string str, ref int i)
    {
        if (i >= str.Length)
            return int.MinValue;
        
        switch (str[i])
        {
            case '[':
            case ',':
                i++;
                return ReadNext(str, ref i);
            
            case ']':
                return int.MinValue;
            
            case var digit when Char.IsDigit(str[i]):
                int number = digit - '0';
                while (Char.IsDigit(str[i + 1]))
                {
                    i++;
                    number = number * 10 + (str[i] - '0');
                }

                return number;
            
            default:
                throw new ArgumentException($"can't read next from str = {str} and index = {i}");
        }
    }
    
    [Test]
    public void SimpleTest()
    {
        var input = new List<string>()
        {
            "[1,1,3,1,1]",
            "[1,1,5,1,1]",
            "",
            "[[1],[2,3,4]]",
            "[[1],4]",
            "",
            "[9]",
            "[[8,7,6]]",
            "",
            "[[4,4],4,4]",
            "[[4,4],4,4,4]",
            "",
            "[7,7,7,7]",
            "[7,7,7]",
            "",
            "[]",
            "[3]",
            "",
            "[[[]]]",
            "[[]]",
            "",
            "[1,[2,[3,[4,[5,6,7]]]],8,9]",
            "[1,[2,[3,[4,[5,6,0]]]],8,9]",
        };

        Assert.AreEqual(140, SumRightIndexes(input));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(20570, SumRightIndexes(input));
    }
}