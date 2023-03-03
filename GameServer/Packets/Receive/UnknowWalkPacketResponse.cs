using RSLIB;
using RSLIB.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Packets.Receive
{
    internal class UnknowWalkPacketResponse : INetworkPacketAdapter
    {
        private byte[] packer;
        private Client client;
        private Server server;

        private void Run()
        {
            this.client.socket.Send(Convert.FromHexString("24 00 28 11 CD CD CD CD 02 00 00 00 0C 00 24 11 00 00 2B 20 F2 04 9F 09 0C 00 24 11 00 00 2B 20 FE 04 9F 09".Replace(" ", "")));
        }

        public void SetParams(Client client, Server server, byte[] buffer)
        {
            this.client = client;
            this.server = server;
            this.packer = buffer;
            this.Run();
        }
    }
}
