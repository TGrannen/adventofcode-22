﻿namespace AdventOfCode.Tests._09;

public class DayNineTests
{
    private const int Day = 9;

    [Fact(Skip = "Problem not out yet")]
    public async Task PartOne_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var score = new TempClass(contents).PartOne();
        score.Should().Be(0);
    }

    [Fact(Skip = "Problem not out yet")]
    public async Task PartOne_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var score = new TempClass(contents).PartOne();
        score.Should().Be(0);
    }

    [Fact(Skip = "Problem not out yet")]
    public async Task PartTwo_ExampleTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Example.txt");
        var score = new TempClass(contents).PartTwo();
        score.Should().Be(0);
    }

    [Fact(Skip = "Problem not out yet")]
    public async Task PartTwo_ProblemTest()
    {
        var contents = await FileIOWrapper.ReadAllLinesAsync(Day, @"Input\Problem.txt");
        var score = new TempClass(contents).PartTwo();
        score.Should().Be(0);
    }
}