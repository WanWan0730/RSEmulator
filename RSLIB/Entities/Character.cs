using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using static Mysqlx.Notice.Warning.Types;
using System.Xml.Linq;

namespace RSLIB
{

    public class Character
    {
        [StringLength(12, MinimumLength = 4)]
        private string name { get; set; }
        private byte job { get; set; }
        [IntegerValidator(MaxValue = 5, MinValue = 0)]
        private byte index { get; set; }
        private short location { get; set; }
        private int position_x { get; set; }
        private int position_y { get; set; }
        private short level { get; set; }
        private string ip { get; set; }
        private const int MAX_NAME_LEN = 18;
        private const int MAX_IP_LEN = 16;
        private byte[] header = new byte[] { };
        private byte[] headerBytes = new byte[] { 0x28, 0x01, 0x03, 0x11, 0x00, 0x00, 0x85, 0x67 };
        private static byte[] emptyListHeaderBytes = new byte[] { 0x28, 0x01, 0x03, 0x11, 0x00, 0x00, 0xEC, 0x01 };
        private List<byte> packetByteList = new List<byte>();

        public Character(string name, byte job, byte index, short location, int x, int y, short level, string ip)
        {
            this.name= name;
            this.ip= ip;
            this.job= job;  
            this.index= index;
            this.location= location;
            this.level= level;
            this.position_x = x;
            this.position_y = y;

            if (index == 0)
            {
                this.header = this.headerBytes;
            }
            this.packetByteList.AddRange(this.header);
        }

        public byte[] GetBytes()
        {
            this.packetByteList.Add(this.index);
            this.packetByteList.Add(0x00);
            this.packetByteList.AddRange(Helper.FillLength(this.name, MAX_NAME_LEN));
            this.packetByteList.AddRange(BitConverter.GetBytes(this.job));
            this.packetByteList.AddRange(BitConverter.GetBytes(this.level));
            this.packetByteList.AddRange(BitConverter.GetBytes((short)this.position_x));
            this.packetByteList.AddRange(BitConverter.GetBytes((short)this.position_y));
            this.packetByteList.AddRange(new byte[] { 0xFF, 0xFF });
            this.packetByteList.AddRange(BitConverter.GetBytes((short)this.location));
            this.packetByteList.AddRange(Helper.FillLength(this.ip, MAX_IP_LEN));
            return packetByteList.ToArray();
        }

        public static byte[] GetEmpty(Boolean setHeader = false)
        {
            List<byte> emptyCharacter = new List<byte>();
            if (setHeader == true)
            {
                emptyCharacter.AddRange(emptyListHeaderBytes);
            }
            emptyCharacter.AddRange(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            return emptyCharacter.ToArray();
        }
    }
    
}
