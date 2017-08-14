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
            using (var reader = new BinaryReader(stream, Encoding.Unicode, true))
            {
                this.ShellLinkHeader = reader.ReadStructure<ShellLinkHeader>();

                var linkFlags = this.ShellLinkHeader.LinkFlags;

                if (linkFlags.HasLinkTargetIDList)
                {
                    this.LinkTargetIDList = new LinkTargetIDList(reader);
                }

                if (linkFlags.HasLinkInfo)
                {
                    this.LinkInfo = new LinkInfo(reader);
                }

                if (linkFlags.HasName)
                {
                    this.NameString = reader.ReadShellLinkString();
                }

                if (linkFlags.HasRelativePath)
                {
                    this.RelativePath = reader.ReadShellLinkString();
                }

                if (linkFlags.HasWorkingDir)
                {
                    this.WorkingDir = reader.ReadShellLinkString();
                }

                if (linkFlags.HasArguments)
                {
                    this.CommandLineArguments = reader.ReadShellLinkString();
                }

                if (linkFlags.HasIconLocation)
                {
                    this.IconLocation = reader.ReadShellLinkString();
                }
            }
        }

        private static FileStream OpenFileStreamForReading(string fileName)
        {
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 0x1000, FileOptions.SequentialScan);
        }
    }

    internal static class BinaryReaderExtensions
    {
        public static string ReadShellLinkString(this BinaryReader @this)
        {
            ushort countCharacters = @this.ReadUInt16();
            var chars = @this.ReadChars(countCharacters);
            return new string(chars);
        }
    }
}
