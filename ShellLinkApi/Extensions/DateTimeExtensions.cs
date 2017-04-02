using System;
using System.Runtime.InteropServices.ComTypes;

namespace ShellLinkApi.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToLong(this FILETIME @this)
        {
            return ((long)@this.dwHighDateTime << 32) | (uint)(@this.dwLowDateTime);
        }

        public static DateTime ToDateTime(this FILETIME @this)
        {
            return DateTime.FromFileTime(@this.ToLong());
        }

        public static FILETIME ToFileTimeStructure(this DateTime @this)
        {
            var ticks = @this.Ticks;
            return new FILETIME
            {
                dwHighDateTime = (int)(ticks >> 32),
                dwLowDateTime = (int)(ticks & uint.MaxValue),
            };
        }
    }
}
