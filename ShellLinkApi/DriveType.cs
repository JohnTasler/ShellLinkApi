
namespace ShellLinkApi
{
    /// <summary>The type of drive the link target is stored on.</summary>
    public enum DriveType : uint
    {
        /// <summary>The drive type cannot be determined.</summary>
        Unknown = 0x00000000,

        /// <summary>The root path is invalid, for example, there is no volume mounted at the path.</summary>
        NoRootDir = 0x00000001,

        /// <summary>The drive has removable media, such as a floppy drive, thumb drive, or flash card reader.</summary>
        Removable = 0x00000002,

        /// <summary>The drive has fixed media, such as a hard drive or flash drive.</summary>
        Fixed = 0x00000003,

        /// <summary>The drive is a remote (network) drive.</summary>
        REMOTE = 0x00000004,

        /// <summary>The drive is a CD-ROM drive.</summary>
        CDROM = 0x00000005,

        /// <summary>The drive is a RAM disk.</summary>
        RAMDisk = 0x00000006,
    }
}
