/*
Each Elf separates their own inventory from the previous Elf's inventory (if any) by a blank line in the input file.

var array = new string[] { "1000, 2000, 3000", "4000", "5000, 6000", "7000, 8000, 9000", "10000" };

This input represents the Calories of the food carried by five Elves:

    The first Elf is carrying food with 1000, 2000, and 3000 Calories, a total of 6000 Calories.
    The second Elf is carrying one food item with 4000 Calories.
    The third Elf is carrying food with 5000 and 6000 Calories, a total of 11000 Calories.
    The fourth Elf is carrying food with 7000, 8000, and 9000 Calories, a total of 24000 Calories.
    The fifth Elf is carrying one food item with 10000 Calories.

they'd like to know how many Calories are being carried by the Elf carrying the most Calories. In the example above, this is 24000 (carried by the fourth Elf).

Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    class Program2
    {
        static void Main2(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            var groups = input.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            
            // Loop through groups and count the value in each group
            var groupValues = new List<int>();
            foreach (var group in groups)
            {
                var lines = group.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var groupValue = 0;
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                    
                    groupValue += int.Parse(line);
                }
                groupValues.Add(groupValue);
            }

            // Find the highest value
            var highestValue = groupValues.Max();

            Console.WriteLine("Highest value: " + highestValue);
            Console.ReadLine();
        }
    }
}
