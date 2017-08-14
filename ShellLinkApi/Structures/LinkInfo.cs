using ShellLinkApi.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShellLinkApi.Structures
{
    public class LinkInfo : FileChunk
    {
        public LinkInfo(BinaryReader reader) : base(reader)
        {
            var position = reader.BaseStream.Position;
            this.Header = reader.BaseStream.ReadStructure<LinkInfoFixed>();
            this.Size = this.Header.LinkInfoSize;

            reader.BaseStream.Position = position + this.Size;
        }

        public LinkInfoFixed Header { get; }

        public string VolumeID { get; }
        public string LocalBasePath { get; }
        public string CommonNetworkRelativeLink { get; }
        public string CommonPathSuffix { get; }
        public string LocalBasePathUnicode { get; }
        public string CommonPathSuffixUnicode { get; }

    }

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
