namespace Calendars._2022.Day07;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var folders = GetFolders(input);

        return folders.Where(o => o.GetSize() < 100000).Sum(o => o.GetSize());
    }

    public static int SecondPart(string input)
    {
        var folders = GetFolders(input);

        var totalSpace = 70000000;
        var targetSpace = 30000000;
        var currentSpace = folders.First().GetSize();
        var currentUnused = totalSpace - currentSpace;

        return folders.Where(o => currentUnused + o.GetSize() > targetSpace).Min(o => o.GetSize());
    }

    private static List<Folder> GetFolders(string input)
    {
        var folders = new List<Folder> { new() };
        var currentFolders = new Stack<Folder>();
        currentFolders.Push(folders[0]);

        var reader = new StringReader(input);
        var line = reader.ReadLine();
        line = reader.ReadLine();
        while (line != null)
        {
            if (line == "$ ls")
            {
                line = reader.ReadLine();
                while (line != null && !line.StartsWith("$"))
                {
                    if (line.StartsWith("dir")) { }
                    else
                    {
                        currentFolders.Peek().Files.Add(int.Parse(line.Split(' ')[0]));
                    }

                    line = reader.ReadLine();
                }
            }
            else if (line == "$ cd ..")
            {
                currentFolders.Pop();
                line = reader.ReadLine();
            }
            else if (line.StartsWith("$ cd "))
            {
                var newFolder = new Folder();
                currentFolders.Peek().Folders.Add(newFolder);
                folders.Add(newFolder);

                currentFolders.Push(newFolder);
                line = reader.ReadLine();
            }
        }

        return folders;
    }

    private class Folder
    {
        public readonly List<Folder> Folders = new();
        public readonly List<int> Files = new();

        public int GetSize()
        {
            return this.Files.Sum() + this.Folders.Select(o => o.GetSize()).Sum();
        }
    }
}
