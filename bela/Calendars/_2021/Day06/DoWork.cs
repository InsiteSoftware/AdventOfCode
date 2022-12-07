namespace Calendars._2021.Day06;

public static class DoWork
{
    public static long FirstPart(string input, int days = 80)
    {
        var schoolOfFish = new long[9];
        input
            .Split(",")
            .Select(int.Parse)
            .GroupBy(o => o)
            .ToList()
            .ForEach(o =>
            {
                schoolOfFish[o.Key] = o.Count();
            });

        for (var x = 0; x < days; x++)
        {
            var newFish = schoolOfFish[0];
            for (var fishCount = 0; fishCount < schoolOfFish.Length - 1; fishCount++)
            {
                schoolOfFish[fishCount] = schoolOfFish[fishCount + 1];
            }

            schoolOfFish[6] += newFish;
            schoolOfFish[8] = newFish;
        }

        return schoolOfFish.Sum();
    }

    public static long SecondPart(string input) => FirstPart(input, 256);
}
