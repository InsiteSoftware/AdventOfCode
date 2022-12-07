/*
As you finish identifying the misplaced items, the Elves come to you with another issue.

For safety, the Elves are divided into groups of three. Every Elf carries a badge that identifies their group. For efficiency, within each group of three Elves, the badge is the only item type carried by all three Elves. That is, if a group's badge is item type B, then all three Elves will have item type B somewhere in their rucksack, and at most two of the Elves will be carrying any other item type.

The problem is that someone forgot to put this year's updated authenticity sticker on the badges. All of the badges need to be pulled out of the rucksacks so the new authenticity stickers can be attached.

Additionally, nobody wrote down which item type corresponds to each group's badges. The only way to tell which item type is the right one is by finding the one item type that is common between all three Elves in each group.

Every set of three lines in your list corresponds to a single group, but each group can have a different badge item type. So, in the above example, the first group's rucksacks are the first three lines:

vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg

And the second group's rucksacks are the next three lines:

wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw

In the first group, the only item type that appears in all three rucksacks is lowercase r; this must be their badges. In the second group, their badge item type must be Z.

Priorities for these items must still be found to organize the sticker attachment efforts: here, they are 18 (r) for the first group and 52 (Z) for the second group. The sum of these is 70.

Find the item type that corresponds to the badges of each three-Elf group. What is the sum of the priorities of those item types?
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rucksack
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rucksacks = System.IO.File.ReadAllLines(@"C:\Projects\advent-code\2022\day3\input.txt");

            int[] priorities = new int[rucksacks.Length / 3];

            for (int i = 0; i < rucksacks.Length; i += 3)
            {
                string rucksack1 = rucksacks[i];
                string rucksack2 = rucksacks[i + 1];
                string rucksack3 = rucksacks[i + 2];

                int priority = 0;

                char item = (char)GetCommonCharacter(rucksack1, rucksack2, rucksack3);

                Console.WriteLine(i + " - Common item: " + item);

                if (item != '\0')
                {
                    priority = GetPriority(item);
                }

                priorities[i / 3] = priority;
            }

            Console.WriteLine("Priorities: {0}", string.Join(", ", priorities));
            Console.WriteLine("Total: {0}", priorities.Sum());
            Console.ReadLine();
        }

        //Create a method that returns the case sensitive character that appears all three strings
        static char GetCommonCharacter(string str1, string str2, string str3)
        {
            //Create a dictionary to store the character and the number of times it appears
            Dictionary<char, int> dict = new Dictionary<char, int>();

            //array of char to store the character that appear in the string
            char[] charArray = new char[str1.Length];

            //Loop through the first string
            for (int i = 0; i < str1.Length; i++)
            {
                //If the character is not in the dictionary, add it
                if (!charArray.Contains(str1[i]))
                {
                    charArray[i] = str1[i];

                    //If the character is not in the dictionary, add it
                    if (!dict.ContainsKey(str1[i]))
                    {
                        dict.Add(str1[i], 1);
                    }
                    //If the character is in the dictionary, increment the count
                    else
                    {
                        dict[str1[i]]++;
                    }
                }
                //If the character is in the dictionary, skip
                else
                {
                    continue;
                }
            }

            //array of char to store the character that appear in the string
            char[] charArray2 = new char[str2.Length];

            //Loop through the second string
            for (int i = 0; i < str2.Length; i++)
            {
                //If the character is not in the dictionary, add it
                if (!charArray2.Contains(str2[i]))
                {
                    charArray2[i] = str2[i];

                    //If the character is not in the dictionary, add it
                    if (!dict.ContainsKey(str2[i]))
                    {
                        dict.Add(str2[i], 1);
                    }
                    //If the character is in the dictionary, increment the count
                    else
                    {
                        dict[str2[i]]++;
                    }
                }
                //If the character is in the dictionary, skip
                else
                {
                    continue;
                }
            }

            //array of char to store the character that appear in the string
            char[] charArray3 = new char[str3.Length];

            //Loop through the third string
            for (int i = 0; i < str3.Length; i++)
            {
                //If the character is not in the dictionary, add it
                if (!charArray3.Contains(str3[i]))
                {
                    charArray3[i] = str3[i];
                    //If the character is not in the dictionary, add it
                    if (!dict.ContainsKey(str3[i]))
                    {
                        dict.Add(str3[i], 1);
                    }
                    //If the character is in the dictionary, increment the count
                    else
                    {
                        dict[str3[i]]++;
                    }
                }
                //If the character is in the dictionary, skip
                else
                {
                    continue;
                }
            }

            //Loop through the dictionary
            foreach (KeyValuePair<char, int> kvp in dict)
            {
                //If the count is 3, return the character
                if (kvp.Value == 3)
                {
                    return kvp.Key;
                }
            }

            //If no character appears in all three strings, return null
            return '\0';
        }

        static int GetPriority(char item)
        {
            if (item >= 'a' && item <= 'z')
            {
                return item - 'a' + 1;
            }
            else if (item >= 'A' && item <= 'Z')
            {
                return item - 'A' + 27;
            }

            return 0;
        }
    }
}