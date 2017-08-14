using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShellLinkApi.Structures;
using ShellLinkApi.Extensions;
using ShellLinkApi.Tests.Framework;
using System.Reflection;

namespace ShellLinkApi.Tests
{
    [TestClass]
    public class ShellLinkHeaderTests
    {
        [TestMethod]
        public void VerifyStructureSize()
        {
            Assert.AreEqual(Constants.LinkHeaderSize, (uint)Marshal.SizeOf<ShellLinkHeader>());
        }

        [TestMethod]
        [DeploymentItem(TestConstants.InputFileFolderPath + "This PC.lnk", TestConstants.InputFileFolderName)]
        public void ReadShortcutHeader()
        {
            using (var stream = TestContext.OpenFileStreamForReading(MethodBase.GetCurrentMethod()))
            {
                var shellLinkHeader = stream.ReadStructure<ShellLinkHeader>();
                shellLinkHeader.AssertCommonFieldsAreValid();
            }
        }

        public TestContext TestContext { get; set; }
    }
    internal static class ShellLinkHeaderExtensions
    {
        public static void AssertCommonFieldsAreValid(this ShellLinkHeader @this)
        {
            Assert.AreEqual(Constants.LinkHeaderSize, @this.HeaderSize);
            Assert.AreEqual(Constants.LinkHeaderCLSID, @this.LinkCLSID);
        }
    }
}
