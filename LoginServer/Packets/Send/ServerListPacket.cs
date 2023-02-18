using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.Packets.Send
{
    public class ServerListPacket : IPacketHandler
    {
        private string packetString = "30 00 02 11 00 00 01 00 E5 88 43 6F 6D 6D 75 6E 69 74 79 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
        private string serverName = string.Empty;
        private byte[] packet;
        private Client client;

        public void Run()
        {
            serverName = "HB20S";
            packetString = RSLIB.Helper.ReplaceBytes(packetString, serverName, 10, 18);
            packet = RSLIB.Helper.HexStringToByte(packetString);
            this.client.socket.Send(packet);
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.packet = packet;
            this.client = client;
        }
    }
}
