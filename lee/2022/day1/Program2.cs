/*
By the time you calculate the answer to the Elves' question, they've already realized that the Elf carrying the most Calories of food might eventually run out of snacks.

To avoid this unacceptable situation, the Elves would instead like to know the total Calories carried by the top three Elves carrying the most Calories. That way, even if one of those Elves runs out of snacks, they still have two backups.

In the example above, the top three Elves are the fourth Elf (with 24000 Calories), then the third Elf (with 11000 Calories), then the fifth Elf (with 10000 Calories). The sum of the Calories carried by these three elves is 45000.

Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    class Program
    {
        static void Main(string[] args)
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
            var highestValue = groupValues.OrderByDescending(x => x).Take(3).Sum();

            Console.WriteLine("Highest value: " + highestValue);
            Console.ReadLine();
        }
    }
}