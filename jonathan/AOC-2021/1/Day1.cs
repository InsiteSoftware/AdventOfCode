namespace AOC_2021;

public static class Day1
{
    public static int GetPart1Answer(int[] lines)
    {
        var numIncreasing = 0;
        var previousLine = lines[0];
        foreach (var line in lines.Skip(1))
        {
            if (line > previousLine)
                numIncreasing++;

            previousLine = line;
        }

        return numIncreasing;
    }
    
    public static int GetPart2Answer(int[] lines)
    {
        var numIncreasing = 0;
        for (var i = 1; i < lines.Length - 2; i++)
        {
            var slidingWindowA = lines[i - 1] + lines[i] + lines[i + 1];
            var slidingWindowB = lines[i] + lines[i + 1] + lines[i + 2];

            if (slidingWindowB > slidingWindowA)
                numIncreasing++;
        }

        return numIncreasing;
    }
    
    
}