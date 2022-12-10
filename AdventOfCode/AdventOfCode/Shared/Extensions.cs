namespace AdventOfCode.Shared;

public static class Extensions
{
    /// <summary>
    /// Splits a collection of items into a collection of collections of items based on the function parmater
    /// </summary>
    /// <param name="objects"></param>
    /// <param name="predicate"></param>
    /// <param name="includeInResult">Include the item that matches the predicate as the first item in the next set</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<List<T>> SplitOn<T>(this IEnumerable<T> objects, Func<T, bool> predicate, bool includeInResult = false)
    {
        var currentItems = new List<T>();
        foreach (var item in objects)
        {
            if (!predicate(item))
            {
                currentItems.Add(item);
                continue;
            }

            if (currentItems.Any())
            {
                yield return currentItems;
                currentItems = new List<T>();
            }

            if (includeInResult)
            {
                currentItems.Add(item);
            }
        }

        yield return currentItems;
    }

    public static T[][] Slice<T>(this IEnumerable<T> source, int chunkSize)
    {
        var i = 0;
        var result = source.GroupBy(s => i++ / chunkSize).Select(g => g.ToArray()).ToArray();
        return result;
    }
}