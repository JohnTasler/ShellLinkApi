using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShellLinkApi.Structures;
using ShellLinkApi.Extensions;
using System.Runtime.InteropServices;

namespace ShellLinkApi.Tests
{
    [TestClass]
    public class ShellLinkHeaderTests
    {
        [TestMethod]
        public void VerifyStructureSizes()
        {
            Assert.AreEqual(0x4C, Marshal.SizeOf<ShellLinkHeader>());
        }

        [TestMethod]
        public void ReadHeaderOfMyPCShortcut()
        {
            using (var stream = OpenFileStreamForReading(@"C:\temp\This PC.lnk"))
            {
                var shellLinkHeader = stream.ReadStructure<ShellLinkHeader>();
                Assert.AreEqual(0x4Cu, shellLinkHeader.HeaderSize);
            }
        }

        [TestMethod]
        public void ReadHeaderOfTaskManagerShortcut()
        {
            var shellLink = new ShellLink(@"C:\temp\Task Manager.lnk");
            Assert.AreEqual(0x4Cu, shellLink.ShellLinkHeader.HeaderSize);
        }

        private static FileStream OpenFileStreamForReading(string fileName)
        {
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 0x1000, FileOptions.SequentialScan);
        }
    }
}
