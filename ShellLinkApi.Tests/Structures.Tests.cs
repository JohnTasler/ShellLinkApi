using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShellLinkApi.Structures;
using System.Runtime.InteropServices;

namespace ShellLinkApi.Tests
{
    [TestClass]
    public class StructuresTests
    {
        [TestMethod]
        public void VerifyStructureSizes()
        {
            Assert.AreEqual(0x4C, Marshal.SizeOf<ShellLinkHeader>());
        }

        [TestMethod]
        public void ReadHeaderOfMyPCShortcut()
        {
            var shellLinkHeader = ReadHeader(@"C:\temp\This PC.lnk");
            Assert.AreEqual(0x4Cu, shellLinkHeader.HeaderSize);
        }

        public ShellLinkHeader ReadHeader(string fileName)
        {
            var buffer = new byte[Marshal.SizeOf<ShellLinkHeader>()];
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 0x1000, FileOptions.SequentialScan))
            {
                stream.Read(buffer, 0, buffer.Length);
            }

            var gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var bufferPointer = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
            var shellLinkHeader = Marshal.PtrToStructure<ShellLinkHeader>(bufferPointer);
            gcHandle.Free();

            return shellLinkHeader;
        }
    }
}
