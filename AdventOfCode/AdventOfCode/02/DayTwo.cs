namespace AdventOfCode._02;

public class DayTwo
{
    private readonly List<Row> _rows;

    public DayTwo(IEnumerable<string> lines)
    {
        _rows = lines.Select(s => new Row { Opponent = ConvertToRPS(s[0]), SecondValue = s[2] }).ToList();
    }

    public int PartOne()
    {
        return _rows.Select(row =>
        {
            var choice = ConvertToRPS(row.SecondValue);
            var outcome = choice == row.Opponent ? Outcome.Draw :
                choice switch
                {
                    RPS.Rock => row.Opponent == RPS.Scissors,
                    RPS.Paper => row.Opponent == RPS.Rock,
                    RPS.Scissors => row.Opponent == RPS.Paper
                } ? Outcome.Win : Outcome.Lose;
            return CalculateScore(choice, outcome);
        }).Sum();
    }

    public int PartTwo()
    {
        return _rows.Select(row =>
        {
            var outcome = row.SecondValue switch
            {
                'X' => Outcome.Lose,
                'Y' => Outcome.Draw,
                'Z' => Outcome.Win
            };
            return CalculateScore(outcome switch
            {
                Outcome.Win => (RPS)(((int)row.Opponent + 1) % 3),
                Outcome.Lose => row.Opponent == RPS.Rock ? RPS.Scissors : row.Opponent - 1,
                Outcome.Draw => row.Opponent,
            }, outcome);
        }).Sum();
    }

    private static RPS ConvertToRPS(char c)
    {
        return c switch
        {
            'A' => RPS.Rock,
            'B' => RPS.Paper,
            'C' => RPS.Scissors,
            'X' => RPS.Rock,
            'Y' => RPS.Paper,
            'Z' => RPS.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
    }

    private static int CalculateScore(RPS choice, Outcome outcome) => outcome switch
    {
        Outcome.Win => 6,
        Outcome.Lose => 0,
        Outcome.Draw => 3
    } + (int)choice + 1;
}

public class Row
{
    public RPS Opponent { get; init; }
    public char SecondValue { get; init; }
}

public enum RPS
{
    Rock,
    Paper,
    Scissors
}

public enum Outcome
{
    Win,
    Lose,
    Draw
}