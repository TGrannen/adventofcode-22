namespace AdventOfCode._09;

public class DayNine
{
    public readonly List<KnotPosition> KnotList = new();
    public List<string> TailLocationHistory { get; } = new();

    public DayNine(IEnumerable<string> lines, int tailLength = 1)
    {
        var commands = lines.Select(x => new Command(x)).ToList();

        var (head, last) = SeedKnots(tailLength);
        last.OnMove += (sender, args) =>
        {
            var pos = sender as KnotPosition;
            Console.WriteLine($"{pos!.X}_{pos.Y}");
            TailLocationHistory.Add($"{pos.X}_{pos.Y}");
        };

        TailLocationHistory.Add($"{head.X}_{head.Y}");
        foreach (var command in commands)
        {
            for (var i = 0; i < command.Count; i++)
            {
                head.Move(command.Direction);
                head.Tail?.Trail(head);
            }
        }
    }

    public int PartOne()
    {
        return TailLocationHistory.Distinct().Count();
    }

    public int PartTwo()
    {
        return TailLocationHistory.Distinct().Count();
    }

    private (KnotPosition head, KnotPosition tail) SeedKnots(int tailLength)
    {
        var head = new KnotPosition();
        var current = head;
        for (var i = 0; i < tailLength; i++)
        {
            current.Tail = new KnotPosition();
            KnotList.Add(current);
            current = current.Tail;
        }

        KnotList.Add(current);
        return (head, current);
    }
}

public class KnotPosition
{
    public int X { get; private set; } = 0;
    public int Y { get; private set; } = 0;
    public KnotPosition? Tail { get; set; }
    public event EventHandler<EventArgs>? OnMove;

    public void Move(Direction direction)
    {
        Action action = direction switch
        {
            Direction.Up => () => Y += 1,
            Direction.Down => () => Y -= 1,
            Direction.Left => () => X -= 1,
            Direction.Right => () => X += 1,
            _ => throw new ArgumentOutOfRangeException(nameof(direction))
        };

        action();
    }

    public void Trail(KnotPosition position)
    {
        var directions = CatchUpMoves(position, this);
        if (directions == null || directions.Length == 0) return;

        foreach (var dir in directions)
        {
            Move(dir);
        }

        Tail?.Trail(this);
        OnMove?.Invoke(this, EventArgs.Empty);
    }

    private static Direction[]? CatchUpMoves(KnotPosition position, KnotPosition the)
    {
        var diffX = position.X - the.X;
        var diffY = position.Y - the.Y;

        if (Math.Abs(diffX) <= 1 && Math.Abs(diffY) <= 1)
        {
            return null;
        }

        if (diffX == 0)
        {
            return new[] { diffY >= 0 ? Direction.Up : Direction.Down };
        }

        if (diffY == 0)
        {
            return new[] { diffX >= 0 ? Direction.Right : Direction.Left };
        }

        return new[]
        {
            diffX > 0 ? Direction.Right : Direction.Left,
            diffY > 0 ? Direction.Up : Direction.Down
        };
    }
}

public class Command
{
    public Command(string line)
    {
        Direction = line[0] switch
        {
            'D' => Direction.Down,
            'U' => Direction.Up,
            'L' => Direction.Left,
            'R' => Direction.Right
        };
        var startIndex = line.IndexOf(" ", StringComparison.InvariantCultureIgnoreCase);
        Count = int.Parse(line[startIndex..]);
    }

    public Direction Direction { get; }
    public int Count { get; }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
}