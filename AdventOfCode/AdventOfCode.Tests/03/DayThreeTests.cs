using AdventOfCode._03;

namespace AdventOfCode.Tests._03;

public class DayThreeTests
{
    private const int Day = 3;

    [Fact()]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new DayThree(contents).PartOne();
        result.Should().Be(157);
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new DayThree(contents).PartOne();
        result.Should().Be(8233);
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new DayThree(contents).PartTwo();
        result.Should().Be(70);
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new DayThree(contents).PartTwo();
        result.Should().Be(2821);
    }
}