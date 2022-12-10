using System.Text;
using AdventOfCode._06;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

// ReSharper disable MemberCanBePrivate.Global

namespace AdventOfCode.Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class DaySixBenchmark
{
    private readonly string _input;
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public DaySixBenchmark()
    {
        _input = CreateInput(UniqueSize, PrefixSize);
    }

    [Params(4, 14)] public int UniqueSize { get; set; }
    [Params(1000, 2000000)] public int PrefixSize { get; set; }

    [Benchmark]
    public int FindStartOfPacket()
    {
        return DaySix.FindStartOfPacket(_input, UniqueSize);
    }

    public static string CreateInput(int uniqueSize, int prefixSize)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < prefixSize; i++)
        {
            sb.Append(Alphabet[..(uniqueSize - 2)]);
        }

        sb.Append(Alphabet[..uniqueSize]);
        return sb.ToString();
    }
}