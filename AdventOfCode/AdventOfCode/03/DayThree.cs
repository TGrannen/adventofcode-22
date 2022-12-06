namespace AdventOfCode._03;

public class DayThree
{
    private readonly int[] _parts;
    private readonly int[] _slicedParts;

    public DayThree(IEnumerable<string> lines)
    {
        _parts = lines.Select(x =>
        {
            var split = x.Insert(x.Length / 2, "|").Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            return split[0].AsEnumerable().Intersect(split[1]).Distinct().ToList().Select(CharScore).Sum();
        }).ToArray();

        var strings = lines.Select(x => new string(x.Distinct().ToArray())).Slice(3).Select(x => string.Join("", x)).ToArray();
        var chars = strings.Select(x => x.GroupBy(y => y).First(y => y.Count() == 3).Key).ToArray();

        _slicedParts = chars.Select(CharScore).ToArray();
    }

    public int PartOne() => _parts.Sum();

    public int PartTwo() => _slicedParts.Sum();

    private static int CharScore(char x) => x <= 'a' ? x - 'A' + 27 : x - 'a' + 1;
}