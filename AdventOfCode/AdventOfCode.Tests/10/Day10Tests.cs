using AdventOfCode._10;

namespace AdventOfCode.Tests._10;

[UsesVerify]
public class Day10Tests
{
    private const int Day = 10;

    [Fact]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new DayTen(contents).PartOne();
        result.Should().Be(13140);
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new DayTen(contents).PartOne();
        result.Should().Be(15260);
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var lines = new DayTen(contents).PartTwo();
        await Verify(string.Join(Environment.NewLine, lines)).UseDirectory("Snapshots");
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var lines = new DayTen(contents).PartTwo();
        await Verify(string.Join(Environment.NewLine, lines)).UseDirectory("Snapshots");
    }

    [Fact]
    public void PartOne_ExampleTest_ShouldHaveLastNumber()
    {
        var basic = new[]
        {
            "noop",
            "addx 3",
            "addx -5"
        };
        var result = new DayTen(basic).LastCycleValue();
        result.Should().Be(-1);
    }

    [Fact]
    public async Task PartOne_ShouldHaveDuringValues()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        await Verify(new DayTen(contents).Cycles.Take(22)
            .Select(x => string.Join(" - ", new object[]
            {
                x.Number,
                x.StartingValue,
                x.FinalValue,
                x.Instruction
            }))).UseDirectory("Snapshots");
    }

    [Fact]
    public async Task PartOne_ShouldHaveSignalValues()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        await Verify(new DayTen(contents).Cycles
            .Where(x => x.Number % 20 == 0)
            .Select(x => string.Join(" - ", new[]
            {
                x.Number,
                x.StartingValue,
                x.FinalValue
            }))).UseDirectory("Snapshots");
    }
}