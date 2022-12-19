using System.Drawing;
using NUnit.Framework;

namespace AdventOfCode2022;

public class Day7NoSpaceLeftOnDevice
{
    public class File
    {
        public File(long size, string name)
        {
            Name = name;
            Size = size;
        }

        public string Name { get; set; }
        public long Size { get; set; }
    }
    public class Folder
    {
        public string Name { get; set; }
        public Folder? Parent { get; set; }
        public List<Folder> Folders { get; set; }
        public List<File> Files { get; set; }

        public Folder(string name, Folder? parent)
        {
            Name = name;
            Folders = new List<Folder>();
            Files = new List<File>();
            Parent = parent;
        }
        
        public long GetSize()
        {
            return Folders.Sum(f => f.GetSize()) + Files.Sum(f => f.Size);
        }
    }
    
    private Folder Root { get; set; }
    private string[] Commands { get; set; }
    private int CommandIndex;
    private const long Threshold     = 100000;
    private const long TotalSize   = 70000000;
    private const long UnusedSpace = 30000000;
    private long TargetSize;

    private long CurrentMinFolder = long.MaxValue;
       
        
    private string[] GetInput()
    {
        var lines = System.IO.File.ReadLines("../../../Inputs/Day7Input.txt").ToArray();
        
        return lines;
    }

    private long NoSpaceLeft(string[] commands)
    {
        Root = new Folder("root", null);
        Commands = commands;
        CommandIndex = 0;
        CurrentMinFolder = long.MaxValue;
        
        BuildFS();
        // var result = CountSizeLessThenThreshold(Root);
        TargetSize = Root.GetSize() - (TotalSize - UnusedSpace);
        SizeFolders(Root);
        
        return CurrentMinFolder;
    }
    List<long> folderSizes = new List<long>();

    private void SizeFolders(Folder current)
    {
        var folderSize = current.GetSize();

        if (folderSize > TargetSize)
        {
            if (CurrentMinFolder > folderSize)
                CurrentMinFolder = folderSize;

            if (current.Folders.Any())
            {
                foreach (var fld in current.Folders)
                {
                    SizeFolders(fld);
                }
            }
        }
        
    }
    
    private long CountSizeLessThenThreshold(Folder current)
    {
        long result = 0;

        if (current.GetSize() < Threshold)
            result += current.GetSize();

        result += current.Folders.Sum(CountSizeLessThenThreshold);
        
        return result;
    }
    
    private void BuildFS()
    {
        var current = Root;
        while (CommandIndex < Commands.Length)
        {
            current = RunCommand(Commands[CommandIndex], current);
            CommandIndex++;
        }
    }

    private Folder RunCommand(string command, Folder current)
    {
        switch (command)
        {
            case "$ cd /":
                return Root;
            case "$ cd ..":
                current = current.Parent;
                break;
            case var cd when cd.StartsWith("$ cd "):
                current = ChangeDirectory(cd, current);
                
                break;
            case "$ ls":
                FillFolder(current);
                break;
        }

        return current;
    }

    private Folder ChangeDirectory(string command, Folder current)
    {
        var folderName = command.Substring(5);
        return current.Folders.First(f => f.Name == folderName);
    }
    
    private void FillFolder(Folder current)
    {
        while ((CommandIndex + 1 < Commands.Length) && 
               !Commands[CommandIndex + 1].StartsWith("$"))
        {
            CommandIndex++;
        
            switch (Commands[CommandIndex])
            {
                case var folderCommand when folderCommand.StartsWith("dir "):
                    var folderName = folderCommand.Substring(4);
                    current.Folders.Add(
                        new Folder(folderName, current));
                    break;
                case var fileCommand:
                    var fileData = fileCommand.Split(" ");
                    var fileSize = long.Parse(fileData[0]);
                    var fileName = fileData[1];
                    current.Files.Add(new File(fileSize, fileName));
                    break;
            }
        }
    }
    
    [Test]
    public void SimpleTest()
    {
        var commands = new[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
        };

        Assert.AreEqual(24933642, NoSpaceLeft(commands));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(1815525, NoSpaceLeft(input));
    }
}