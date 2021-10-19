namespace UnMango.Xml.Test;

internal static class TestData
{
    public static readonly char[] ValidNameCharacters = new[]
    {
        '-', '.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };

    public static readonly char[] InvalidNameCharacters = new[]
    {
        ';', '^', '`', '@', '['
    };

    public static readonly char[] ValidStartNameCharacters = new[]
    {
        ':', 'A', 'Z', '_', 'a', 'z'
    };

    public static readonly char[] InvalidStartNameCharacters = new[]
    {
        '9', ';', '^', '`', '@', '['
    };
}