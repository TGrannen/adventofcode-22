using System.Diagnostics.SymbolStore;

namespace AdventOfCode._03;

public class DayThree
{
    private readonly List<Parts> _parts;
    private readonly List<Slice> _slicedParts;

    public DayThree(IEnumerable<string> lines)
    {
        _parts = lines.Select(x =>
        {
            var split = x.Insert(x.Length / 2, "|").Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            return new Parts
            {
                OriginalDistinct = string.Join("", x.Distinct()),
                Part1 = split[0],
                Part2 = split[1]
            };
        }).ToList();

        _slicedParts = _parts.Slice(3).Select(x => new Slice { Items = x.ToArray() }).ToList();
    }

    public int PartOne()
    {
        return _parts.Sum(x =>
        {
            var chars = x.Part1.AsEnumerable().Intersect(x.Part2).Distinct().ToList();
            return chars.Select(Parts.CharScore).Sum();
        });
    }

    public int PartTwo()
    {
        return _slicedParts.Select(x => Parts.CharScore(x.TopChar())).Sum();
    }

    private class Parts
    {
        public string OriginalDistinct { get; init; }
        public string Part1 { get; init; }
        public string Part2 { get; init; }

        public static int CharScore(char x) => x <= 'a' ? x - 'A' + 27 : x - 'a' + 1;
    }

    private class Slice
    {
        public Parts[] Items { get; init; }

        public char TopChar()
        {
            return 
                string.Join("", Items.Select(x => x.OriginalDistinct))
                .GroupBy(x => x)
                .First(x => x.Count() == 3).Key;
        }
    }
}