using System;
using System.Runtime.InteropServices;

namespace ShellLinkApi.Extensions
{
    public static class IntPtrExtensions
    {
        public static bool IsContentEqual(this IntPtr @this, long thisByteCount, IntPtr that, long thatByteCount)
        {
            if (thisByteCount != thatByteCount)
            {
                return false;
            }

            var thisEndPointer = (IntPtr)((long)@this + thisByteCount);
            while (@this.ToInt64() < thisEndPointer.ToInt64()
                && Marshal.ReadByte(@this) == Marshal.ReadByte(that))
            {
                @this += 1;
                that += 1;
            }

            return @this == thisEndPointer;
        }
    }
}
