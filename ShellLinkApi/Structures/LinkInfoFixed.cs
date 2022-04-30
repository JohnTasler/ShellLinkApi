using System.Runtime.InteropServices;

namespace ShellLinkApi.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LinkInfoFixed
    {
        public uint LinkInfoSize;
        public uint LinkInfoHeaderSize;
        public LinkInfoFlags LinkInfoFlags;
        public uint VolumeIDOffset;
        public uint LocalBasePathOffset;
        public uint CommonNetworkRelativeLinkOffset;
        public uint CommonPathSuffixOffset;
        public uint OptionalLocalBasePathOffsetUnicode;
        public uint OptionalCommonPathSuffixOffsetUnicode;
    }
}
