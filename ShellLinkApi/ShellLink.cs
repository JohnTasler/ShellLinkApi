using ShellLinkApi.Extensions;
using ShellLinkApi.Framework;
using ShellLinkApi.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static ShellLinkApi.Structures.Constants;

namespace ShellLinkApi
{
    public class ShellLink
    {
        public ShellLinkHeader ShellLinkHeader { get; set; }
        public LinkTargetIDList LinkTargetIDList { get; set; }
        public LinkInfo LinkInfo { get; set; }
        public string NameString { get; set; }
        public string RelativePath { get; set; }
        public string WorkingDir { get; set; }
        public string CommandLineArguments { get; set; }
        public string IconLocation { get; set; }

        public ShellLink(string fileName)
        {
            using (var stream = OpenFileStreamForReading(fileName))
            {
                this.ReadFromStream(stream);
            }
        }

        public ShellLink(Stream stream)
        {
            this.ReadFromStream(stream);
        }

        private void ReadFromStream(Stream stream)
        {
            ValidateArgument.IsNotNull(stream, nameof(stream));

            this.ShellLinkHeader = stream.ReadStructure<ShellLinkHeader>();

            var linkFlags = this.ShellLinkHeader.LinkFlags;

            if (linkFlags.HasFlag(LinkFlags.HasLinkTargetIDList))
            {
                this.LinkTargetIDList = stream.ReadStructure<LinkTargetIDList>();
                stream.Position += this.LinkTargetIDList.IDListSize;
            }

            if (linkFlags.HasFlag(LinkFlags.HasLinkInfo))
            {
                this.LinkInfo = stream.ReadStructure<LinkInfo>();
                stream.Position += this.LinkInfo.LinkInfoSize;
            }

            if (linkFlags.HasFlag(LinkFlags.HasName))
            {
                this.NameString = stream.ReadString();
            }

            if (linkFlags.HasFlag(LinkFlags.HasRelativePath))
            {
                this.RelativePath = stream.ReadString();
            }

            if (linkFlags.HasFlag(LinkFlags.HasWorkingDir))
            {
                this.WorkingDir = stream.ReadString();
            }

            if (linkFlags.HasFlag(LinkFlags.HasArguments))
            {
                this.CommandLineArguments = stream.ReadString();
            }

            if (linkFlags.HasFlag(LinkFlags.HasIconLocation))
            {
                this.IconLocation = stream.ReadString();
            }
        }

        private static FileStream OpenFileStreamForReading(string fileName)
        {
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 0x1000, FileOptions.SequentialScan);
        }
    }
}
