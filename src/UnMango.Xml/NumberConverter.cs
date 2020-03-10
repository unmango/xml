using System.Runtime.CompilerServices;

namespace UnMango.Xml
{
    internal static class NumberConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToInt16(byte first, byte second)
        {
            return (short)((first << 8) | second);
        }
    }
}
