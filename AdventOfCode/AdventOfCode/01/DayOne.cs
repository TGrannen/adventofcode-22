namespace AdventOfCode._01;

public class DayOne
{
    private readonly List<int> _elfCalories;

    public DayOne(IEnumerable<string> lines)
    {
        _elfCalories = GetElfCalories(lines);
    }

    public int PartOne()
    {
        return _elfCalories.Max();
    }

    public int PartTwo()
    {
        return _elfCalories.OrderByDescending(x => x).Take(3).Sum();
    }

    private static List<int> GetElfCalories(IEnumerable<string> lines)
    {
        var calories = new List<int>();
        var elfCalories = new List<int>();
        foreach (var line in lines)
        {
            if (int.TryParse(line, out var cals))
            {
                calories.Add(cals);
            }
            else
            {
                elfCalories.Add(calories.Sum());
                calories.Clear();
            }
        }

        elfCalories.Add(calories.Sum());
        return elfCalories;
    }
}