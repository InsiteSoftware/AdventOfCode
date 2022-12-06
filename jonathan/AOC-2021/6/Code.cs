namespace AOC_2021._6;

public static class Code
{
    public static int GetPart1Answer(string[] lines)
    {
        var fish = lines[0].Split(",").Select(o => Convert.ToInt32(o)).ToList();

        for (var day = 0; day < 80; day++)
        {
            var fishCount = fish.Count;
            for (var i = 0; i < fishCount; i++)
            {
                if (fish[i] == 0)
                {
                    fish[i] = 6;
                    fish.Add(8);
                }
                else
                    fish[i]--;
            }
            
            // Console.WriteLine($"Day {day:D2} - {fish.Count} -- {string.Join(",", fish)}");
        }
        
        return fish.Count;
    }

    public static long GetPart2Answer(string[] lines)
    {
        var fish = new long[9];
        foreach (var num in lines[0].Split(",").Select(o => Convert.ToInt32(o)))
        {
            fish[num]++;
        }

        for (var day = 0; day < 256; day++)
        {
            var newFish = fish[0];
            for (var i = 0; i < 8; i++)
            {
                fish[i] = fish[i + 1];
            }

            fish[8] = newFish;
            fish[6] += newFish;
        }
        
        return fish.Sum();
    }
}