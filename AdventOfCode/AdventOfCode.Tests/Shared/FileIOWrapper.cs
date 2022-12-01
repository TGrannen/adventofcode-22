namespace AdventOfCode.Tests.Shared;

public static class FileIOWrapper
{
    private const string BasePath = @"..\..\..";

    public static Task<string[]> ReadAllLinesAsync(int day, string path)
    {
        return File.ReadAllLinesAsync(GetFullPath(day, path));
    }

    public static Task<string> ReadAllTextAsync(int day, string path)
    {
        return File.ReadAllTextAsync(GetFullPath(day, path));
    }

    private static string GetFullPath(int day, string path)
    {
        return Path.Combine($@"{BasePath}\{day:00}\", path);
    }
}