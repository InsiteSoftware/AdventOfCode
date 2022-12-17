using System.Text;

namespace AOC_2022._10;

public static class Code
{
    public static int GetPart1Answer(string[] lines)
    {
        var cycleList = new[] { 20, 60, 100, 140, 180, 220 };
        var signalStrengths = new List<int>();

        var cycle = 1;
        var registerValue = 1;

        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            var instruction = parts[0];

            var cycleAfterInstruction = cycle + 1;
            var registerValueAfterInstruction = registerValue;

            switch (instruction)
            {
                case "addx":
                    cycleAfterInstruction = cycle + 2;
                    registerValueAfterInstruction += int.Parse(parts[1]);
                    break;
            }

            var cycleSample = cycleList.FirstOrDefault(o => cycle <= o && o < cycleAfterInstruction);
            if (cycleSample != default)
            {
                signalStrengths.Add(cycleSample * registerValue);
            }

            cycle = cycleAfterInstruction;
            registerValue = registerValueAfterInstruction;
        }

        return signalStrengths.Sum();
    }

    public static void GetPart2Answer(string[] lines)
    {
        var cycle = 1;
        var registerValue = 1;
        var output = new StringBuilder();

        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            var instruction = parts[0];

            var cycleAfterInstruction = cycle + 1;
            var registerValueAfterInstruction = registerValue;

            switch (instruction)
            {
                case "addx":
                    cycleAfterInstruction = cycle + 2;
                    registerValueAfterInstruction += int.Parse(parts[1]);
                    break;
            }

            for (var i = cycle; i < cycleAfterInstruction; i++)
            {
                var currentColumn = (i - 1) % 40;
                
                if (currentColumn == 0)
                    output.Append('\n');
                
                var characterToWrite = ' ';
                if (Math.Abs(registerValue - currentColumn) <= 1)
                    characterToWrite = '#';
                
                output.Append(characterToWrite);

            }
            
            cycle = cycleAfterInstruction;
            registerValue = registerValueAfterInstruction;
        }
        
        Console.Write(output);
    }
}