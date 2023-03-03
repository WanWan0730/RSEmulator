using LoginServer.Packets;
using RSLIB;
using RSLIB.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class SendCharacterToWorld : INetworkPacketAdapter
    {
        private byte[] packet;
        private RSLIB.Network.Client client;
        private Server server;

        private void Run()
        {
            NetworkPacket packetWorker = new NetworkPacket(packet);
            byte[] decrytped = packetWorker.Decrypt();
            
            byte[] response = new byte[] { 0x0C, 0x00, 0x09, 0x11, 0x00, 0x00, 0x00, 0x00, 0xE8, 0xD7, 0x00, 0x00 };
            this.client.socket.Send(response);
        }

        public void SetParams(RSLIB.Network.Client client, Server server, byte[] buffer)
        {
            this.client = client;
            this.packet = buffer;
            this.server = server;
            this.Run();
        }
    }
}
