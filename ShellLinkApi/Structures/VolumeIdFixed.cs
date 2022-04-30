using System.Runtime.InteropServices;

namespace ShellLinkApi.Structures
{
    /// <summary>
    /// The VolumeID structure specifies information about the volume that a link target was on when
    /// the link was created. This information is useful for resolving the link if the file is not
    /// found in its original location.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VolumeIdFixed
    {
        public uint VolumeIDSize;
        public DriveType DriveType;
        public uint DriveSerialNumber;
        public uint VolumeLabelOffset;
    }
}
