namespace AOC_2022._7;

public static class Code
{
    public static int GetPart1Answer(string[] lines)
    {
        var filesystem = new Dictionary<string, Dictionary<string, int>>();
        var currentDirectory = "/";
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("$"))
            {
                var parts = lines[i].Split(' ');
                switch (parts[1])
                {
                    case "cd":
                        if (parts[2].StartsWith("/"))
                            currentDirectory = parts[2];
                        else if (parts[2].StartsWith(".."))
                        {
                            var dirParts = currentDirectory.Split("/");
                            currentDirectory = string.Join("/", dirParts.SkipLast(1));
                        }
                        else
                            currentDirectory += $"{parts[2]}/";
                        break;
                    case "ls":
                        while (i + 1 < lines.Length && !lines[i + 1].StartsWith("$"))
                        {
                            i++;
                            parts = lines[i].Split(' ');
                            if (!filesystem.ContainsKey(currentDirectory))
                                filesystem[currentDirectory] = new Dictionary<string, int>();

                            if (parts[0] == "dir")
                            {
                                filesystem[$"{currentDirectory}{parts[1] + "/"}"] = new Dictionary<string, int>();
                            }
                            else
                                filesystem[currentDirectory][parts[1] + "/"] = Convert.ToInt32(parts[0]);
                        }
                        break;
                }
            }
        }

        return filesystem.Select(o => o.Key)
            .Select(directory => filesystem.Where(o => o.Key.StartsWith(directory))
                .Sum(o => o.Value.Values.Sum()))
            .Where(totalDirSize => totalDirSize <= 100000)
            .Sum();
    }

    public static int GetPart2Answer(string[] lines)
    {
        var totalSpace = 70000000;
        var neededSpace    = 30000000;
        
        var filesystem = new Dictionary<string, Dictionary<string, int>>();
        var currentDirectory = "/";
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("$"))
            {
                var parts = lines[i].Split(' ');
                switch (parts[1])
                {
                    case "cd":
                        if (parts[2].StartsWith("/"))
                            currentDirectory = parts[2];
                        else if (parts[2].StartsWith(".."))
                        {
                            var dirParts = currentDirectory.Split("/");
                            currentDirectory = string.Join("/", dirParts.SkipLast(1));
                        }
                        else
                            currentDirectory += $"{parts[2]}/";
                        break;
                    case "ls":
                        while (i + 1 < lines.Length && !lines[i + 1].StartsWith("$"))
                        {
                            i++;
                            parts = lines[i].Split(' ');
                            if (!filesystem.ContainsKey(currentDirectory))
                                filesystem[currentDirectory] = new Dictionary<string, int>();

                            if (parts[0] == "dir")
                            {
                                filesystem[$"{currentDirectory}{parts[1] + "/"}"] = new Dictionary<string, int>();
                            }
                            else
                                filesystem[currentDirectory][parts[1] + "/"] = Convert.ToInt32(parts[0]);
                        }
                        break;
                }
            }
        }

        var usedSpace = filesystem.Sum(o => o.Value.Values.Sum());
        var spaceToDelete = neededSpace - (totalSpace - usedSpace);
        
        return filesystem.Select(o => o.Key)
            .Select(directory =>
                new KeyValuePair<string, int>(
                    directory,
                    filesystem.Where(o => o.Key.StartsWith(directory))
                        .Sum(o => o.Value.Values.Sum())))
            .Where(o => o.Value >= spaceToDelete)
            .MinBy(o => o.Value).Value;
        
        return 0;
    }
}