using AdventOfCode._03;

namespace AdventOfCode.Tests._03;

public class DayThreeTests
{
    private const int Day = 3;

    [Fact()]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var score = new DayThree(contents).PartOne();
        score.Should().Be(157);
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var score = new DayThree(contents).PartOne();
        score.Should().Be(8233);
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var score = new DayThree(contents).PartTwo();
        score.Should().Be(70);
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var score = new DayThree(contents).PartTwo();
        score.Should().Be(2821);
    }
}