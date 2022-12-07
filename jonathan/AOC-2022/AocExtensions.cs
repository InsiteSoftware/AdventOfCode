namespace AOC_2022;

public static class AocExtensions
{
    private static bool Includes(this (int start, int end) range, int number)
    {
        return number >= range.start && number <= range.end;
    }
    
    public static bool Includes(this (int start, int end) range1, (int start, int end) range2)
    {
        return range1.Includes(range2.start) && range1.Includes(range2.end);
    }
    
    public static bool Overlaps(this (int start, int end) range1, (int start, int end) range2)
    {
        return range1.Includes(range2.start) || range1.Includes(range2.end)
            || range2.Includes(range1.start) || range2.Includes(range1.end);
    }
}