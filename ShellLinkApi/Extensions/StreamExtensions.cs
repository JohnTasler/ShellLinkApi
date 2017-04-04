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
            var bufferPointer = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
            var structure = Marshal.PtrToStructure<T>(bufferPointer);
            gcHandle.Free();

            return structure;
        }

        public static string ReadString(this Stream @this)
        {
            return @this.ReadString(Encoding.Unicode);
        }

        public static string ReadString(this Stream @this, Encoding encoding)
        {
            using (var reader = new BinaryReader(@this, encoding, true))
            {
                ushort countCharacters = reader.ReadUInt16();
                var chars = reader.ReadChars(countCharacters);
                return new string(chars);
            }
        }
    }
}
