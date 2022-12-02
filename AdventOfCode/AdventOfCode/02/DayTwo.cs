// ReSharper disable InconsistentNaming

#pragma warning disable CS8509
#pragma warning disable CS8524
namespace AdventOfCode._02;

public class DayTwo
{
    private readonly List<Row> _rows;

    public DayTwo(IEnumerable<string> lines)
    {
        _rows = lines.Select(s => new Row { Opponent = s[0].ConvertToRPS(), SecondValue = s[2] }).ToList();
    }

    public int PartOne()
    {
        return _rows.Select(row =>
        {
            var choice = row.SecondValue.ConvertToRPS();
            return CalculateScore(choice, GetOutcome(choice, row.Opponent));
        }).Sum();
    }

    public int PartTwo()
    {
        return _rows.Select(row =>
        {
            var desiredOutcome = row.SecondValue switch
            {
                'X' => Outcome.Lose,
                'Y' => Outcome.Draw,
                'Z' => Outcome.Win
            };
            var choiceFromDesired = desiredOutcome switch
            {
                Outcome.Win => row.Opponent.IsBeatenBy(),
                Outcome.Lose => row.Opponent.LosesTo(),
                Outcome.Draw => row.Opponent,
            };
            return CalculateScore(choiceFromDesired, desiredOutcome);
        }).Sum();
    }

    private static int CalculateScore(RPS choice, Outcome outcome) => (int)outcome * 3 + (int)choice + 1;

    private static Outcome GetOutcome(RPS choice, RPS opponent) =>
        choice == opponent ? Outcome.Draw : choice.IsBeatenBy() == opponent ? Outcome.Lose : Outcome.Win;
}

public static class Extensions
{
    public static RPS IsBeatenBy(this RPS choice) => (RPS)(((int)choice + 1) % 3);
    public static RPS LosesTo(this RPS choice) => choice == RPS.Rock ? RPS.Scissors : choice - 1;

    public static RPS ConvertToRPS(this char c)
    {
        return c switch
        {
            'A' => RPS.Rock,
            'B' => RPS.Paper,
            'C' => RPS.Scissors,
            'X' => RPS.Rock,
            'Y' => RPS.Paper,
            'Z' => RPS.Scissors
        };
    }
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
    Lose,
    Draw,
    Win,
}