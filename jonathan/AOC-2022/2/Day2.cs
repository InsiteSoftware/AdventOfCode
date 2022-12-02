namespace AOC_2022._2;

public static class Day2
{
    private enum Outcome
    {
        Lose,
        Draw,
        Win
    }
    
    private static Dictionary<char, int> Score = new()
    {
        { 'X', 1 },
        { 'Y', 2 },
        { 'Z', 3 }
    };

    private static int GetMatchScore(char theirs, char mine)
    {
        switch (theirs)
        {
            case 'A':
                return mine switch
                {
                    'X' => 3,
                    'Y' => 6,
                    'Z' => 0
                }; 
            case 'B':
                return mine switch
                {
                    'X' => 0,
                    'Y' => 3,
                    'Z' => 6
                }; 
            case 'C':
                return mine switch
                {
                    'X' => 6,
                    'Y' => 0,
                    'Z' => 3
                }; 
        }

        throw new Exception("Shit got fucky.");
    }

    private static char GetMyPlay(char theirs, Outcome outcome)
    {
        switch (theirs)
        {
            case 'A':
                return outcome switch
                {
                    Outcome.Win => 'Y',
                    Outcome.Lose => 'Z',
                    Outcome.Draw => 'X'
                }; 
            case 'B':
                return outcome switch
                {
                    Outcome.Win => 'Z',
                    Outcome.Lose => 'X',
                    Outcome.Draw => 'Y'
                }; 
            case 'C':
                return outcome switch
                {
                    Outcome.Win => 'X',
                    Outcome.Lose => 'Y',
                    Outcome.Draw => 'Z'
                }; 
        }

        throw new Exception("Shit got fucky.");
    }

    public static int GetPart1Answer(string[] lines)
    {
        var totalScore = 0;
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            var theirs = parts[0].First();
            var mine = parts[1].First();
            
            totalScore += GetMatchScore(theirs, mine) + Score[mine];
        }
        
        return totalScore;
    }
    
    public static int GetPart2Answer(string[] lines)
    {
        var totalScore = 0;
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            var theirs = parts[0].First();
            var mine = GetMyPlay(theirs, (Outcome)(parts[1].First() - 'X'));
            totalScore += GetMatchScore(theirs, mine) + Score[mine];
        }
        
        return totalScore;
    }
}