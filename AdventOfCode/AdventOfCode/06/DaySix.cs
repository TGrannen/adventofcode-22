namespace AdventOfCode._06;

public static class DaySix
{
    public static int PartOne(string input)
    {
        return FindStartOfPacket(input, 4);
    }

    public static int PartTwo(string input)
    {
        return FindStartOfPacket(input, 14);
    }

    private static int FindStartOfPacket(string input, int numberOfUniqueChars)
    {
        var index = numberOfUniqueChars;
        while (index < input.Length)
        {
            var charChunk = input[(index - numberOfUniqueChars)..index];
            if (charChunk.Distinct().Count() == numberOfUniqueChars)
                return index;
            index++;
        }

        return 0;
    }
}