using System;
using System.Runtime.CompilerServices;

namespace UnMango.Xml
{
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
        /// Checks whether <paramref name="character"/> is a Char.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True is <paramref name="character"/> is a Char, False otherwise.</returns>
        /// <remarks>
        /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-Char
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsChar(byte character) => IsChar((char)character);

        /// <summary>
        /// Checks whether <paramref name="character"/> is a Char.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True is <paramref name="character"/> is a Char, False otherwise.</returns>
        /// <remarks>
        /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-Char
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsChar(char character)
        {
            switch (character)
            {
                case (char)0x9:
                case (char)0xA:
                case (char)0xD:
                    return true;
            }

            if (character >= 0x20 && character <= 0xD7FF) return true;
            if (character >= 0xE000 && character <= 0xFFFD) return true;
            if (character >= 0x10000 && character <= 0x10FFFF) return true;

            return false;
        }

        /// <summary>
        /// Checks whether <paramref name="character"/> is a literal delimeter.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if <paramref name="character"/> is a literal delimeter, False otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLiteralDelimeter(byte character)
        {
            return character == '\'' || character == '"';
        }

        /// <summary>
        /// Checks whether <paramref name="character"/> is a NameChar.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if <paramref name="character"/> is a NameChar, False otherwise.</returns>
        /// <remarks>
        /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameChar
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameCharacter(byte character)
        {
            return IsNameCharacter((char)character);
        }

        /// <summary>
        /// Checks whether the character specified by <paramref name="high"/>
        /// and <paramref name="low"/> is a NameChar.
        /// </summary>
        /// <param name="character"></param>
        /// <returns>True if the input is a NameChar, False otherwise.</returns>
        /// <remarks>
        /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameChar
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameCharacter(ReadOnlySpan<byte> character)
        {
            //return IsNameCharacter(BitConverter.ToChar(character));
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks whether <paramref name="character"/> is a NameChar.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if <paramref name="character"/> is a NameChar, False otherwise.</returns>
        /// <remarks>
        /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameChar
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameCharacter(char character)
        {
            if (IsNameStartCharacter(character)) return true;

            switch (character)
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

            if (character >= 0x0300 && character <= 0x036F) return true;
            if (character >= 0x203F && character <= 0x2040) return true;

            return false;
        }

        /// <summary>
        /// Checks whether <paramref name="character"/> is a NameStartChar.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if <paramref name="character"/> is a NameStartChar, False otherwise.</returns>
        /// <remarks>
        /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameStartChar
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameStartCharacter(byte character)
        {
            return IsNameStartCharacter((char)character);
        }

        /// <summary>
        /// Checks whether <paramref name="character"/> is a NameStartChar.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if the character is a NameStartChar, False otherwise.</returns>
        /// <remarks>
        /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-NameStartChar
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameStartCharacter(char character)
        {
            switch (character)
            {
                case ':':
                case '_':
                    return true;
            }

            if (character >= 'A' && character <= 'Z') return true;
            if (character >= 'a' && character <= 'z') return true;
            if (character >= 0xC0 && character <= 0xD6) return true;
            if (character >= 0xD8 && character <= 0xF6) return true;
            if (character >= 0xF8 && character <= 0x2FF) return true;
            if (character >= 0x370 && character <= 0x37D) return true;
            if (character >= 0x37F && character <= 0x1FFF) return true;
            if (character >= 0x200C && character <= 0x200D) return true;
            if (character >= 0x200C && character <= 0x200D) return true;
            if (character >= 0x2C00 && character <= 0x2FEF) return true;
            if (character >= 0x2C00 && character <= 0x2FEF) return true;
            if (character >= 0x2C00 && character <= 0x2FEF) return true;
            if (character >= 0x2C00 && character <= 0x2FEF) return true;
            if (character >= 0x10000 && character <= 0xEFFFF) return true;

            return false;
        }

        /// <summary>
        /// Checks whether <paramref name="character"/> is a PubidChar.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if <paramref name="character"/> is a PubidChar, False otherwise.</returns>
        /// <remarks>
        /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-PubidChar
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPubidCharacter(byte character)
        {
            switch (character)
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

            if (character >= 'a' && character <= 'z') return true;
            if (character >= 'A' && character <= 'Z') return true;

            return false;
        }

        /// <summary>
        /// Checks whether <paramref name="character"/> is White Space.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if <paramref name="character"/> is White Space, false otherwise.</returns>
        /// <remarks>
        /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-S
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhiteSpace(byte character)
        {
            switch (character)
            {
                case Space:
                case CarriageReturn:
                case LineFeed:
                case Tab:
                    return true;
            }

            return false;
        }
    }
}
