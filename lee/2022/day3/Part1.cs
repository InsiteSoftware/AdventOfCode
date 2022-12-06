/*
For example, suppose you have the following list of contents from six rucksacks:

vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw

    The first rucksack contains the items vJrwpWtwJgWrhcsFMMfFFhFp, which means its first compartment contains the items vJrwpWtwJgWr, while the second compartment contains the items hcsFMMfFFhFp. The only item type that appears in both compartments is lowercase p.
    The second rucksack's compartments contain jqHRNqRjqzjGDLGL and rsFMfFZSrLrFZsSL. The only item type that appears in both compartments is uppercase L.
    The third rucksack's compartments contain PmmdzqPrV and vPwwTWBwg; the only common item type is uppercase P.
    The fourth rucksack's compartments only share item type v.
    The fifth rucksack's compartments only share item type t.
    The sixth rucksack's compartments only share item type s.

To help prioritize item rearrangement, every item type can be converted to a priority:

    Lowercase item types a through z have priorities 1 through 26.
    Uppercase item types A through Z have priorities 27 through 52.

In the above example, the priority of the item type that appears in both compartments of each rucksack is 16 (p), 38 (L), 42 (P), 22 (v), 20 (t), and 19 (s); the sum of these is 157.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rucksack
{
    class Program1
    {
        static void Main1(string[] args)
        {
            string[] rucksacks = System.IO.File.ReadAllLines(@"C:\Projects\advent-code\2022\day3\input.txt");
               
            int[] priorities = new int[rucksacks.Length];

            for (int i = 0; i < rucksacks.Length; i++)
            {
                string rucksack = rucksacks[i];
                int priority = 0;

                char item = (char)GetCommonCharacter(rucksack);
                if (item != '\0')
                {
                    priority = GetPriority(item);
                }

                priorities[i] = priority;
            }

            Console.WriteLine("Priorities: {0}", string.Join(", ", priorities));
            Console.WriteLine("Total: {0}", priorities.Sum());
            Console.ReadLine();
        }

        //Create a method that takes a string and returns the character that appears in both halves of the string.
        //If there is no such character, return null.
        public static char? GetCommonCharacter(string s)
        {
            if (s.Length % 2 != 0)
            {
                return null;
            }

            string firstHalf = s.Substring(0, s.Length / 2);
            string secondHalf = s.Substring(s.Length / 2);

            for (int i = 0; i < firstHalf.Length; i++)
            {
                char item = firstHalf[i];

                if (secondHalf.IndexOf(item) != -1)
                {
                    return item;
                }
            }

            return null;
        }

        //Create a method that takes a character and returns its priority.
        //If the character is not an item type, return -1.
        public static int GetPriority(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return c - 'a' + 1;
            }
            else if (c >= 'A' && c <= 'Z')
            {
                return c - 'A' + 27;
            }

            return -1;
        }

    }
}
