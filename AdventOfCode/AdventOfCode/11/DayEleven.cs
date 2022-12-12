namespace AdventOfCode._11;

public class DayEleven
{
    private readonly Monkey[] _monkeys;

    public DayEleven(IEnumerable<string> contents)
    {
        _monkeys = contents.SplitOn(string.IsNullOrEmpty).Select(x => new Monkey(x.ToArray())).ToArray();
    }

    public long GetMonkeyBusiness()
    {
        var values = _monkeys.OrderByDescending(x => x.ProcessCount).Select(x => x.ProcessCount).Take(2).ToArray();
        return values[0] * values[1];
    }

    public Monkey[] Process(int numberOfRounds, bool divideByThree)
    {
        var productOfDivisors = _monkeys.Select(x => x.Divisor).Aggregate(1, (x, y) => x * y);
        Func<long, long> managementFunc = divideByThree ? l => l / 3 : l => l % productOfDivisors;

        for (var i = 0; i < numberOfRounds; i++)
        {
            foreach (var monkey in _monkeys.Where(x => x.Items.Any()))
            {
                monkey.Process(_monkeys, managementFunc);
            }
        }

        return _monkeys;
    }
}

public class Monkey
{
    public Monkey(string[] details)
    {
        Number = int.Parse(details[0].Replace("Monkey ", "").Replace(":", ""));
        foreach (var num in details[1].Replace("Starting items: ", "").Split(",").Select(int.Parse).ToList())
        {
            Items.Enqueue(num);
        }

        var split = details[2].Replace("  Operation: new = ", "").Split(" ").ToArray();
        _first = split[0];
        _second = split[2];
        _operatorSymbol = split[1];
        Divisor = int.Parse(details[3][21..]);
        var trueNumber = int.Parse(details[4][29..]);
        var falseNumber = int.Parse(details[5][30..]);
        ToThrowTo = item => item % Divisor == 0 ? trueNumber : falseNumber;
    }

    public int Number { get; }
    public int Divisor { get; }
    public Queue<long> Items { get; } = new();
    private Func<long, int> ToThrowTo { get; }
    public long ProcessCount { get; private set; }

    private readonly string _first;
    private readonly string _second;
    private readonly string _operatorSymbol;

    public void Process(Monkey[] monkeys, Func<long, long> managementFunc)
    {
        while (Items.Any())
        {
            var item = Items.Dequeue();
            var first = _first == "old" ? item : long.Parse(_first);
            var second = _second == "old" ? item : long.Parse(_second);
            var newLevel = _operatorSymbol switch
            {
                "+" => first + second,
                "-" => first - second,
                "*" => first * second,
                "/" => first / second
            };
            item = managementFunc(newLevel);
            monkeys[ToThrowTo(item)].Items.Enqueue(item);
            ProcessCount++;
        }
    }
}