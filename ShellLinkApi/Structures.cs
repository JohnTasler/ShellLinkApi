﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ShortcutLinkApi.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class ShellLinkHeader
    {
        /// <summary>
        /// The size, in bytes, of this structure. This value MUST be 0x0000004C.
        /// </summary>
        public readonly uint HeaderSize = 0x0000004C;

        /// <summary>
        /// A class identifier (CLSID). This value MUST be 00021401-0000-0000-C000-000000000046.
        /// </summary>
        public readonly Guid LinkCLSID = new Guid("00021401-0000-0000-C000-000000000046");

        /// <summary>
        /// A LinkFlags structure (section 2.1.1) that specifies information about the shell link and the presence of optional portions of the structure.
        /// </summary>
        public LinkFlags LinkFlags;

        /// <summary>
        /// A FileAttributesFlags structure (section 2.1.2) that specifies information about the link target.
        /// </summary>
        public FileAttributes FileAttributes;

        /// <summary>
        /// A FILETIME structure ([MS-DTYP] section 2.3.3) that specifies the creation time of the link target in UTC (Coordinated Universal Time). If the value is zero, there is no creation time set on the link target.
        /// </summary>
        public FILETIME CreationTime;

        /// <summary>
        /// A FILETIME structure ([MS-DTYP] section 2.3.3) that specifies the access time of the link target in UTC (Coordinated Universal Time). If the value is zero, there is no access time set on the link target.
        /// </summary>
        public FILETIME AccessTime;

        /// <summary>
        /// A FILETIME structure ([MS-DTYP] section 2.3.3) that specifies the write time of the link target in UTC (Coordinated Universal Time). If the value is zero, there is no write time set on the link target.
        /// </summary>
        public FILETIME WriteTime;

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
        ShowCommand ShowCommand;

        /// <summary>
        /// that specifies the keystrokes used to launch the application referenced by the shortcut key. This value is assigned to the application after it is launched, so that pressing the key activates that application.
        /// </summary>
        public HotKey HotKey;

        private ushort Reserved1;
        private uint Reserved2;
        private uint Reserved3;
    }

    /// <summary>
    /// The expected window state of an application launched by the link.
    /// </summary>
    public enum ShowCommand : uint
    {
        Normal = 1,
        Maximized = 3,
        Minimized = 7,
    }

    [Flags]
    public enum LinkFlags : uint
    {
        /// <summary>
        /// The shell link is saved with an item ID list (IDList). If this bit is set, a LinkTargetIDList structure (section 2.2) MUST follow the ShellLinkHeader. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        HasLinkTargetIDList = 0x00000001,

        /// <summary>
        /// The shell link is saved with link information. If this bit is set, a LinkInfo structure (section 2.3) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        HasLinkInfo = 0x00000002,

        /// <summary>
        /// The shell link is saved with a name string. If this bit is set, a NAME_STRING StringData structure (section 2.4) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        HasName = 0x00000004,

        /// <summary>
        /// The shell link is saved with a relative path string. If this bit is set, a RELATIVE_PATH StringData structure (section 2.4) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        HasRelativePath = 0x00000008,

        /// <summary>
        /// The shell link is saved with a working directory string. If this bit is set, a WORKING_DIR StringData structure (section 2.4) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        HasWorkingDir = 0x00000010,

        /// <summary>
        /// The shell link is saved with command line arguments. If this bit is set, a COMMAND_LINE_ARGUMENTS StringData structure (section 2.4) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        HasArguments = 0x00000020,

        /// <summary>
        /// The shell link is saved with an icon location string. If this bit is set, an ICON_LOCATION StringData structure (section 2.4) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        HasIconLocation = 0x00000040,

        /// <summary>
        /// The shell link contains Unicode encoded strings. This bit SHOULD be set. If this bit is set, the StringData section contains Unicode-encoded strings; otherwise, it contains strings that are encoded using the system default code page.
        /// </summary>
        IsUnicode = 0x00000080,

        /// <summary>
        /// The LinkInfo structure (section 2.3) is ignored.
        /// </summary>
        ForceNoLinkInfo = 0x00000100,

        /// <summary>
        /// The shell link is saved with an EnvironmentVariableDataBlock (section 2.5.4).
        /// </summary>
        HasExpString = 0x00000200,

        /// <summary>
        /// The target is run in a separate virtual machine when launching a link target that is a 16-bit application.
        /// </summary>
        RunInSeparateProcess = 0x00000400,

        /// <summary>
        /// A bit that is undefined and MUST be ignored.
        /// </summary>
        Unused1 = 0x00000800,

        /// <summary>
        /// The shell link is saved with a DarwinDataBlock (section 2.5.3).
        /// </summary>
        HasDarwinID = 0x00001000,

        /// <summary>
        /// The application is run as a different user when the target of the shell link is activated.
        /// </summary>
        RunAsUser = 0x00002000,

        /// <summary>
        /// The shell link is saved with an IconEnvironmentDataBlock (section 2.5.5).
        /// </summary>
        HasExpIcon = 0x00004000,

        /// <summary>
        /// The file system location is represented in the shell namespace when the path to an item is parsed into an IDList.
        /// </summary>
        NoPidlAlias = 0x00008000,

        /// <summary>
        /// A bit that is undefined and MUST be ignored.
        /// </summary>
        Unused2 = 0x00010000,

        /// <summary>
        /// The shell link is saved with a ShimDataBlock (section 2.5.8).
        /// </summary>
        RunWithShimLayer = 0x00020000,

        /// <summary>
        /// The TrackerDataBlock (section 2.5.10) is ignored.
        /// </summary>
        ForceNoLinkTrack = 0x00040000,

        /// <summary>
        ///
        /// </summary>
        EnableTargetMetadata = 0x00080000,

        /// <summary>
        /// The EnvironmentVariableDataBlock is ignored.
        /// </summary>
        DisableLinkPathTracking = 0x00100000,

        /// <summary>
        /// The SpecialFolderDataBlock (section 2.5.9) and the KnownFolderDataBlock (section 2.5.6) are ignored when loading the shell link. If this bit is set, these extra data blocks SHOULD NOT be saved when saving the shell link.
        /// </summary>
        DisableKnownFolderTracking = 0x00200000,

        /// <summary>
        /// If the link has a KnownFolderDataBlock (section 2.5.6), the unaliased form of the known folder IDList SHOULD be used when translating the target IDList at the time that the link is loaded.
        /// </summary>
        DisableKnownFolderAlias = 0x00400000,

        /// <summary>
        /// Creating a link that references another link is enabled. Otherwise, specifying a link as the target IDList SHOULD NOT be allowed.
        /// </summary>
        AllowLinkToLink = 0x00800000,

        /// <summary>
        /// When saving a link for which the target IDList is under a known folder, either the unaliased form of that known folder or the target IDList SHOULD be used.
        /// </summary>
        UnaliasOnSave = 0x01000000,

        /// <summary>
        /// The target IDList SHOULD NOT be stored; instead, the path specified in the EnvironmentVariableDataBlock (section 2.5.4) SHOULD be used to refer to the target.
        /// </summary>
        PreferEnvironmentPath = 0x02000000,

        /// <summary>
        /// When the target is a UNC name that refers to a location on a local machine, the local path IDList in the PropertyStoreDataBlock (section 2.5.7) SHOULD be stored, so it can be used when the link is loaded on the local machine.
        /// </summary>
        KeepLocalIDListForUNCTarget = 0x04000000,
    }

    /// <summary>
    /// Specifies a virtual key code that corresponds to a key on the keyboard.
    /// </summary>
    public enum HotKeys : byte
    {
        Number0 = 0x30, Number1 = 0x31, Number2 = 0x32, Number3 = 0x33, Number4 = 0x34,
        Number5 = 0x35, Number6 = 0x36, Number7 = 0x37, Number8 = 0x38, Number9 = 0x39,
        A = 0x41, B = 0x42, C = 0x43, D = 0x44, E = 0x45, F = 0x46,
        G = 0x47, H = 0x48, I = 0x49, J = 0x4A, K = 0x4B, L = 0x4C, M = 0x4D,
        N = 0x4E, O = 0x4F, P = 0x50, Q = 0x51, R = 0x52, S = 0x53,
        T = 0x54, U = 0x55, V = 0x56, W = 0x57, X = 0x58, Y = 0x59, Z = 0x5A,
        F1 = 0x70, F2 = 0x71, F3 = 0x72, F4 = 0x73, F5 = 0x74, F6 = 0x75,
        F7 = 0x76, F8 = 0x77, F9 = 0x78, F10 = 0x79, F11 = 0x7A, F12 = 0x7B,
        F13 = 0x7C, F14 = 0x7D, F15 = 0x7E, F16 = 0x7F, F17 = 0x80, F18 = 0x81,
        F19 = 0x82, F20 = 0x83, F21 = 0x84, F22 = 0x85, F23 = 0x86, F24 = 0x87,
        NumLock = 0x90, ScrollLock = 0x91,
    }

    /// <summary>
    /// Modifier keys on the keyboard.
    /// </summary>
    [Flags]
    public enum HotKeyModifiers : byte
    {
        None = 0x0,
        Shift = 0x1,
        Ctrl = 0x2,
        Alt = 0x4,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HotKey
    {
        public HotKeys Key;
        public HotKeyModifiers Modifiers;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct LinkTargetIDList
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IDList
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ItemID
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LinkInfo
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VolumeID
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CommonNetworkRelativeLink
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StringData
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ExtraData
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ConsoleDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ConsoleFEDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DarwinDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EnvironmentVariableDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IconEnvironmentDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KnownFolderDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PropertyStoreDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ShimDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpecialFolderDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TrackerDataBlock
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VistaAndAboveIDListDataBlock
    {
    }

}