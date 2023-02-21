using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    internal class CharacterCreatedPacketResponse
    {
        private List<Byte> packet;
        private Client client;

        private const int IP_MAX_LEN = 15;
        private const int NAME_MAX_LEN = 16;

        private string name;
        private byte index;
        private byte job;
        private byte location_x;
        private byte location_y;
        private ushort map;
        private string ip;

        public CharacterCreatedPacketResponse(byte index, string name, byte job, byte location_x, byte location_y, ushort map, string ip, Client client)
        {
            this.index = index;
            this.name = name;
            this.job = job;
            this.location_x = location_x;
            this.location_y = location_y;
            this.map = map;
            this.ip = ip;
            this.packet = new List<byte>();
            this.client = client;
            this.PreparePacket();
        }

        public void Send()
        {
            this.client.socket.Send(this.packet.ToArray());
        }

        private void PreparePacket()
        {
            this.packet.AddRange(new byte[] { 0x3C, 0x00, 0x04, 0x11, 0x00, 0x00, 0x00, 0x00 });
            this.packet.Add(this.index);
            this.packet.AddRange(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 });
            this.packet.AddRange(Helper.StringToByte(this.name, NAME_MAX_LEN));
            this.packet.AddRange(new byte[] { 0x00, 0x00, this.job, 0x00 });
            this.packet.Add(0x01);
            this.packet.Add(0x00);
            this.packet.AddRange(new byte[] { 0x98, 0x00 });
            this.packet.AddRange(new byte[] { 0xA5, 0x00, 0xFF, 0xFF });
            this.packet.AddRange(BitConverter.GetBytes(this.map));
            this.packet.AddRange(RSLIB.Helper.StringToByte(this.ip, IP_MAX_LEN));
            this.packet.Add(0x00);
        }
    }
}
