﻿namespace AdventOfCode.Tests._23;

public class Day23Tests
{
    private const int Day = 23;

    [Fact(Skip = "Problem not out yet")]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new TempClass(contents).PartOne();
        result.Should().Be(0);
    }

    [Fact(Skip = "Problem not out yet")]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new TempClass(contents).PartOne();
        result.Should().Be(0);
    }

    [Fact(Skip = "Problem not out yet")]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var result = new TempClass(contents).PartTwo();
        result.Should().Be(0);
    }

    [Fact(Skip = "Problem not out yet")]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var result = new TempClass(contents).PartTwo();
        result.Should().Be(0);
    }
}