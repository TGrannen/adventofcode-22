namespace AdventOfCode.Shared;

public static class Extensions
{
    public static IEnumerable<List<T>> SplitOn<T>(this IEnumerable<T> objects, Func<T, bool> predicate)
    {
        var currentItems = new List<T>();
        foreach (var item in objects)
        {
            if (!predicate(item))
            {
                currentItems.Add(item);
                continue;
            }

            yield return currentItems;
            currentItems = new List<T>();
        }

        yield return currentItems;
    }
}