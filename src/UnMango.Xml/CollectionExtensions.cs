using System.Collections.Generic;
using System.Linq;

namespace UnMango.Xml;

internal static class CollectionExtensions
{
    public static IReadOnlyDictionary<TKey, TValue> With<TKey, TValue>(
        this IReadOnlyDictionary<TKey, TValue> dictionary,
        TKey key,
        TValue value) where TKey : notnull
    {
        var next = dictionary.ToDictionary(pair => pair.Key, pair => pair.Value);
        next.Add(key, value);
        return next;
    }
}
