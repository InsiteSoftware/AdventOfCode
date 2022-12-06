/*
The Elf finishes helping with the tent and sneaks back over to you. "Anyway, the second column says how the round needs to end: X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win. Good luck!"

The total score is still calculated in the same way, but now you need to figure out what shape to choose so the round ends as indicated. The example above now goes like this:

    In the first round, your opponent will choose Rock (A), and you need the round to end in a draw (Y), so you also choose Rock. This gives you a score of 1 + 3 = 4.
    In the second round, your opponent will choose Paper (B), and you choose Rock so you lose (X) with a score of 1 + 0 = 1.
    In the third round, you will defeat your opponent's Scissors with Rock for a score of 1 + 6 = 7.

Now that you're correctly decrypting the ultra top secret strategy guide, you would get a total score of 12.

Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide?
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_code_day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\Projects\advent-code\2022\day2\input.txt");
            int score = 0;
            foreach (string line in input)
            {
                string[] split = line.Split(' ');
                string opponent = split[0];
                string player = split[1];

                if(player == "X")
                {
                    if(opponent == "A")
                    {
                        score += 3;
                    }
                    else if(opponent == "B")
                    {
                        score += 1;
                    }
                    else if(opponent == "C")
                    {
                        score += 2;
                    }
                }
                else if(player == "Y")
                {
                    if(opponent == "A")
                    {
                        score += 4;
                    }
                    else if(opponent == "B")
                    {
                        score += 5;
                    }
                    else if(opponent == "C")
                    {
                        score += 6;
                    }
                }
                else if(player == "Z")
                {
                    if(opponent == "A")
                    {
                        score += 8;
                    }
                    else if(opponent == "B")
                    {
                        score += 9;
                    }
                    else if(opponent == "C")
                    {
                        score += 7;
                    }
                }
            }
            Console.WriteLine(score);
        }
    }
}