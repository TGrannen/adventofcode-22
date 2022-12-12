namespace AdventOfCode._10;

public class DayTen
{
    public readonly List<Cycle> Cycles = new();

    public DayTen(IEnumerable<string> contents)
    {
        FillCycles(contents);
        CalculateCycleValues();
    }

    public int PartOne()
    {
        var set = new HashSet<int> { 20, 60, 100, 140, 180, 220 };
        return Cycles.Where(x => set.Contains(x.Number)).Sum(x => x.StartingValue * x.Number);
    }

    public IEnumerable<string> PartTwo()
    {
        return Cycles.Slice(40).Select(crtRow => string.Join("", crtRow.Select(CycleToPixelChar)));
    }

    public int LastCycleValue()
    {
        return Cycles.Last().FinalValue;
    }

    private void FillCycles(IEnumerable<string> contents)
    {
        int index = 0;
        foreach (var line in contents)
        {
            if (line != "noop")
            {
                Cycles.Add(new Cycle(index, null));
                index++;
            }

            Cycles.Add(new Cycle(index, line));
            index++;
        }
    }

    private void CalculateCycleValues()
    {
        var previous = Cycles[0];
        Cycles[0].FinalValue = 1;
        foreach (var cycle in Cycles.Skip(1))
        {
            cycle.StartingValue = previous.FinalValue;
            cycle.FinalValue = cycle.StartingValue + cycle.Change;
            previous = cycle;
        }
    }

    static char CycleToPixelChar(Cycle cycle)
    {
        var position = cycle.Index % 40;
        var shouldDraw = position - 1 <= cycle.StartingValue && cycle.StartingValue <= position + 1;
        return shouldDraw ? '#' : '.';
    }
}

public class Cycle
{
    public Cycle(int index, string? instruction)
    {
        Index = index;
        Number = index + 1;
        Instruction = instruction ?? "skip";
        Change = instruction != null && instruction != "noop" ? int.Parse(instruction.Replace("addx ", "")) : 0;
    }

    public int Index { get; }
    public int Number { get; }
    public string Instruction { get; }
    public int Change { get; }
    public int StartingValue { get; set; }
    public int FinalValue { get; set; }
};