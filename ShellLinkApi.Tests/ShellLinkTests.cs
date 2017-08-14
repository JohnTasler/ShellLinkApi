using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShellLinkApi.Structures;
using ShellLinkApi.Tests.Framework;
using System.Reflection;

namespace ShellLinkApi.Tests
{
    [TestClass]
    public class ShellLinkTests
    {
        [TestMethod]
        [DeploymentItem(TestConstants.InputFileFolderPath + "Task Manager.lnk", TestConstants.InputFileFolderName)]
        public void ReadTaskManagerShortcut()
        {
            var shellLink = new ShellLink(TestContext.GetMethodInputFilePath(MethodBase.GetCurrentMethod()));
            shellLink.ShellLinkHeader.AssertCommonFieldsAreValid();
        }

        [TestMethod]
        [DeploymentItem(TestConstants.InputFileFolderPath + "test command.lnk", TestConstants.InputFileFolderName)]
        public void ReadShortcutWithIDList()
        {
            var shellLink = new ShellLink(TestContext.GetMethodInputFilePath(MethodBase.GetCurrentMethod()));
            shellLink.ShellLinkHeader.AssertCommonFieldsAreValid();
        }

        public TestContext TestContext { get; set; }
    }
}
