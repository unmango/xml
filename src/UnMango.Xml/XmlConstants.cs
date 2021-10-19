using System;
using System.Runtime.CompilerServices;

// ReSharper disable ConvertIfStatementToReturnStatement

namespace UnMango.Xml;

using BitConverter =
#if NETSTANDARD2_0
    // NetStandard 2.0 System.BitConverter doesn't have ReadOnlySpan<byte> overloads
    Internal.BitConverter;
#else
    // ReSharper disable once RedundantNameQualifier
    System.BitConverter;
#endif

internal static class XmlConstants
{
    // Whitespace
    public const byte Space = (byte)' ';
    public const byte CarriageReturn = (byte)'\r';
    public const byte LineFeed = (byte)'\n';
    public const byte Tab = (byte)'\t';

    // Xml
    public const byte OpenElement = (byte)'<';
    public const byte CloseElement = (byte)'>';

    /// <summary>
    /// Checks whether <paramref name="value"/> is a Char.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True if <paramref name="value"/> is a Char, False otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-Char
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsChar(byte value) => IsChar((char)value);

    /// <summary>
    /// Checks whether <paramref name="value"/> is a Char.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True if <paramref name="value"/> is a Char, False otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-Char
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsChar(ReadOnlySpan<byte> value)
    {
        return IsChar(BitConverter.ToChar(value));
    }

    /// <summary>
    /// Checks whether <paramref name="value"/> is a Char.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True is <paramref name="value"/> is a Char, False otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-Char
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsChar(char value)
    {
        switch (value)
        {
            case (char)0x9:
            case (char)0xA:
            case (char)0xD:
                return true;
        }

        if (value >= 0x20 && value <= 0xD7FF) return true;
        if (value >= 0xE000 && value <= 0xFFFD) return true;
        if (value >= 0x10000 && value <= 0x10FFFF) return true;

        return false;
    }

    /// <summary>
    /// Checks whether <paramref name="value"/> is a literal delimiter.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True if <paramref name="value"/> is a literal delimiter, False otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLiteralDelimiter(byte value)
    {
        return value == '\'' || value == '"';
    }

    /// <summary>
    /// Checks whether <paramref name="value"/> is a NameChar.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True if <paramref name="value"/> is a NameChar, False otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameChar
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNameCharacter(byte value)
    {
        return IsNameCharacter((char)value);
    }

    /// <summary>
    /// Checks whether <paramref name="value"/> is a NameChar.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>True if the input is a NameChar, False otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameChar
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNameCharacter(in ReadOnlySpan<byte> value)
    {
        return IsNameCharacter(BitConverter.ToChar(value));
    }

    /// <summary>
    /// Checks whether <paramref name="value"/> is a NameChar.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True if <paramref name="value"/> is a NameChar, False otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameChar
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNameCharacter(char value)
    {
        if (IsNameStartCharacter(value)) return true;

        switch (value)
        {
            case '-':
            case '.':
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
            case (char)0xB7:
                return true;
        }

        if (value >= 0x0300 && value <= 0x036F) return true;
        if (value >= 0x203F && value <= 0x2040) return true;

        return false;
    }

    /// <summary>
    /// Checks whether <paramref name="value"/> is a NameStartChar.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True if <paramref name="value"/> is a NameStartChar, False otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameStartChar
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNameStartCharacter(byte value)
    {
        return IsNameStartCharacter((char)value);
    }

    /// <summary>
    /// Checks whether <paramref name="value"/> is a NameStartChar.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True if <paramref name="value"/> is a NameStartChar, False otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameStartChar
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNameStartCharacter(ReadOnlySpan<byte> value)
    {
        return IsNameStartCharacter(BitConverter.ToChar(value));
    }

    /// <summary>
    /// Checks whether <paramref name="value"/> is a NameStartChar.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True if the character is a NameStartChar, False otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameStartChar
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNameStartCharacter(char value)
    {
        switch (value)
        {
            case ':':
            case '_':
            case >= 'A' and <= 'Z':
            case >= 'a' and <= 'z':
                return true;
        }

        if (value >= 0xC0 && value <= 0xD6) return true;
        if (value >= 0xD8 && value <= 0xF6) return true;
        if (value >= 0xF8 && value <= 0x2FF) return true;
        if (value >= 0x370 && value <= 0x37D) return true;
        if (value >= 0x37F && value <= 0x1FFF) return true;
        if (value >= 0x200C && value <= 0x200D) return true;
        if (value >= 0x200C && value <= 0x200D) return true;
        if (value >= 0x2C00 && value <= 0x2FEF) return true;
        if (value >= 0x2C00 && value <= 0x2FEF) return true;
        if (value >= 0x2C00 && value <= 0x2FEF) return true;
        if (value >= 0x2C00 && value <= 0x2FEF) return true;
        if (value >= 0x10000 && value <= 0xEFFFF) return true;

        return false;
    }

    /// <summary>
    /// Checks whether <paramref name="value"/> is a PubidChar.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True if <paramref name="value"/> is a PubidChar, False otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-PubidChar
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPubidCharacter(byte value)
    {
        switch (value)
        {
            case 0x20:
            case 0xD:
            case 0xA:
            case (byte)'0':
            case (byte)'1':
            case (byte)'2':
            case (byte)'3':
            case (byte)'4':
            case (byte)'5':
            case (byte)'6':
            case (byte)'7':
            case (byte)'8':
            case (byte)'9':
            case (byte)'-':
            case (byte)'\'':
            case (byte)'(':
            case (byte)')':
            case (byte)'+':
            case (byte)',':
            case (byte)'.':
            case (byte)'/':
            case (byte)':':
            case (byte)'=':
            case (byte)'?':
            case (byte)';':
            case (byte)'!':
            case (byte)'*':
            case (byte)'#':
            case (byte)'@':
            case (byte)'$':
            case (byte)'_':
            case (byte)'%':
                return true;
        }

        if (value >= 'a' && value <= 'z') return true;
        if (value >= 'A' && value <= 'Z') return true;

        return false;
    }

    /// <summary>
    /// Checks whether <paramref name="value"/> is White Space.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns>True if <paramref name="value"/> is White Space, false otherwise.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-S
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpace(byte value)
    {
        switch (value)
        {
            case Space:
            case CarriageReturn:
            case LineFeed:
            case Tab:
                return true;
        }

        return false;
    }

    /// <summary>
    /// Swap between ' and ".
    /// </summary>
    /// <param name="literal">The initial literal.</param>
    /// <returns>The literal opposite to <paramref name="literal"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte SwapLiteral(byte literal)
    {
        return (byte)(~literal ^ 0x8F);
    }
}
