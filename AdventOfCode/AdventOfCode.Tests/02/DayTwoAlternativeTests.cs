using AdventOfCode._02;

namespace AdventOfCode.Tests._02;

public class DayTwoAlternativeTests
{
    [Fact]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(2, @"Input\Example.txt");
        var score = new DayTwoAlternate(contents).PartOne();
        score.Should().Be(15);
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(2, @"Input\Problem.txt");
        var score = new DayTwoAlternate(contents).PartOne();
        score.Should().Be(12679);
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(2, @"Input\Example.txt");
        var score = new DayTwoAlternate(contents).PartTwo();
        score.Should().Be(12);
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(2, @"Input\Problem.txt");
        var score = new DayTwoAlternate(contents).PartTwo();
        score.Should().Be(14470);
    }
}