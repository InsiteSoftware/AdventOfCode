/*
The signal is a series of seemingly-random characters that the device receives one at a time.

The start of a packet is indicated by a sequence of four characters that are all different.

The device will send your subroutine a datastream buffer (your puzzle input); your subroutine needs to identify the first position where the four most recently received characters were all different. Specifically, it needs to report the number of characters from the beginning of the buffer to the end of the first such four-character marker.

For example, suppose you receive the following datastream buffer:

mjqjpqmgbljsphdztnvjfqwrcgsmlb

After the first three characters (mjq) have been received, there haven't been enough characters received yet to find the marker. The first time a marker could occur is after the fourth character is received, making the most recent four characters mjqj. Because j is repeated, this isn't a marker.

The first time a marker appears is after the seventh character arrives. Once it does, the last four characters received are jpqm, which are all different. In this case, your subroutine should report the value 7, because the first start-of-packet marker is complete after 7 characters have been processed.

Here are a few more examples:

    bvwbjplbgvbhsrlpgdmjqwftvncz: first marker after character 5
    nppdvjthqldpwncqszvftbrmjlhg: first marker after character 6
    nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg: first marker after character 10
    zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw: first marker after character 11

How many characters need to be processed before the first start-of-packet marker is detected?
*/

namespace Day25
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            int count = 0;
            int i = 0;
            while (i < input.Length)
            {
                // Check if the next 4 characters are all different
                if (input[i] != input[i + 1] && input[i] != input[i + 2] && input[i] != input[i + 3] &&
                    input[i + 1] != input[i + 2] && input[i + 1] != input[i + 3] && input[i + 2] != input[i + 3])
                {
                    // If so, we're done
                    count = i + 4;
                    break;
                }
                else
                {
                    // Otherwise, increment the count and move to the next character
                    i++;
                }
            }
            Console.WriteLine(count);

            /*
            A start-of-message marker is just like a start-of-packet marker, except it consists of 14 distinct characters rather than 4.

            Here are the first positions of start-of-message markers for all of the above examples:

                mjqjpqmgbljsphdztnvjfqwrcgsmlb: first marker after character 19
                bvwbjplbgvbhsrlpgdmjqwftvncz: first marker after character 23
                nppdvjthqldpwncqszvftbrmjlhg: first marker after character 23
                nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg: first marker after character 29
                zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw: first marker after character 26

            How many characters need to be processed before the first start-of-message marker is detected?
            */

            count = 0;
            i = 0;
            while (i < input.Length)
            {
                // send the next 14 characters to a method that checks if they're all different
                if (AreAllUnique(input.Substring(i, 14)))
                {
                    // If so, we're done
                    count = i + 14;
                    break;
                }
                else
                {
                    // Otherwise, increment and move to the next character
                    i++;
                }
            }

            Console.WriteLine(count);
            Console.ReadLine();
        }

        // Method for comparing 14 characters and returning true if they are all unique
        static bool AreAllUnique(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}