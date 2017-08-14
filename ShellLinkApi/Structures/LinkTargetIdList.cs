using ShellLinkApi.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace ShellLinkApi.Structures
{
    public interface IFileChunk
    {
        uint Size { get; }
    }

    public abstract class FileChunk : IFileChunk
    {
        protected FileChunk(BinaryReader reader)
        {
            ValidateArgument.IsNotNull(reader, nameof(reader));
        }

        public uint Size { get; protected set; }
    }

    public class LinkTargetIDList : FileChunk
    {
        public LinkTargetIDList(BinaryReader reader) : base(reader)
        {
            var size = reader.ReadUInt16();
            this.Size = size;
            this.IDList = new IDList(reader, size);
        }

        public IDList IDList { get; }
    }

    public class IDList : FileChunk
    {
        public IDList(BinaryReader reader, ushort maximumSize) : base(reader)
        {
            var list = new List<ItemID>();

            var idListSize = maximumSize - sizeof(ushort);

            ushort byteCount = 0;
            while (byteCount < idListSize)
            {
                var itemID = new ItemID(reader);
                list.Add(itemID);
                byteCount += (ushort)itemID.Size;
            }

            var terminalId = reader.ReadUInt16();
            if (terminalId != 0)
            {
                throw new FormatException();
            }

            this.ItemIDList = list.ToArray();
        }

        public ItemID[] ItemIDList { get; }
    }

    public class ItemID : FileChunk
    {
        public ItemID(BinaryReader reader) : base(reader)
        {
            var size = reader.ReadUInt16();
            this.Size = size;
            this.Data = size != 0 ? reader.ReadBytes(size - sizeof(ushort)) : null;
        }

        public byte[] Data { get; }
    }
}
