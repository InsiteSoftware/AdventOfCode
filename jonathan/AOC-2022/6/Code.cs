using System.Text.RegularExpressions;

namespace AOC_2022._6;

public static class Code
{
    public static int GetPart1Answer(string[] lines)
    {
        const int uniqueLength = 4;
        var buffer = new char[uniqueLength];

        var index = 0;
        for (var i = 0; index < uniqueLength || buffer.Distinct().Count() != uniqueLength; i = ++i % uniqueLength)
        {
            buffer[i] = lines[0][index];
            index++;
        }
        
        return index;
    }

    public static int GetPart2Answer(string[] lines)
    {
        const int uniqueLength = 14;
        var buffer = new char[uniqueLength];

        var index = 0;
        for (var i = 0; index < uniqueLength || buffer.Distinct().Count() != uniqueLength; i = ++i % uniqueLength)
        {
            buffer[i] = lines[0][index];
            index++;
        }
        
        return index;
    }
}