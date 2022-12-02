// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main(string[] args)
    {
        var score = 0;

        string[] lines = System.IO.File.ReadAllLines(@"C:\projects\AdventOfCode\hudy\AdventOfCode\Day2\input.txt");

        foreach (var line in lines)
        {
            var plays = line.Split(' ');
            var opponentPlay = plays[0];
            var myPlay = plays[1];

            score += GetScore2(opponentPlay, myPlay);
        }

        Console.WriteLine(score);
    }
    static void Main2(string[] args)
    {
        // Question 1 brute force
        var score = 0;

        string[] lines = System.IO.File.ReadAllLines(@"C:\projects\AdventOfCode\hudy\AdventOfCode\Day2\input.txt");

        foreach (var line in lines)
        {
            var plays = line.Split(' ');
            var opponentPlay = plays[0];
            var myPlay = plays[1];

            score += GetScore(opponentPlay, myPlay);
        }

        Console.WriteLine(score);
    }
    
    private static int GetScore2(string theirPlay, string myPlay)
    {
        var score = 0;
        switch (myPlay)
        {
            // I lose
            case "X":
                if (theirPlay.Equals("A"))
                {
                    // I play scissors
                    score = 3;
                }
                else if(theirPlay.Equals("B"))
                {
                    // I play rock
                    score = 1;
                }
                else
                {
                    score = 2;
                }
                break;
            // I draw
            case "Y":
                if (theirPlay.Equals("A"))
                {
                    score = 4;
                } else if (theirPlay.Equals("B"))
                {
                    score = 5;
                }
                else
                {
                    score = 6;
                }
                break;
            // I win
            case "Z":
                if (theirPlay.Equals("A"))
                {
                    score = 8;
                } else if (theirPlay.Equals("B"))
                {
                    score = 9;
                }
                else
                {
                    score = 7;
                }
                break;
        }

        return score;
    }

    private static int GetScore(string theirPlay, string myPlay)
    {
        var score = 0;
        switch (myPlay)
        {
            case "X":
                if (theirPlay.Equals("C"))
                {
                    score = 7;
                }
                else if(theirPlay.Equals("A"))
                {
                    score = 4;
                }
                else
                {
                    score = 1;
                }
                break;
            case "Y":
                if (theirPlay.Equals("A"))
                {
                    score = 8;
                } else if (theirPlay.Equals("B"))
                {
                    score = 5;
                }
                else
                {
                    score = 2;
                }
                break;
            case "Z":
                if (theirPlay.Equals("B"))
                {
                    score = 9;
                } else if (theirPlay.Equals("C"))
                {
                    score = 6;
                }
                else
                {
                    score = 3;
                }
                break;
        }

        return score;
    }
}
