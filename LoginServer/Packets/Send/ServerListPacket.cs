using RSLIB.Network;
using RSLIB.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.Packets.Send
{
    public class ServerListPacket : INetworkPacketAdapter
    {
        private string packetString = "30 00 02 11 00 00 01 00 E5 88 43 6F 6D 6D 75 6E 69 74 79 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
        private string serverName = Config.SERVER_NAME;
        private byte[] packet = new byte[0];
        private RSLIB.Network.Client? client;
        private RSLIB.Network.Server? server;

        private void Run()
        {
            packetString = RSLIB.Helper.ReplaceBytes(packetString, serverName, 10, 18);
            packet = RSLIB.Helper.HexStringToByte(packetString);
            this.client.socket.Send(packet);
        }

        public void SetParams(RSLIB.Network.Client client, Server server, byte[] buffer)
        {
            this.client = client;
            this.server = server;
            this.packet = buffer;
            this.Run(); 
        }
    }
}
