using AdventOfCode.Shared.Utilities;
using Argon;

namespace AdventOfCode.Tests.Shared.Utilities;

[UsesVerify]
public class GridTests
{
    private readonly Grid<int> _sut = new();

    [Fact]
    public async Task Values_ShouldBeLoadedCorrectly()
    {
        FillGrid(3, 4);

        await Verify(_sut.Values).IgnoreMember("Grid")
            .AddExtraSettings(settings => settings.DefaultValueHandling = DefaultValueHandling.Include);
    }

    [Fact]
    public async Task DirectionExtensionMethods_ShouldBeLoadedCorrectly()
    {
        FillGrid(3, 4);

        var items = _sut.Values.Select(x => new
        {
            Item = x.Value,
            Left = string.Join(",", x.Left().Select(coord => coord.Value)),
            Up = string.Join(",", x.Up().Select(coord => coord.Value)),
            Right = string.Join(",", x.Right().Select(coord => coord.Value)),
            Down = string.Join(",", x.Down().Select(coord => coord.Value))
        });
        await Verify(new
        {
            Grid = _sut.Print(x => x.Value),
            Items = items
        });
    }

    [Fact]
    public async Task IsEdge_ShouldBeLoadedCorrectly()
    {
        FillGrid(7, 13);

        await Verify(_sut.Print(x => x.IsEdge() ? 1 : 0));
    }

    [Fact]
    public async Task Print_ShouldReturnLinesWithSelectedValue()
    {
        FillGrid(6, 9);

        var lines = _sut.Print(x => x.Value.ToString());
        await Verify(lines);
    }

    private void FillGrid(int rows, int columns)
    {
        var count = 1;
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                _sut.Create(i, j, count);
                count++;
            }
        }
    }
}