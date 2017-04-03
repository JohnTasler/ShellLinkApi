using System;
using System.IO;
using System.Runtime.InteropServices;
using ShellLinkApi.Extensions;
using ct = System.Runtime.InteropServices.ComTypes;

namespace ShellLinkApi.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ShellLinkHeader
    {
        /// <summary>
        /// The size, in bytes, of this structure. This value MUST be 0x0000004C.
        /// </summary>
        public readonly uint HeaderSize = Constants.LinkHeaderSize;

        /// <summary>
        /// A class identifier (CLSID). This value MUST be 00021401-0000-0000-C000-000000000046.
        /// </summary>
        public readonly Guid LinkCLSID = Constants.LinkHeaderCLSID;

        /// <summary>
        /// A LinkFlags structure (section 2.1.1) that specifies information about the shell link and the presence of optional portions of the structure.
        /// </summary>
        public Constants.LinkFlags LinkFlags;

        /// <summary>
        /// A FileAttributesFlags structure (section 2.1.2) that specifies information about the link target.
        /// </summary>
        public FileAttributes FileAttributes;

        public DateTime CreationTime
        {
            get { return _creationTime.ToDateTime(); }
            set { _creationTime = value.ToFileTimeStructure(); }
        }

        public DateTime AccessTime
        {
            get { return _accessTime.ToDateTime(); }
            set { _accessTime = value.ToFileTimeStructure(); }
        }

        public DateTime WriteTime
        {
            get { return _writeTime.ToDateTime(); }
            set { _writeTime = value.ToFileTimeStructure(); }
        }

        /// <summary>
        /// A FILETIME structure ([MS-DTYP] section 2.3.3) that specifies the creation time of the link target in UTC (Coordinated Universal Time). If the value is zero, there is no creation time set on the link target.
        /// </summary>
        private ct.FILETIME _creationTime;

        /// <summary>
        /// A FILETIME structure ([MS-DTYP] section 2.3.3) that specifies the access time of the link target in UTC (Coordinated Universal Time). If the value is zero, there is no access time set on the link target.
        /// </summary>
        private ct.FILETIME _accessTime;

        /// <summary>
        /// A FILETIME structure ([MS-DTYP] section 2.3.3) that specifies the write time of the link target in UTC (Coordinated Universal Time). If the value is zero, there is no write time set on the link target.
        /// </summary>
        private ct.FILETIME _writeTime;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the size, in bytes, of the link target. If the link target file is larger than 0xFFFFFFFF, this value specifies the least significant 32 bits of the link target file size.
        /// </summary>
        public uint FileSize;

        /// <summary>
        /// A 32-bit signed integer that specifies the index of an icon within a given icon location.
        /// </summary>
        public int IconIndex;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the expected window state of an application launched by the link. This value SHOULD be one of the following.
        /// </summary>
        public Constants.ShowCommand ShowCommand = Constants.ShowCommand.Normal;

        /// <summary>
        /// that specifies the keystrokes used to launch the application referenced by the shortcut key. This value is assigned to the application after it is launched, so that pressing the key activates that application.
        /// </summary>
        public HotKey HotKey;

        private readonly ushort Reserved1;
        private readonly uint Reserved2;
        private readonly uint Reserved3;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct HotKey
    {
        public Constants.HotKeys Key;
        public Constants.HotKeyModifiers Modifiers;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VolumeID
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CommonNetworkRelativeLink
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ExtraData
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ConsoleDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ConsoleFEDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DarwinDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EnvironmentVariableDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IconEnvironmentDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct KnownFolderDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PropertyStoreDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ShimDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SpecialFolderDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TrackerDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VistaAndAboveIDListDataBlock
    {
    }

}
