using AdventOfCode._02;

namespace AdventOfCode.Tests._02;

public class DayTwoTests
{
    [Fact]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(2, @"Input\Example.txt");
    }
}