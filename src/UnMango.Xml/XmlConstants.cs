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

        public const byte OpenElement = (byte)'<';
        public const byte CloseElement = (byte)'>';

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLiteralDelimeter(byte @byte)
        {
            return @byte == '\'' || @byte == '"';
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameCharacter(byte @byte)
        {
            if (IsNameStartCharacter(@byte)) return true;

            switch (@byte)
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

            // TODO
            if (@byte >= 0x0300 && @byte <= 0x036F) return true;
            if (@byte >= 0x203F && @byte <= 0x2040) return true;

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNameStartCharacter(byte @byte)
        {
            switch (@byte)
            {
                case (byte)':':
                case (byte)'_':
                    return true;
            }

            if (@byte >= 'A' && @byte <= 'Z') return true;
            if (@byte >= 0xC0 && @byte <= 0xD6) return true;
            if (@byte >= 0xD8 && @byte <= 0xF6) return true;

            // TODO
            if (@byte >= 0xF8 && @byte <= 0x2FF) return true;
            if (@byte >= 0x370 && @byte <= 0x37D) return true;
            if (@byte >= 0x37F && @byte <= 0x1FFF) return true;
            if (@byte >= 0x200C && @byte <= 0x200D) return true;
            if (@byte >= 0x200C && @byte <= 0x200D) return true;
            if (@byte >= 0x2C00 && @byte <= 0x2FEF) return true;
            if (@byte >= 0x2C00 && @byte <= 0x2FEF) return true;
            if (@byte >= 0x2C00 && @byte <= 0x2FEF) return true;
            if (@byte >= 0x2C00 && @byte <= 0x2FEF) return true;
            if (@byte >= 0x10000 && @byte <= 0xEFFFF) return true;

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPubidCharacter(byte @byte)
        {
            switch (@byte)
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

            if (@byte >= 'a' && @byte <= 'z') return true;
            if (@byte >= 'A' && @byte <= 'Z') return true;

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
