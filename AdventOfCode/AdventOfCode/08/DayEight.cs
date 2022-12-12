using AdventOfCode.Shared.Utilities;

namespace AdventOfCode._08;

public class DayEight
{
    private readonly int _rowCount;
    public readonly Grid<Tree> _grid = new();

    public DayEight(IEnumerable<string> lines)
    {
        var row = 0;
        foreach (var line in lines)
        {
            foreach (var t in line.Select((c, i) => new { Height = c - '0', Index = i }))
            {
                _grid.Create(row, t.Index, new Tree { Height = t.Height });
            }

            row++;
        }

        _rowCount = row;

        foreach (var coordinate in _grid.Values)
        {
            var tree = coordinate.Value;
            tree.Visibility.IsVisibleLeft = coordinate.Left().IsVisible(coordinate);
            tree.Visibility.IsVisibleRight = coordinate.Right().IsVisible(coordinate);
            tree.Visibility.IsVisibleTop = coordinate.Up().IsVisible(coordinate);
            tree.Visibility.IsVisibleBottom = coordinate.Down().IsVisible(coordinate);
        }
    }

    public int PartOne()
    {
        return _grid.Values.Count(x => x.Value.Visibility.AnyVisible);
    }

    public int PartTwo()
    {
        return 0;
    }
}

public class Tree
{
    public int Height { get; init; }
    public Visibility Visibility { get; } = new();
}

public class Visibility
{
    public bool AnyVisible => IsVisibleLeft || IsVisibleTop || IsVisibleRight || IsVisibleBottom;
    public bool IsVisibleLeft { get; set; }
    public bool IsVisibleTop { get; set; }
    public bool IsVisibleRight { get; set; }
    public bool IsVisibleBottom { get; set; }
}

public static class Extensions
{
    public static bool IsVisible(this IEnumerable<Coordinate<Tree>> direction, Coordinate<Tree> current)
    {
        var height = current.Value.Height;
        var lastOrDefault = direction.TakeWhile(x => x.Value.Height < height).LastOrDefault();
        if (lastOrDefault == null)
        {
            return current.IsEdge();
        }

        return lastOrDefault.IsEdge();
    }
}