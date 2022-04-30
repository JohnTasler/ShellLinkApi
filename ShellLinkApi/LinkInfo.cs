using ShellLinkApi.Extensions;
using ShellLinkApi.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShellLinkApi
{
    public class LinkInfo : FileChunk
    {
        public LinkInfo(BinaryReader reader) : base(reader)
        {
            var basePosition = reader.BaseStream.Position;
            this.Structure = reader.BaseStream.ReadStructure<LinkInfoFixed>();
            this.Size = this.Structure.LinkInfoSize;

            reader.BaseStream.Position = basePosition + this.Size;
        }

        private LinkInfoFixed Structure { get; }

        public string VolumeID { get; }
        public string LocalBasePath { get; }
        public string CommonNetworkRelativeLink { get; }
        public string CommonPathSuffix { get; }
        public string LocalBasePathUnicode { get; }
        public string CommonPathSuffixUnicode { get; }

    }
}
