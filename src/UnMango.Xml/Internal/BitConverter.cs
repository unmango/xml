using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnMango.Xml.Internal
{
    /// <summary>
    /// https://github.com/dotnet/runtime/blob/5ea5b57374363b1cd8bdecc04d6cd6ba0290db50/src/libraries/System.Private.CoreLib/src/System/BitConverter.cs
    /// </summary>
    internal static class BitConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(ReadOnlySpan<byte> value)
        {
            if (value.Length < sizeof(char))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return Unsafe.ReadUnaligned<char>(ref MemoryMarshal.GetReference(value));
        }
    }
}
