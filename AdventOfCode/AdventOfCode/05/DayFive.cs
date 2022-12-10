using System.Text.RegularExpressions;

namespace AdventOfCode._05;

public record Command(int Count, int Start, int End);

public record Input(Stack<char>[] Stacks, Command[] Commands);

public class DayFive
{
    private readonly Input _input;

    public DayFive(IEnumerable<string> lines)
    {
        _input = InputParser.Parse(lines);
    }

    public string PartOne()
    {
        foreach (var command in _input.Commands)
        {
            for (var i = 0; i < command.Count; i++)
            {
                _input.Stacks[command.End - 1].Push(_input.Stacks[command.Start - 1].Pop());
            }
        }

        return string.Join("", _input.Stacks.Select(x => x.Peek()));
    }

    public string PartTwo()
    {
        var tempStack = new Stack<char>();
        foreach (var command in _input.Commands)
        {
            for (var i = 0; i < command.Count; i++)
            {
                tempStack.Push(_input.Stacks[command.Start - 1].Pop());
            }

            for (var i = 0; i < command.Count; i++)
            {
                _input.Stacks[command.End - 1].Push(tempStack.Pop());
            }
        }

        return string.Join("", _input.Stacks.Select(x => x.Peek()));
    }
}

public static class InputParser
{
    private static readonly Regex Regex = new(" (?=[1-9])[0-9]*");

    public static Input Parse(IEnumerable<string> lines)
    {
        var sections = lines.SplitOn(x => x == string.Empty).ToList();
        return new Input(BuildStacks(sections[0].ToArray()), BuildCommands(sections[1]));
    }

    private static Stack<char>[] BuildStacks(string[] lines)
    {
        var count = lines.Last().Split(" ").Select(x => int.TryParse(x, out var i) ? i : 0).Max();
        var stacks = Enumerable.Range(0, count).Select(_ => new Stack<char>()).ToArray();

        foreach (var line in lines.Select(x => x).Reverse().Skip(1))
        {
            var index = 0;
            while (line.Length > index * 4 + 1)
            {
                var columnIndex = index * 4 + 1;
                if (line[columnIndex] != ' ')
                {
                    stacks[index].Push(line[columnIndex]);
                }

                index++;
            }
        }

        return stacks;
    }

    private static Command[] BuildCommands(IEnumerable<string> sections)
    {
        return sections.Select(x =>
        {
            var numbers = Regex.Matches(x).Select(m => int.Parse(m.Value)).ToList();
            return new Command(numbers[0], numbers[1], numbers[2]);
        }).ToArray();
    }
}