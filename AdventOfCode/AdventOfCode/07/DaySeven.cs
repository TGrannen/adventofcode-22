namespace AdventOfCode._07;

public class DaySeven
{
    private readonly Disk _disk;

    public DaySeven(IEnumerable<string> lines)
    {
        _disk = new Disk();
        _disk.Parse(lines);
    }

    public long PartOne()
    {
        return _disk.FlatSubDirectoryList.Where(x => x.TotalSize < 100_000).Sum(x => x.TotalSize);
    }

    public long PartTwo()
    {
        var availableSpace = 70_000_000 - _disk.Root.TotalSize;
        var minSizeNeeded = 30_000_000 - availableSpace;

        return _disk.FlatSubDirectoryList.OrderBy(x => x.TotalSize).First(x => x.TotalSize >= minSizeNeeded).TotalSize;
    }
}

public record Directory
{
    public long TotalSize = 0;
}

public class Disk
{
    public Directory Root { get; } = new();
    public List<Directory> FlatSubDirectoryList { get; } = new();

    public void Parse(IEnumerable<string> lines)
    {
        var sections = lines.SplitOn(x => x.StartsWith("$"), includeInResult: true).ToArray();

        var current = Root;
        var directoryStack = new Stack<Directory>();
        foreach (var section in sections.Skip(1)) // ignore the 'cd /' line
        {
            var cmdLine = section.First();
            if (cmdLine == "$ cd ..")
            {
                current = directoryStack.Pop();
                continue;
            }

            if (cmdLine.StartsWith("$ cd"))
            {
                var newDir = new Directory();
                FlatSubDirectoryList.Add(newDir);

                directoryStack.Push(current);
                current = newDir;
                continue;
            }

            current.TotalSize = section.Skip(1).Where(x => !x.StartsWith("dir")).Sum(line => int.Parse(line.Split(" ")[0]));
            foreach (var currentDirectories in directoryStack)
            {
                currentDirectories.TotalSize += current.TotalSize;
            }
        }
    }
}