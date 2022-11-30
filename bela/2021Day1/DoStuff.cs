namespace Day1;

public static class DoStuff
{
    public static int Run(string input)
    {
        var reader = new StringReader(input);
        int? last = null;
        var ups = 0;
        var line = reader.ReadLine();
        while (line != null)
        {
            var current = int.Parse(line);
            if (current > last)
            {
                ups++;
            }

            last = current;
            line = reader.ReadLine();
        }

        return ups;
    }

    public static int RunRunningTotal(string input)
    {
        var reader = new StringReader(input);
        int? last = null;
        var queue = new Queue<int>();
        var ups = 0;
        var line = reader.ReadLine();
        while (line != null)
        {
            queue.Enqueue(int.Parse(line));
            if (queue.Count > 3)
            {
                queue.Dequeue();
            }

            if (queue.Count == 3)
            {
                var current = queue.Sum(o => o);
                if (current > last)
                {
                    ups++;
                }

                last = current;
            }

            line = reader.ReadLine();
        }

        return ups;
    }
}
