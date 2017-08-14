using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Linq;

namespace ShellLinkApi.Tests.Framework
{
    internal static class TestExtensions
    {
        public static string GetMethodInputFilePath(this TestContext testContext, MethodBase methodInfo)
        {
            var deploymentItem = methodInfo.GetCustomAttributes<DeploymentItemAttribute>().Single();
            return Path.Combine(testContext.DeploymentDirectory, deploymentItem.OutputDirectory, Path.GetFileName(deploymentItem.Path));
        }

        public static FileStream OpenFileStreamForReading(this TestContext testContext, MethodBase methodInfo)
        {
            var fileName = testContext.GetMethodInputFilePath(methodInfo);
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 0x1000, FileOptions.SequentialScan);
        }
    }
}
