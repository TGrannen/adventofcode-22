namespace AdventOfCode._04;

public class DayFour
{
    private readonly Group[] _groups;

    public DayFour(IEnumerable<string> lines)
    {
        _groups = lines.Select(x => new Group(x)).ToArray();
    }

    public int PartOne()
    {
        return _groups.Count(x => x.IsEncapsulated);
    }

    public int PartTwo()
    {
        return _groups.Count(x => x.AnyOverlap);
    }

    private class Group
    {
        public Group(string s)
        {
            var split = s.Split(",").Select(rStr => rStr.Split("-").Select(int.Parse).ToArray()).ToArray();
            var one = new Range { Min = split[0][0], Max = split[0][1] };
            var two = new Range { Min = split[1][0], Max = split[1][1] };
            IsEncapsulated = one.Min <= two.Min && two.Max <= one.Max || two.Min <= one.Min && one.Max <= two.Max;
            AnyOverlap = one.IsBetween(two) || two.IsBetween(one);
        }

        public bool IsEncapsulated { get; }
        public bool AnyOverlap { get; }

        private class Range
        {
            public int Min { get; init; }
            public int Max { get; init; }

            public bool IsBetween(Range range)
            {
                return range.Min <= Min && Min <= range.Max ||
                       range.Min <= Max && Max <= range.Max;
            }
        }
    }
}