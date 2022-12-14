using AdventOfCode._07;

namespace AdventOfCode.Tests._07;

public class DaySevenTests
{
    private const int Day = 7;

    [Fact]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new DaySeven(contents).PartOne();
        result.Should().Be(95437);
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new DaySeven(contents).PartOne();
        result.Should().Be(1501149);
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new DaySeven(contents).PartTwo();
        result.Should().Be(24933642);
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new DaySeven(contents).PartTwo();
        result.Should().Be(10096985);
    }
}