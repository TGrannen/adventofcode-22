namespace AdventOfCode._01;

public class DayOne
{
    private readonly List<int> _elfCalories;

    public DayOne(IEnumerable<string> lines)
    {
        _elfCalories =
            lines.SplitOn(string.IsNullOrEmpty)
                .Select(elf => elf.Select(int.Parse).Sum())
                .ToList();
    }

    public int PartOne()
    {
        return _elfCalories.Max();
    }

    public int PartTwo()
    {
        return _elfCalories.OrderByDescending(x => x).Take(3).Sum();
    }
}