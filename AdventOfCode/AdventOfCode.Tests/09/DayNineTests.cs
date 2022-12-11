using AdventOfCode._09;

namespace AdventOfCode.Tests._09;

public class DayNineTests
{
    private const int Day = 9;

    [Fact]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new DayNine(contents).PartOne();
        result.Should().Be(13);
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new DayNine(contents).PartOne();
        result.Should().Be(6642);
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new DayNine(contents).PartTwo(9);
        result.Should().Be(1);
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new DayNine(contents).PartTwo(9);
        result.Should().Be(2765);
    }

    #region AdditionalTests

    [Fact]
    public async Task PartTwo_ExampleTest_Position()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var dayNine = new DayNine(contents);
        dayNine.PartTwo(9);
        dayNine.KnotList.Select(pos => $"{pos.X}_{pos.Y}").Should().BeEquivalentTo(new[]
        {
            "2_2",
            "1_2",
            "2_2",
            "3_2",
            "2_2",
            "1_1",
            "0_0",
            "0_0",
            "0_0",
            "0_0",
        });
    }

    [Fact]
    public async Task PartTwo_ExampleTest_Position2()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var dayNine = new DayNine(contents);
        dayNine.PartTwo(4);
        dayNine.TailsLocationHistory.Should().BeEquivalentTo(new[]
        {
            "0_0",
            "1_1",
            "2_2"
        });
        dayNine.KnotList.Select(pos => $"{pos.X}_{pos.Y}").Should().BeEquivalentTo(new[]
        {
            "2_2",
            "1_2",
            "2_2",
            "3_2",
            "2_2",
        });
    }

    #endregion
}