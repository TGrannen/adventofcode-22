namespace AdventOfCode.Shared.Utilities;

public class Grid<T>
{
    private readonly Dictionary<(int, int), Coordinate<T>> _dictionary = new();
    public IEnumerable<Coordinate<T>> Values => _dictionary.Values;
    public int MaxRow { get; private set; }
    public int MaxColumn { get; private set; }

    public Coordinate<T>? Get(int row, int col)
    {
        var newKeys = (row, col);
        return _dictionary.ContainsKey(newKeys) ? _dictionary[newKeys] : null;
    }

    public IEnumerable<string> Print(Func<Coordinate<T>, object> selector)
    {
        var range = Enumerable.Range(0, MaxColumn + 1);
        for (int i = 0; i <= MaxRow; i++)
        {
            yield return $"{string.Join("-", range.Select(x => selector(Get(i, x))))}";
        }
    }

    public Coordinate<T> Create(int row, int col, T value)
    {
        var coordinate = new Coordinate<T>
        {
            Row = row,
            Column = col,
            Value = value,
            Grid = this
        };
        _dictionary.Add((row, col), coordinate);
        MaxRow = _dictionary.Keys.Max(x => x.Item1);
        MaxColumn = _dictionary.Keys.Max(x => x.Item2);

        return coordinate;
    }
}