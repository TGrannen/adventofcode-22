namespace AdventOfCode._04;

public class DayFour
{
    private readonly Group[] _groups;

    public DayFour(IEnumerable<string> lines)
    {
        _groups = lines.Select(x =>
        {
            var split = x.Split(",");
            return new Group
            {
                Ranges = new[] { new Range(split[0]), new Range(split[1]) }.OrderBy(x => x.Min).ToArray()
            };
        }).ToArray();
    }

    public int PartOne()
    {
        return _groups.Count(x => x.Isin());
    }

    public int PartTwo()
    {
        return _groups.Count(x => x.AnyOverlap());
    }

    private class Group
    {
        public Range[] Ranges { get; init; }

        public bool Isin()
        {
            var last = Ranges.Last();
            var first = Ranges.First();
            return last.Diff < first.Diff && last.Max <= first.Max || first.Min == last.Min;
        }

        public bool AnyOverlap()
        {
            var last = Ranges.Last();
            var first = Ranges.First();
            return (first.Min <= last.Min && last.Max <= first.Max) || (last.Min <= first.Max && first.Max <= last.Max);
        }
    }

    public class Range
    {
        public Range(string s)
        {
            var split = s.Split("-");
            Min = int.Parse(split[0]);
            Max = int.Parse(split[1]);
        }

        public int Min { get; init; }
        public int Max { get; init; }
        public int Diff => Max - Min;
    }
}