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
        var currentSpace = folders.First(o => o.Name == "/").GetSize();
        var currentUnused = totalSpace - currentSpace;

        return folders.Where(o => currentUnused + o.GetSize() > targetSpace).Min(o => o.GetSize());
    }

    private static List<Folder> GetFolders(string input)
    {
        var folders = new List<Folder> { new() { Name = "/" } };
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
                    if (line.StartsWith("dir"))
                    {
                        var newFolder = new Folder() { Name = line.Replace("dir ", "") };
                        currentFolders.Peek().Folders.Add(newFolder);
                        folders.Add(newFolder);
                    }
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
                currentFolders.Push(
                    currentFolders.Peek().Folders.First(o => o.Name == line.Replace("$ cd ", ""))
                );
                line = reader.ReadLine();
            }
        }

        return folders;
    }

    private class Folder
    {
        public string Name { get; set; }
        public readonly List<Folder> Folders = new();
        public readonly List<int> Files = new();

        public int GetSize()
        {
            return this.Files.Sum() + this.Folders.Select(o => o.GetSize()).Sum();
        }
    }
}
