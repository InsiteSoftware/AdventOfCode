namespace AOC_2022._1;

public static class Day1
{
    public static int GetPart1Answer(string[] lines)
    {
        var totalCalories = 0;
        var maxCalories = 0;
        foreach (var line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                totalCalories += Convert.ToInt32(line);
            }
            else
            {
                maxCalories = totalCalories > maxCalories ? totalCalories : maxCalories;
                totalCalories = 0;
            }
        }
        
        maxCalories = totalCalories > maxCalories ? totalCalories : maxCalories;
        
        return maxCalories;
    }
    
    public static int GetPart2Answer(string[] lines)
    {
        var totalCalories = 0;
        var maxCalories = new List<int>();
        foreach (var line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                totalCalories += Convert.ToInt32(line);
            }
            else
            {
                maxCalories.Add(totalCalories);
                totalCalories = 0;
            }
        }
        maxCalories.Add(totalCalories);

        return maxCalories.OrderDescending().Take(3).Sum();
    }
}