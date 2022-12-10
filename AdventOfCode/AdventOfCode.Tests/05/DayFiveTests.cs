using AdventOfCode._05;

namespace AdventOfCode.Tests._05;

public class DayFiveTests
{
    private const int Day = 5;

    [Fact]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var score = new DayFive(contents).PartOne();
        score.Should().Be("CMZ");
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var score = new DayFive(contents).PartOne();
        score.Should().Be("PSNRGBTFT");
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var score = new DayFive(contents).PartTwo();
        score.Should().Be("MCD");
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var score = new DayFive(contents).PartTwo();
        score.Should().Be("BNTZFPMMW");
    }
}