using AdventOfCode._08;

namespace AdventOfCode.Tests._08;

[UsesVerify]
public class DayEightTests
{
    private const int Day = 8;

    [Fact]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new DayEight(contents).PartOne();
        result.Should().Be(21);
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new DayEight(contents).PartOne();
        result.Should().Be(1812);
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new DayEight(contents).PartTwo();
        result.Should().Be(8);
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new DayEight(contents).PartTwo();
        result.Should().Be(0);
    }

    [Fact]
    public async Task Visibility_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var grid = new DayEight(contents)._grid;
        await Verify(new
        {
            Grid = grid.Print(x => x.Value.Height),
            Visibility = grid.Print(x => x.Value.Visibility.AnyVisible ? 1 : 0)
        }).UseDirectory("Snapshots");
    }
}