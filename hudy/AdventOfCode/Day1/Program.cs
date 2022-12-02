// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

string[] lines = System.IO.File.ReadAllLines(@"C:\projects\AdventOfCode\hudy\AdventOfCode\Day1\input.txt");
var elfTotal = 0;
var highestTotal = 0;
var elves = new List<int>();
var currentElf = 0;
// Display the file contents by using a foreach loop.
foreach (string line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        currentElf += 1;
    }
    else
    {
        if (elves.Count <= currentElf)
        {
            elves.Add(0);
        }
        elves[currentElf] += Convert.ToInt32(line);
    }
}

elves.Sort();
elves.Reverse();

Console.WriteLine(elves[0]);

Console.WriteLine(elves[0] + elves[1] + elves[2]);
