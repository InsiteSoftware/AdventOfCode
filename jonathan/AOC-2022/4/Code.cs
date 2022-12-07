using System.Text.RegularExpressions;

namespace AOC_2022._4;

public static class Code
{
    private static readonly Regex PairsRegex = new Regex(@"^(?<a1>\d+)-(?<a2>\d+),(?<b1>\d+)-(?<b2>\d+)$");
    
    public static int GetPart1Answer(string[] lines)
    {
        var totalOverlapping = 0;
        foreach (var line in lines)
        {
            var matches = PairsRegex.Match(line);
            (int start, int end) r1 = (Convert.ToInt32(matches.Groups["a1"].Value), Convert.ToInt32(matches.Groups["a2"].Value));
            (int start, int end) r2 = (Convert.ToInt32(matches.Groups["b1"].Value), Convert.ToInt32(matches.Groups["b2"].Value));

            totalOverlapping = r1.Includes(r2) || r2.Includes(r1) ? totalOverlapping + 1 : totalOverlapping;
        }
        
        return totalOverlapping;
    }
    
    public static int GetPart2Answer(string[] lines)
    {
        var totalOverlapping = 0;
        foreach (var line in lines)
        {
            var matches = PairsRegex.Match(line);
            (int start, int end) r1 = (Convert.ToInt32(matches.Groups["a1"].Value), Convert.ToInt32(matches.Groups["a2"].Value));
            (int start, int end) r2 = (Convert.ToInt32(matches.Groups["b1"].Value), Convert.ToInt32(matches.Groups["b2"].Value));

            totalOverlapping = r1.Overlaps(r2) ? totalOverlapping + 1 : totalOverlapping;
        }
        
        return totalOverlapping;
    }
}