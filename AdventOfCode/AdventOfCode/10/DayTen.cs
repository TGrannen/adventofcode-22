namespace AdventOfCode._10;

public class DayTen
{
    public readonly List<Cycle> _cycles = new();

    public DayTen(IEnumerable<string> contents)
    {
        var instructions = contents.Select(x => x == "noop"
                ? new Instruction { Text = x, NoOp = true }
                : new Instruction { Text = x, Change = int.Parse(x.Replace("addx ", "")) })
            .ToArray();

        var index = 0;
        foreach (var instruction in instructions)
        {
            if (instruction.NoOp)
            {
                _cycles.Add(new Cycle(index, instruction));
                index++;
            }
            else
            {
                _cycles.Add(new Cycle(index, null));
                index++;
                _cycles.Add(new Cycle(index, instruction));
                index++;
            }
        }

        var previous = _cycles[0];
        _cycles[0].StartingValue = _cycles[0].FinalValue = 1;
        foreach (var cycle in _cycles.Skip(1))
        {
            cycle.StartingValue = previous.FinalValue;
            previous = cycle;
            if (!cycle.Changes.Any())
            {
                cycle.FinalValue = cycle.StartingValue;
                continue;
            }

            cycle.FinalValue = cycle.StartingValue + cycle.Changes.Sum();
        }
    }

    public int PartOne()
    {
        var set = new HashSet<int> { 20, 60, 100, 140, 180, 220 };
        return _cycles.Where(x => set.Contains(x.Number)).Sum(x => x.StartingValue * x.Number);
    }

    public List<string> PartTwo()
    {
        var list = new List<string>();
        foreach (var row in _cycles.Slice(40))
        {
            var shouldDraw = row.Select(x =>
            {
                var argIndex = x.Index % 40;
                return argIndex - 1 <= x.StartingValue && x.StartingValue <= argIndex + 1;
            });
            var s = string.Join("", shouldDraw.Select(x => x ? "#" : "."));
            list.Add(s);
        }

        return list;
    }

    public int LastCycleValue()
    {
        return _cycles.Last().FinalValue;
    }
}

public record Instruction
{
    public string Text { get; init; }
    public bool NoOp { get; init; }
    public int Change { get; init; }
};

public class Cycle
{
    public Cycle(int index, Instruction? instruction)
    {
        Index = index;
        Number = index + 1;
        Instruction = instruction?.Text ?? "skip";
        if (instruction is { NoOp: false })
        {
            Changes.Add(instruction.Change);
        }
    }

    public int Index { get; }
    public int Number { get; }
    public string Instruction { get; }
    public int StartingValue { get; set; }
    public List<int> Changes { get; } = new();
    public int FinalValue { get; set; }
};