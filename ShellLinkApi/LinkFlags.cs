using System;
using System.Runtime.InteropServices;

namespace ShellLinkApi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LinkFlags
    {
        public LinkFlagValues Value;

        /// <summary>
        /// The shell link is saved with an item ID list (IDList). If this bit is set, a LinkTargetIDList structure (section 2.2) MUST follow the ShellLinkHeader. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public bool HasLinkTargetIDList => Value.HasFlag(LinkFlagValues.HasLinkTargetIDList);

        /// <summary>
        /// The shell link is saved with link information. If this bit is set, a LinkInfo structure (section 2.3) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public bool HasLinkInfo => Value.HasFlag(LinkFlagValues.HasLinkInfo);

        /// <summary>
        /// The shell link is saved with a name string. If this bit is set, a NAME_STRING StringData structure (section 2.4) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public bool HasName => Value.HasFlag(LinkFlagValues.HasName);

        /// <summary>
        /// The shell link is saved with a relative path string. If this bit is set, a RELATIVE_PATH StringData structure (section 2.4) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public bool HasRelativePath => Value.HasFlag(LinkFlagValues.HasRelativePath);

        /// <summary>
        /// The shell link is saved with a working directory string. If this bit is set, a WORKING_DIR StringData structure (section 2.4) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public bool HasWorkingDir => Value.HasFlag(LinkFlagValues.HasWorkingDir);

        /// <summary>
        /// The shell link is saved with command line arguments. If this bit is set, a COMMAND_LINE_ARGUMENTS StringData structure (section 2.4) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public bool HasArguments => Value.HasFlag(LinkFlagValues.HasArguments);

        /// <summary>
        /// The shell link is saved with an icon location string. If this bit is set, an ICON_LOCATION StringData structure (section 2.4) MUST be present. If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public bool HasIconLocation => Value.HasFlag(LinkFlagValues.HasIconLocation);

        /// <summary>
        /// The shell link contains Unicode encoded strings. This bit SHOULD be set. If this bit is set, the StringData section contains Unicode-encoded strings; otherwise, it contains strings that are encoded using the system default code page.
        /// </summary>
        public bool IsUnicode => Value.HasFlag(LinkFlagValues.IsUnicode);

        /// <summary>
        /// The LinkInfo structure (section 2.3) is ignored.
        /// </summary>
        public bool ForceNoLinkInfo => Value.HasFlag(LinkFlagValues.ForceNoLinkInfo);

        /// <summary>
        /// The shell link is saved with an EnvironmentVariableDataBlock (section 2.5.4).
        /// </summary>
        public bool HasExpString => Value.HasFlag(LinkFlagValues.HasExpString);

        /// <summary>
        /// The target is run in a separate virtual machine when launching a link target that is a 16-bit application.
        /// </summary>
        public bool RunInSeparateProcess => Value.HasFlag(LinkFlagValues.RunInSeparateProcess);

        /// <summary>
        /// A bit that is undefined and MUST be ignored.
        /// </summary>
        public bool Unused1 => Value.HasFlag(LinkFlagValues.Unused1);

        /// <summary>
        /// The shell link is saved with a DarwinDataBlock (section 2.5.3).
        /// </summary>
        public bool HasDarwinID => Value.HasFlag(LinkFlagValues.HasDarwinID);

        /// <summary>
        /// The application is run as a different user when the target of the shell link is activated.
        /// </summary>
        public bool RunAsUser => Value.HasFlag(LinkFlagValues.RunAsUser);

        /// <summary>
        /// The shell link is saved with an IconEnvironmentDataBlock (section 2.5.5).
        /// </summary>
        public bool HasExpIcon => Value.HasFlag(LinkFlagValues.HasExpIcon);

        /// <summary>
        /// The file system location is represented in the shell namespace when the path to an item is parsed into an IDList.
        /// </summary>
        public bool NoPidlAlias => Value.HasFlag(LinkFlagValues.NoPidlAlias);

        /// <summary>
        /// The shell link is saved with a ShimDataBlock (section 2.5.8).
        /// </summary>
        public bool RunWithShimLayer => Value.HasFlag(LinkFlagValues.RunWithShimLayer);

        /// <summary>
        /// The TrackerDataBlock (section 2.5.10) is ignored.
        /// </summary>
        public bool ForceNoLinkTrack => Value.HasFlag(LinkFlagValues.ForceNoLinkTrack);

        /// <summary>
        ///
        /// </summary>
        public bool EnableTargetMetadata => Value.HasFlag(LinkFlagValues.EnableTargetMetadata);

        /// <summary>
        /// The EnvironmentVariableDataBlock is ignored.
        /// </summary>
        public bool DisableLinkPathTracking => Value.HasFlag(LinkFlagValues.DisableLinkPathTracking);

        /// <summary>
        /// The SpecialFolderDataBlock (section 2.5.9) and the KnownFolderDataBlock (section 2.5.6) are ignored when loading the shell link. If this bit is set, these extra data blocks SHOULD NOT be saved when saving the shell link.
        /// </summary>
        public bool DisableKnownFolderTracking => Value.HasFlag(LinkFlagValues.DisableKnownFolderTracking);

        /// <summary>
        /// If the link has a KnownFolderDataBlock (section 2.5.6), the unaliased form of the known folder IDList SHOULD be used when translating the target IDList at the time that the link is loaded.
        /// </summary>
        public bool DisableKnownFolderAlias => Value.HasFlag(LinkFlagValues.DisableKnownFolderAlias);

        /// <summary>
        /// Creating a link that references another link is enabled. Otherwise, specifying a link as the target IDList SHOULD NOT be allowed.
        /// </summary>
        public bool AllowLinkToLink => Value.HasFlag(LinkFlagValues.AllowLinkToLink);

        /// <summary>
        /// When saving a link for which the target IDList is under a known folder, either the unaliased form of that known folder or the target IDList SHOULD be used.
        /// </summary>
        public bool UnaliasOnSave => Value.HasFlag(LinkFlagValues.UnaliasOnSave);

        /// <summary>
        /// The target IDList SHOULD NOT be stored; instead, the path specified in the EnvironmentVariableDataBlock (section 2.5.4) SHOULD be used to refer to the target.
        /// </summary>
        public bool PreferEnvironmentPath => Value.HasFlag(LinkFlagValues.PreferEnvironmentPath);

        /// <summary>
        /// When the target is a UNC name that refers to a location on a local machine, the local path IDList in the PropertyStoreDataBlock (section 2.5.7) SHOULD be stored, so it can be used when the link is loaded on the local machine.
        /// </summary>
        public bool KeepLocalIDListForUNCTarget => Value.HasFlag(LinkFlagValues.KeepLocalIDListForUNCTarget);
    }

    [Flags]
    public enum LinkFlagValues : uint
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
}
