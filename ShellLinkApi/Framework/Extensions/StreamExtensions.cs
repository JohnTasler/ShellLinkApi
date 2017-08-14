using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ShellLinkApi.Extensions
{
    public static class StreamExtensions
    {
        public static T ReadStructure<T>(this Stream @this)
        {
            var buffer = new byte[Marshal.SizeOf<T>()];
            @this.Read(buffer, 0, buffer.Length);  // TODO: throw if not enough bytes could be read

            var gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                var bufferPointer = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                var structure = Marshal.PtrToStructure<T>(bufferPointer);
                return structure;
            }
            finally
            {
                gcHandle.Free();
            }
        }

        public static T ReadStructure<T>(this BinaryReader @this)
        {
            var buffer = @this.ReadBytes(Marshal.SizeOf<T>());
            var gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                var bufferPointer = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                var structure = Marshal.PtrToStructure<T>(bufferPointer);
                return structure;
            }
            finally
            {
                gcHandle.Free();
            }
        }
    }
}
