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
        result.Should().Be(315495);
    }

    [Fact]
    public async Task Visibility_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var dayEight = new DayEight(contents);
        dayEight.CalculateVisibilities();
        var grid = dayEight.Grid;
        await Verify(new
        {
            Grid = grid.Print(x => x.Value.Height),
            Visibility = grid.Print(x => x.Value.AnyVisible ? 1 : 0)
        }).UseDirectory("Snapshots");
    }

    [Fact]
    public async Task ScenicScore_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var dayEight = new DayEight(contents);
        dayEight.CalculateScores();
        var grid = dayEight.Grid;
        await Verify(new
        {
            Grid = grid.Print(x => x.Value.Height),
            Score = grid.Print(x => x.Value.Score)
        }).UseDirectory("Snapshots");
    }
}