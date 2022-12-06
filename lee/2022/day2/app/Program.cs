/*
For example, suppose you were given the following strategy guide:

A Y
B X
C Z

This strategy guide predicts and recommends the following:

    In the first round, your opponent will choose Rock (A), and you should choose Paper (Y). This ends in a win for you with a score of 8 (2 because you chose Paper + 6 because you won).
    In the second round, your opponent will choose Paper (B), and you should choose Rock (X). This ends in a loss for you with a score of 1 (1 + 0).
    The third round is a draw with both players choosing Scissors, giving you a score of 3 + 3 = 6.

In this example, if you were to follow the strategy guide, you would get a total score of 15 (8 + 1 + 6).
*/

namespace advent_code_day2
{
    class Program2
    {
        static void Main2(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"C:\Projects\advent-code\2022\day2\input.txt");
            int score = 0;
            foreach (string line in input)
            {
                string[] split = line.Split(' ');
                string opponent = split[0];
                string player = split[1];

                if (opponent == "A" && player == "X")
                {
                    score += 4;
                }
                else if (opponent == "B" && player == "Y")
                {
                    score += 5;
                }
                else if (opponent == "C" && player == "Z")
                {
                    score += 6;
                }
                else if (opponent == "B" && player == "X")
                {
                    score += 1;
                }
                else if (opponent == "C" && player == "Y")
                {
                    score += 2;
                }
                else if (opponent == "A" && player == "Z")
                {
                    score += 3;
                }
                else if (opponent == "C" && player == "X")
                {
                    score += 7;
                }
                else if (opponent == "A" && player == "Y")
                {
                    score += 8;
                }
                else if (opponent == "B" && player == "Z")
                {
                    score += 9;
                }
            }
            Console.WriteLine(score);
            Console.ReadLine();
        }
    }
}

