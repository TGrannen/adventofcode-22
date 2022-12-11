namespace AdventOfCode.Shared.Utilities;

public static class Extensions
{
    public static IEnumerable<Coordinate<T>> Left<T>(this Coordinate<T> start) => Shift(start, c => (c.Row, c.Column - 1));
    public static IEnumerable<Coordinate<T>> Right<T>(this Coordinate<T> start) => Shift(start, c => (c.Row, c.Column + 1));
    public static IEnumerable<Coordinate<T>> Up<T>(this Coordinate<T> start) => Shift(start, c => (c.Row - 1, c.Column));
    public static IEnumerable<Coordinate<T>> Down<T>(this Coordinate<T> start) => Shift(start, c => (c.Row + 1, c.Column));

    private static IEnumerable<Coordinate<T>> Shift<T>(this Coordinate<T> start, Func<Coordinate<T>, (int, int)> fun)
    {
        var coord = GetCoordinateFromFunc(start, fun);
        while (coord != null)
        {
            yield return coord;
            coord = GetCoordinateFromFunc(coord, fun);
        }
    }

    private static Coordinate<T>? GetCoordinateFromFunc<T>(Coordinate<T> start, Func<Coordinate<T>, (int, int)> fun)
    {
        var (row, col) = fun(start);
        return start.Grid.Get(row, col);
    }
}