string[] lines = System.IO.File.ReadAllLines(@"C:\Projects\AdventOfCode\monica\AdventCalendar\AdventCalendar\Input.txt");
var elfCounter = 1;
var currentElfCalories = 0;
Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
var end = lines.Length;
var lineCounter = 0;


foreach (string line in lines)
{
    lineCounter++;
    if (string.IsNullOrEmpty(line))
    {
        keyValuePairs.Add(elfCounter, currentElfCalories);

        NextElf();
        continue;
    }

    var calories = int.Parse(line);

    currentElfCalories = currentElfCalories + calories;

    if (lineCounter == end)
    {
        keyValuePairs.Add(elfCounter, currentElfCalories);
    }
}

var sortedDict = from entry in keyValuePairs orderby entry.Value descending select entry;

Console.WriteLine($"The elf with the most calories is " + sortedDict.ToArray()[0].Key + " With " + sortedDict.ToArray()[0].Value + "calories");

Console.WriteLine($"The elf with the most calories is " + sortedDict.ToArray()[1].Key + " With " + sortedDict.ToArray()[1].Value + "calories");

Console.WriteLine($"The elf with the most calories is " + sortedDict.ToArray()[2].Key + " With " + sortedDict.ToArray()[2].Value + "calories");

var max3CalorieTotal = sortedDict.ToArray()[0].Value + sortedDict.ToArray()[1].Value + sortedDict.ToArray()[2].Value;

Console.WriteLine($"The calories are " + max3CalorieTotal);


void NextElf()
{
    elfCounter++;
    currentElfCalories = 0;
}
