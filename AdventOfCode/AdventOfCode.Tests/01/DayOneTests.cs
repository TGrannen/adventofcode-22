using AdventOfCode._01;

namespace AdventOfCode.Tests._01;

public class DayOneTests
{
    [Fact]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(1, @"Input\Example.txt");
        var result = new DayOne(contents).PartOne();
        result.Should().Be(24_000);
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(1, @"Input\Problem.txt");
        var result = new DayOne(contents).PartOne();
        result.Should().Be(68_775);
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(1, @"Input\Example_Part2.txt");
        var result = new DayOne(contents).PartTwo();
        result.Should().Be(45_000);
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(1, @"Input\Problem.txt");
        var result = new DayOne(contents).PartTwo();
        result.Should().BeGreaterThan(0);
        result.Should().Be(202_585);
    }
}