using System;
using System.Collections.Generic;
using System.Linq;

namespace UnMango.Xml.Test;

internal static class TestHelper
{
    public static IEnumerable<(T, T)> CartesianProduct<T>(IEnumerable<T> first, IEnumerable<T> second)
    {
        foreach (var i in first)
        {
            foreach (var j in second)
            {
                yield return (i, j);
            }
        }
    }

    public static IEnumerable<object[]> SelectAsTestParameters<T, V>(
        this IEnumerable<T> source,
        Func<T, IEnumerable<V>> selector)
    {
        return source.Select(selector).Select(x => x.Cast<object>().ToArray());
    }

    public static IEnumerable<object[]> SelectAsTestParameters<T>(
        this IEnumerable<T> source,
        Func<T, string> selector)
    {
        return source.Select(selector).Select(x => new object[] { x });
    }

    public static IEnumerable<object[]> SelectAsTestParameters<T>(
        this IEnumerable<T> source,
        Func<T, object> selector)
    {
        return source.Select(selector).Select(x => new object[] { x });
    }
}