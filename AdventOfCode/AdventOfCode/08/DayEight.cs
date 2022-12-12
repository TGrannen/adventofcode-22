using AdventOfCode.Shared.Utilities;

namespace AdventOfCode._08;

public class DayEight
{
    public readonly Grid<Tree> Grid = new();

    public DayEight(IEnumerable<string> lines)
    {
        var row = 0;
        foreach (var line in lines)
        {
            foreach (var t in line.Select((c, i) => new { Height = c - '0', Index = i }))
            {
                Grid.Create(row, t.Index, new Tree { Height = t.Height });
            }

            row++;
        }
    }

    public int PartOne()
    {
        CalculateVisibilities();
        return Grid.Values.Count(x => x.Value.AnyVisible);
    }


    public int PartTwo()
    {
        CalculateScores();
        return Grid.Values.Max(x => x.Value.Score);
    }

    public void CalculateScores()
    {
        foreach (var coordinate in Grid.Values)
        {
            var tree = coordinate.Value;

            tree.Left.Score = coordinate.Left().ToArray().Score(coordinate);
            tree.Top.Score = coordinate.Up().ToArray().Score(coordinate);
            tree.Right.Score = coordinate.Right().ToArray().Score(coordinate);
            tree.Bottom.Score = coordinate.Down().ToArray().Score(coordinate);
        }
    }

    public void CalculateVisibilities()
    {
        foreach (var coordinate in Grid.Values)
        {
            var tree = coordinate.Value;

            tree.Left.Visible = coordinate.Left().IsVisible(coordinate);
            tree.Right.Visible = coordinate.Right().IsVisible(coordinate);
            tree.Top.Visible = coordinate.Up().IsVisible(coordinate);
            tree.Bottom.Visible = coordinate.Down().IsVisible(coordinate);
        }
    }
}

public class Tree
{
    public int Height { get; init; }
    public Side Left { get; } = new();
    public Side Top { get; } = new();
    public Side Right { get; } = new();
    public Side Bottom { get; } = new();
    public int Score => Left.Score * Top.Score * Right.Score * Bottom.Score;
    public bool AnyVisible => Left.Visible || Top.Visible || Right.Visible || Bottom.Visible;
}

public class Side
{
    public bool Visible { get; set; } = false;
    public int Score { get; set; } = 1;
}

public static class Extensions
{
    public static bool IsVisible(this IEnumerable<Coordinate<Tree>> direction, Coordinate<Tree> current)
    {
        var lastOrDefault = direction.TakeWhile(x => x.Value.Height < current.Value.Height).LastOrDefault();
        return lastOrDefault?.IsEdge() ?? current.IsEdge();
    }

    public static int Score(this Coordinate<Tree>[] direction, Coordinate<Tree> current)
    {
        if (current.IsEdge())
        {
            return 1;
        }

        var treesVisible = direction.TakeWhile(x => x.Value.Height < current.Value.Height).ToArray();
        if (!treesVisible.Any())
        {
            return 1;
        }

        return treesVisible.Length + (treesVisible.Last() == direction.Last() ? 0 : 1);
    }
}