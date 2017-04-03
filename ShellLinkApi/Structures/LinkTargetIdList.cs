using System.Runtime.InteropServices;

namespace ShellLinkApi.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class LinkTargetIDList
    {
        public ushort IDListSize;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class IDList
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ItemID
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class LinkInfo
    {
        public uint LinkInfoSize;
    }

}
