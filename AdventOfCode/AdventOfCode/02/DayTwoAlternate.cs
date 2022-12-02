namespace AdventOfCode._02;

public class DayTwoAlternate
{
    private readonly IEnumerable<string> _lines;

    public DayTwoAlternate(IEnumerable<string> lines)
    {
        _lines = lines;
    }

    public int PartOne()
    {
        return _lines.Select(line =>
        {
            return line switch
            {
                "A X" => 4, // 3 + 1
                "A Y" => 8, // 6 + 2
                "A Z" => 3, // 0 + 3
                "B X" => 1, // 0 + 1
                "B Y" => 5, // 3 + 2
                "B Z" => 9, // 6 + 3
                "C X" => 7, // 6 + 1
                "C Y" => 2, // 0 + 2
                "C Z" => 6, // 3 + 3
            };
        }).Sum();
    }

    public int PartTwo()
    {
        return _lines.Select(line =>
        {
            return line switch
            {
                "A X" => 3, // 0 + 3,
                "A Y" => 4, // 3 + 1,
                "A Z" => 8, // 6 + 2,
                "B X" => 1, // 0 + 1,
                "B Y" => 5, // 3 + 2,
                "B Z" => 9, // 6 + 3,
                "C X" => 2, // 0 + 2,
                "C Y" => 6, // 3 + 3,
                "C Z" => 7, // 6 + 1,
            };
        }).Sum();
    }
}