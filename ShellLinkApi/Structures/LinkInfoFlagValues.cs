using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShellLinkApi.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class LinkInfoFlags
    {
        public LinkInfoFlagValues Value;
    }

    [Flags]
    public enum LinkInfoFlagValues : uint
    {
        VolumeIDAndLocalBasePath = 1,
        CommonNetworkRelativeLinkAndPathSuffix = 2,
    }
}


