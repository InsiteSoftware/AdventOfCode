namespace Calendars._2022.Day13;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var lines = input.SplitLines();
        var total = 0;
        for (var x = 0; x < lines.Length; x += 3)
        {
            var index = (x / 3) + 1;

            var left = new List<object>();
            var leftInput = new Queue<string>(lines[x].ToCharArray().Select(o => o.ToString()));
            leftInput.Dequeue();
            Parse(left, leftInput);

            var right = new List<object>();
            var rightInput = new Queue<string>(
                lines[x + 1].ToCharArray().Select(o => o.ToString())
            );
            rightInput.Dequeue();
            Parse(right, rightInput);

            if (CompareTo(left, right) > 0)
            {
                total += index;
            }
        }

        return total;
    }

    public static int SecondPart(string input)
    {
        var lines = input.SplitLines();
        var first = new List<object>(new List<object> { 2 });
        var second = new List<object>(new List<object> { 6 });
        var inputs = new List<List<object>> { first, second };
        for (var x = 0; x < lines.Length; x += 3)
        {
            var left = new List<object>();
            var leftInput = new Queue<string>(lines[x].ToCharArray().Select(o => o.ToString()));
            leftInput.Dequeue();
            Parse(left, leftInput);
            inputs.Add(left);

            var right = new List<object>();
            var rightInput = new Queue<string>(
                lines[x + 1].ToCharArray().Select(o => o.ToString())
            );
            rightInput.Dequeue();
            Parse(right, rightInput);
            inputs.Add(right);
        }

        inputs.Sort(new Comparer());

        return (inputs.IndexOf(first) + 1) * (inputs.IndexOf(second) + 1);
    }

    private class Comparer : Comparer<List<object>>
    {
        public override int Compare(List<object>? x, List<object>? y)
        {
            return DoWork.CompareTo(x, y) * -1;
        }
    }

    private static int CompareTo(List<object> left, List<object> right)
    {
        var x = -1;
        while (x < left.Count - 1 && x < right.Count - 1)
        {
            x++;
            if (left[x] is int leftValue && right[x] is int rightValue)
            {
                if (leftValue == rightValue)
                {
                    continue;
                }

                return leftValue < rightValue ? 1 : -1;
            }

            if (left[x] is List<object> leftList)
            {
                if (right[x] is List<object> rightList)
                {
                    var result = CompareTo(leftList, rightList);
                    if (result != 0)
                    {
                        return result;
                    }
                }
                else
                {
                    var result = CompareTo(leftList, new List<object> { right[x] });
                    if (result != 0)
                    {
                        return result;
                    }
                }
            }
            else
            {
                var result = CompareTo(new List<object> { left[x] }, right[x] as List<object>);
                if (result != 0)
                {
                    return result;
                }
            }
        }

        if (left.Count < right.Count)
        {
            return 1;
        }
        else if (left.Count > right.Count)
        {
            return -1;
        }

        return 0;
    }

    private static void Parse(List<object> list, Queue<string> input)
    {
        var next = input.Dequeue();
        while (next != "]")
        {
            if (IsInteger(next))
            {
                if (IsInteger(input.Peek()))
                {
                    next += input.Dequeue();
                }

                list.Add(int.Parse(next));
            }
            else if (next == "[")
            {
                var child = new List<object>();
                list.Add(child);
                Parse(child, input);
            }

            next = input.Dequeue();
        }
    }

    private static bool IsInteger(string value) => int.TryParse(value, out _);
}
