
public class Trie
{

    public Node Root { get; init; }
    private Dictionary<string, int> data { get; init; }

    private Trie()
    {
        Root = new Node();
        data = new Dictionary<string, int>();
    }

    public static Trie Build(Dictionary<string, int> numbers)
    {

        var root = new Node();

        foreach (var (number, digit) in numbers)
        {
            Node parent = root;

            foreach (var letter in number)
            {

                var current = parent.Nodes.SingleOrDefault(x => x.Value == letter);

                if (current is null)
                {
                    current = new Node() { Value = letter };
                    parent.Nodes.Add(current);
                }

                parent = current;
            }
        }

        return new Trie
        {
            Root = root,
            data = numbers
        };
    }

    public bool TryGetWordDigit(string line, int position, out int number)
    {

        var letters = new List<char>();
        var parent = this.Root;
        var word = string.Empty;
        number = 0;

        while (position < line.Length)
        {
            var current = parent.Nodes.SingleOrDefault(x => x.Value == line[position]);

            if (current is null)
            {
                word = string.Concat(letters.ToArray());
                if (data.TryGetValue(word, out var digit))
                {
                    number = digit;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                letters.Add(current.Value);
                parent = current;
                position++;
            }

        }

        word = string.Concat(letters.ToArray());
        if (data.TryGetValue(word, out var value))
        {
            number = value;
            return true;
        }


        return false;

    }
}