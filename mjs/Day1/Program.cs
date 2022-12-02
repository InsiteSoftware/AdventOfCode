// See https://aka.ms/new-console-template for more information

using System.Text;

Day1A();
Day1B();

static string[] GetContents(string path = "input.txt")
{
    return File.ReadAllLines(path);
}

static void Day1A()
{
    var contents = GetContents();

    var max = 0;
    var current = 0;
    foreach (var line in contents)
    {
        if (string.IsNullOrEmpty(line))
        {
            if (current > max)
                max = current;
            current = 0;
            continue;
        }

        current += int.Parse(line);
    }

    Console.WriteLine(max);
}

static void Day1B()
{
    var contents = GetContents();

    var elfNum = 0;
    var top3Snacks = contents.Select(e =>
    {
        var cal = 0;
        if (string.IsNullOrEmpty(e))
            elfNum++;
        else
            cal = int.Parse(e);
        return new { elfNum, cal };
    }).ToList() // Gross - without enumerating here we don't partition the list though
        .GroupBy(e => e.elfNum)
        .Select(g => 
            new { elf = g.Key, cals = g.Sum(e => e.cal) })
        .OrderByDescending(e => e.cals)
        .Take(3)
        .Sum(e => e.cals);
    
    Console.WriteLine(top3Snacks);
    
}
