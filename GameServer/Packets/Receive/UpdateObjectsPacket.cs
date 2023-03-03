using RSLIB;
using RSLIB.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Packets.Receive
{
    internal class UpdateObjectsPacket : INetworkPacketAdapter
    {
        private byte[] packer;
        private Client client;
        private Server server;

        private void Run()
        {
            Log.Warning("4136 implementado");
            this.client.socket.Send(Convert.FromHexString("0C 00 24 11 00 00 67 00 FF 0A 56 0B".Replace(" ", "")));
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
