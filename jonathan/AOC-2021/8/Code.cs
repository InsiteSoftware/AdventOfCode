namespace AOC_2021._8;

public static class Code
{
    private static void ZeroInput(string[] parts, string pattern)
    {
        for (var i = 0; i < parts.Length; i++)
        {
            if (parts[i] == pattern)
            {
                parts[i] = string.Empty;
                return;
            }
        }
    }
    
    public static int GetPart1Answer(string[] lines)
    {        
        var numberOfOutputs = 0;
        foreach (var line in lines)
        {
            var parts = line.Split('|');
            var outputs = parts[1].Split(' ');

            numberOfOutputs += outputs.Count(o => o.Length is 2 or 3 or 4 or 7);
        }

        return numberOfOutputs;
    }

    public static long GetPart2Answer(string[] lines)
    {
        var outputValue = 0;
        foreach (var line in lines.Where(o => !string.IsNullOrEmpty(o)))
        {
            var parts = line.Split('|');
            var inputs = parts[0].Split(' ');
            var outputs = parts[1].Split(' ');

            var numbers = new string[10];
            numbers[1] = inputs.First(o => o.Length == 2);
            ZeroInput(inputs, numbers[1]);
            numbers[4] = inputs.First(o => o.Length == 4);
            ZeroInput(inputs, numbers[4]);
            numbers[7] = inputs.First(o => o.Length == 3);
            ZeroInput(inputs, numbers[7]);
            numbers[8] = inputs.First(o => o.Length == 7);
            ZeroInput(inputs, numbers[8]);
            
            // 2 ∩ 4 = 2, 2 ∩ 7 = 2
            numbers[2] = inputs.First(o => o.Length == 5
                                           && numbers[4].Intersect(o).Count() == 2
                                           && numbers[7].Intersect(o).Count() == 2);
            ZeroInput(inputs, numbers[2]);
            
            // 3 ∩ 4 = 3, 3 ∩ 7 = 3
            numbers[3] = inputs.First(o => o.Length == 5
                                           && numbers[4].Intersect(o).Count() == 3
                                           && numbers[7].Intersect(o).Count() == 3);
            ZeroInput(inputs, numbers[3]);
            
            // 5 ∩ 4 = 3, 5 ∩ 7 = 2 
            numbers[5] = inputs.First(o => o.Length == 5
                                           && numbers[4].Intersect(o).Count() == 3
                                           && numbers[7].Intersect(o).Count() == 2);
            ZeroInput(inputs, numbers[5]);
            
            // 6 ∩ 7 = 2
            numbers[6] = inputs.First(o => o.Length == 6
                                           && numbers[7].Intersect(o).Count() == 2);
            ZeroInput(inputs, numbers[6]);

            // 0 ∩ 5 = 4
            numbers[0] = inputs.First(o => o.Length == 6
                                           && numbers[5].Intersect(o).Count() == 4);
            ZeroInput(inputs, numbers[0]);
            
            // 9 ∩ 5 = 5
            numbers[9] = inputs.First(o => o.Length == 6
                                           && numbers[5].Intersect(o).Count() == 5);
            ZeroInput(inputs, numbers[9]);

            outputValue += Convert.ToInt32(outputs.Where(o => o.Trim().Length > 0).Aggregate(string.Empty, (current, output) => current + Array.IndexOf(numbers, numbers.First(o => o.Length == output.Length && o.Intersect(output).Count() == output.Length))));
        }
        
        return outputValue;
    }
}