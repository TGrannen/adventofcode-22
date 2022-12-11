namespace AdventOfCode._09;

public class DayNine
{
    private readonly List<Command> _commands;
    public readonly List<KnotPosition> KnotList = new();
    private KnotPosition Head { get; } = new();
    public List<string> TailsLocationHistory { get; } = new();

    public DayNine(IEnumerable<string> lines)
    {
        _commands = lines.Select(x => new Command(x)).ToList();
    }

    public int PartOne()
    {
        SeedKnots(1);
        ApplyCommands();
        return TailsLocationHistory.Distinct().Count();
    }

    public int PartTwo(int tailLength)
    {
        SeedKnots(tailLength);
        ApplyCommands();
        return TailsLocationHistory.Distinct().Count();
    }


    private void ApplyCommands()
    {
        TailsLocationHistory.Add($"{Head.X}_{Head.Y}");
        foreach (var command in _commands)
        {
            for (var i = 0; i < command.Count; i++)
            {
                Head.Move(command.Direction);
                Head.Tail?.Trail(Head);
            }
        }
    }

    private void SeedKnots(int tailLength)
    {
        var current = Head;
        for (var i = 0; i < tailLength; i++)
        {
            current.Tail = new KnotPosition();
            KnotList.Add(current);
            current = current.Tail;
        }

        KnotList.Add(current);
        current.OnMove += (sender, args) =>
        {
            var pos = sender as KnotPosition;
            Console.WriteLine($"{pos.X}_{pos.Y}");
            TailsLocationHistory.Add($"{pos.X}_{pos.Y}");
        };
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

    public static Direction[]? CatchUpMoves(KnotPosition position, KnotPosition the)
    {
        var diffX = position.X - the.X;
        var diffY = position.Y - the.Y;

        if (Math.Abs(diffX) <= 1 && Math.Abs(diffY) <= 1)
        {
            return null;
        }

        var key = $"{diffX}_{diffY}";
        return key switch
        {
            "1_-2" => new[] { Direction.Right, Direction.Down },
            "1_2" => new[] { Direction.Right, Direction.Up },
            "-1_-2" => new[] { Direction.Left, Direction.Down },
            "-1_2" => new[] { Direction.Left, Direction.Up },
            "2_1" => new[] { Direction.Right, Direction.Up },
            "2_-1" => new[] { Direction.Right, Direction.Down },
            "-2_1" => new[] { Direction.Left, Direction.Up },
            "-2_-1" => new[] { Direction.Left, Direction.Down },
            "0_2" => new[] { Direction.Up },
            "0_-2" => new[] { Direction.Down },
            "2_0" => new[] { Direction.Right },
            "-2_0" => new[] { Direction.Left },
            "2_2" => new[] { Direction.Right, Direction.Up },
            "-2_2" => new[] { Direction.Left, Direction.Up },
            "-2_-2" => new[] { Direction.Left, Direction.Down },
            "2_-2" => new[] { Direction.Right, Direction.Down },
            _ => throw new ArgumentException(key)
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