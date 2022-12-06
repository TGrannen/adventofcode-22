using AdventOfCode._04;

namespace AdventOfCode.Tests._04;

public class DayFourTests
{
    private const int Day = 4;

    [Fact]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var score = new DayFour(contents).PartOne();
        score.Should().Be(2);
    }

    [Theory]
    [InlineData("47-48,25-47", 0)]
    [InlineData("12-46,5-46", 1)]
    [InlineData("10-78,10-10", 1)]
    [InlineData("18-95,4-94", 0)]
    [InlineData("24-81,9-70", 0)]
    [InlineData("6-98,90-97", 1)]
    [InlineData("3-55,38-60", 0)]
    [InlineData("55-68,55-67", 1)]
    [InlineData("22-80,22-82", 1)]
    [InlineData("6-70,7-7", 1)]
    [InlineData("13-15,12-18", 1)]
    [InlineData("54-95,38-89", 0)]
    [InlineData("19-93,42-93", 1)]
    [InlineData("65-92,93-97", 0)]
    [InlineData("50-93,50-63", 1)]
    [InlineData("50-99,50-99", 1)]
    [InlineData("49-49,3-48", 0)]
    [InlineData("4-54,4-54", 1)]
    [InlineData("48-49,49-80", 0)]
    [InlineData("1-4,3-3", 1)]
    [InlineData("66-98,17-67", 0)]
    public void PartOne_ExampleTest2(string con, int expected)
    {
        var score = new DayFour(new[] { con }).PartOne();
        score.Should().Be(expected);
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var score = new DayFour(contents).PartOne();
        score.Should().Be(540);
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var score = new DayFour(contents).PartTwo();
        score.Should().Be(4);
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var score = new DayFour(contents).PartTwo();
        score.Should().Be(872);
    }
}