using LoginServer.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class CharacterListPacket : IPacketHandler
    {
        private string packetString = "28 01 03 11 00 00 BE 00 00 00 41 72 71 75 65 69 72 61 00 00 00 00 00 00 00 00 00 00 02 00 D0 07 F0 00 F5 00 FF FF 00 00 31 39 32 2E 31 36 38 2E 31 36 2E 33 00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
        private byte[] packet;
        private Client client;

        public void Run()
        {
            byte[] charlist = RSLIB.Helper.HexStringToByte(this.packetString);
            this.client.socket.Send(charlist);
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.packet = packet;
            this.client = client;
        }
    }
}
