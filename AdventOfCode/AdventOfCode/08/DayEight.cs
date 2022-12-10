namespace AdventOfCode._08;

public class DayEight
{
    private readonly List<Tree> _trees;
    private readonly List<List<Tree>> _grid = new();

    public DayEight(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var treeLine = line.Select(c => new Tree
            {
                Height = c - '0'
            }).ToList();
            _grid.Add(treeLine);
        }

        _trees = _grid.SelectMany(x => x).ToList();
        ProcessGrid();
    }


    public int PartOne()
    {
        return _trees.Count(x => x.AnyVisible);
    }

    public int PartTwo()
    {
        return 0;
    }

    private void ProcessGrid()
    {
        _grid.First().ForEach(x => x.IsVisibleTop = true);
        _grid.Last().ForEach(x => x.IsVisibleBottom = true);
        foreach (var row in _grid.Skip(1).SkipLast(1))
        {
            row.First().IsVisibleLeft = true;
            row.Last().IsVisibleRight = true;
            LineOfTrees(row, tree => tree.IsVisibleLeft = true, t => t.IsVisibleRight = true, t => t.IsVisibleLeft);
        }

        var countOfColumns = _grid.First().Count;
        for (var j = 1; j < countOfColumns - 1; j++)
        {
            var column = GetTreesInColumn(j);
            LineOfTrees(column, tree => tree.IsVisibleTop = true, t => t.IsVisibleRight = true, t => t.IsVisibleRight);
        }
    }

    private IEnumerable<Tree> GetTreesInColumn(int column)
    {
        return _grid.Select(row => row[column]);
    }

    private static void LineOfTrees(IEnumerable<Tree> row, Action<Tree> setFirst, Action<Tree> setSecond, Func<Tree, bool> hasMetMax)
    {
        var trees = row.ToArray();
        var max = 0;
        foreach (var tree in trees)
        {
            if (tree.Height > max)
            {
                setFirst(tree);
                max = tree.Height;
            }

            if (max == 9)
            {
                break;
            }
        }

        max = 0;
        foreach (var tree in trees.Select(x => x).Reverse())
        {
            if (tree.Height > max)
            {
                setSecond(tree);
                max = tree.Height;
            }

            if (max == 9 || hasMetMax.Invoke(tree))
            {
                break;
            }
        }
    }
}

internal class Tree
{
    public int Height { get; init; }
    public bool AnyVisible => IsVisibleLeft || IsVisibleTop || IsVisibleRight || IsVisibleBottom;
    public bool IsVisibleLeft { get; set; }
    public bool IsVisibleTop { get; set; }
    public bool IsVisibleRight { get; set; }
    public bool IsVisibleBottom { get; set; }
}
