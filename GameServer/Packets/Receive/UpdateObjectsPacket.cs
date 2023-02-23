using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Packets.Receive
{
    internal class UpdateObjectsPacket : IPacketHandler
    {
        private byte[] packer;
        private Client client;

        public void Run()
        {
            Log.Warning("4136 implementado");
            this.client.socket.Send(Convert.FromHexString("0C 00 24 11 00 00 67 00 FF 0A 56 0B".Replace(" ", "")));
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.client = client;
            this.packer = packet;
        }
    }
}
