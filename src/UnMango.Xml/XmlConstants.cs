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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLiteralDelimeter(byte character)
        {
            return character == '\'' || character == '"';
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameCharacter(byte character)
        {
            if (IsNameStartCharacter(character)) return true;

            switch (character)
            {
                case (byte)'-':
                case (byte)'.':
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
                case 0xB7:
                    return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameCharacter(short character)
        {
            if (IsNameStartCharacter(character)) return true;

            if (character >= 0x0300 && character <= 0x036F) return true;
            if (character >= 0x203F && character <= 0x2040) return true;

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameStartCharacter(byte character)
        {
            switch (character)
            {
                case (byte)':':
                case (byte)'_':
                    return true;
            }

            if (character >= 'A' && character <= 'Z') return true;
            if (character >= 'a' && character <= 'z') return true;
            if (character >= 0xC0 && character <= 0xD6) return true;
            if (character >= 0xD8 && character <= 0xF6) return true;

            return character >= 0xF8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameStartCharacter(short character)
        {
            if (character >= 0xF8 && character <= 0x2FF) return true;
            if (character >= 0x370 && character <= 0x37D) return true;
            if (character >= 0x37F && character <= 0x1FFF) return true;
            if (character >= 0x200C && character <= 0x200D) return true;
            if (character >= 0x200C && character <= 0x200D) return true;
            if (character >= 0x2C00 && character <= 0x2FEF) return true;
            if (character >= 0x2C00 && character <= 0x2FEF) return true;
            if (character >= 0x2C00 && character <= 0x2FEF) return true;
            if (character >= 0x2C00 && character <= 0x2FEF) return true;

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameStartCharacter(int character)
        {
            return character >= 0x10000 && character <= 0xEFFFF;
        }

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhiteSpace(byte @byte)
        {
            switch (@byte)
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
