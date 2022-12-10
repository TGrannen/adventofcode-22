namespace AdventOfCode._07;

public class DaySeven
{
    private readonly Disk _disk;

    public DaySeven(IEnumerable<string> lines)
    {
        _disk = InputParser.Parse(lines);
    }

    public long PartOne()
    {
        return _disk.FlatDirectories.Where(x => x.TotalSize < 100_000).Sum(x => x.TotalSize);
    }

    public long PartTwo()
    {
        var minSizeNeeded = 30_000_000 - _disk.AvailableSpace;

        var ordered = _disk.FlatDirectories.OrderBy(x => x.TotalSize).ToArray();
        return ordered.First(x => x.TotalSize >= minSizeNeeded).TotalSize;
    }
}

public record TFile(int Size, string FileName);

public class Disk
{
    public Disk()
    {
        Root = new TDirectory { Name = "/" };
    }

    public TDirectory Root { get; }
    public List<TDirectory> FlatDirectories { get; } = new();
    public long TotalSpace { get; init; } = 70_000_000;
    public long AvailableSpace => TotalSpace - Root.TotalSize;

    public TDirectory CreateDirectory(TDirectory? parent, string cmdLine)
    {
        var newDir = new TDirectory { Name = cmdLine.Replace("$ cd ", "") };
        parent?.Directories.Add(newDir);
        FlatDirectories.Add(newDir);
        return newDir;
    }
}

public record TDirectory
{
    public List<TFile> Files { get; } = new();
    public List<TFile> FilesBelow { get; } = new();
    public List<TDirectory> Directories { get; } = new();
    public string Name { get; init; } = string.Empty;
    public long Size => Files.Sum(x => x.Size);
    public long TotalSize => Size + FilesBelow.Sum(x => x.Size);
}

public static class InputParser
{
    public static Disk Parse(IEnumerable<string> lines)
    {
        var sections = lines.SplitOn(x => x.StartsWith("$"), includeInResult: true).ToArray();
        var disk = new Disk();
        var current = disk.Root;

        var directoryStack = new Stack<TDirectory>();
        foreach (var section in sections.Skip(1))
        {
            var cmdLine = section.First();
            if (cmdLine == "$ cd ..")
            {
                current = directoryStack.Pop();
                continue;
            }

            if (cmdLine.StartsWith("$ cd"))
            {
                var newDir = disk.CreateDirectory(current, cmdLine);
                directoryStack.Push(current);
                current = newDir;
                continue;
            }

            if (cmdLine != "$ ls") continue;

            ParseFileLines(section, directoryStack, current);
        }

        return disk;
    }

    private static void ParseFileLines(List<string> section, Stack<TDirectory> directoryStack, TDirectory current)
    {
        foreach (var line in section.Skip(1).Where(x => !x.StartsWith("dir")))
        {
            var split = line.Split(" ");
            var newFile = new TFile(int.Parse(split[0]), split[1]);
            foreach (var currentDirectories in directoryStack)
            {
                currentDirectories.FilesBelow.Add(newFile);
            }

            current.Files.Add(newFile);
        }
    }
}