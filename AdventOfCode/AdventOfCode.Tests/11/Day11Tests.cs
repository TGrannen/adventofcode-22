using AdventOfCode._11;

namespace AdventOfCode.Tests._11;

[UsesVerify]
public class Day11Tests
{
    private const int Day = 11;

    [Fact]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var dayEleven = new DayEleven(contents);
        dayEleven.Process(20, true);
        dayEleven.GetMonkeyBusiness().Should().Be(10605);
    }

    [Fact]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var dayEleven = new DayEleven(contents);
        dayEleven.Process(20, true);
        dayEleven.GetMonkeyBusiness().Should().Be(57348);
    }

    [Fact]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var dayEleven = new DayEleven(contents);
        dayEleven.Process(10_000, false);
        dayEleven.GetMonkeyBusiness().Should().Be(2713310158);
    }

    [Fact]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var dayEleven = new DayEleven(contents);
        dayEleven.Process(10_000, false);
        dayEleven.GetMonkeyBusiness().Should().Be(14106266886);
    }

    [Fact]
    public async Task Monkeys_ShouldHaveProcessCounts_AfterRounds()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");

        await Verify(new
        {
            _1 = new DayEleven(contents).Process(1, false).Select(x => $"{x.Number} - {x.ProcessCount}"),
            _20 = new DayEleven(contents).Process(20, false).Select(x => $"{x.Number} - {x.ProcessCount}"),
            _1000 = new DayEleven(contents).Process(1000, false).Select(x => $"{x.Number} - {x.ProcessCount}"),
            _5000 = new DayEleven(contents).Process(5_000, false).Select(x => $"{x.Number} - {x.ProcessCount}"),
            _10000 = new DayEleven(contents).Process(10_000, false).Select(x => $"{x.Number} - {x.ProcessCount}"),
        }).UseDirectory("Snapshots");
    }
}