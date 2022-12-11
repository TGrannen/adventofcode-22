namespace AdventOfCode.Shared.Utilities;

public class Coordinate<T>
{
    public T Value { get; init; }
    public int Row { get; init; }
    public int Column { get; init; }
    public Grid<T> Grid { get; init; }

    public bool IsEdge()
    {
        return Row == 0 || Column == 0 || Row == Grid.MaxRow || Column == Grid.MaxColumn;
    }
}