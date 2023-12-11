
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

public static class StringExtensions
{
    private static Dictionary<string, int> words = new Dictionary<string, int>{
        {"one", 1 },
        {"two", 2},
        {"three", 3},
        {"four", 4},
        {"five", 5},
        {"six", 6},
        {"seven", 7},
        {"eight", 8},
        {"nine", 9}
};

    private static Dictionary<string, int> reversedWords = ReverseTheWords();

    private static Dictionary<string, int> ReverseTheWords()
    {
        var reversed = new Dictionary<string, int>();

        foreach (var (number, digit) in words)
        {
            reversed.Add(string.Concat(number.Reverse()), digit);
        }

        return reversed;
    }

    private static Trie trie = Trie.Build(words);

    public static int FirstNumberOrDefault(this string line)
    {
        for (var i = 0; i < line.Length; i++)
        {
            var character = line[i];
            if (char.IsDigit(character))
            {
                return int.Parse(character.ToString());
            }

            if (trie.TryGetWordDigit(line, i, out var number))
            {
                return number;
            }
        }

        return 0;
    }

    private static Trie reversedTrie = Trie.Build(reversedWords);
    public static int LastNumberOrDefault(this string line)
    {
        var reversed = string.Concat(line.Reverse());

        for (var i = 0; i < reversed.Length; i++)
        {
            var character = reversed[i];

            if (char.IsDigit(character))
            {
                return int.Parse(character.ToString());
            }

            if (reversedTrie.TryGetWordDigit(reversed, i, out var number))
            {
                return number;
            }
        }

        return 0;

    }
}