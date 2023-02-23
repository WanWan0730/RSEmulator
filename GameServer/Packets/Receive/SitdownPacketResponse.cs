using GameServer.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class SitdownPacketResponse : IPacketHandler
    {
        private byte[] packet;
        private Client client;

        public void Run()
        {
            this.client.socket.Send(Convert.FromHexString("3A 00 28 11 CD CD CD CD 02 00 00 00 0E 00 57 11 00 00 00 00 03 00 00 00 01 00 20 00 B0 11 00 00 73 00 00 00 20 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 C0".Replace(" ", "")));

            this.client.socket.Send(Convert.FromHexString("18 00 28 11 CD CD CD CD 01 00 00 00 0C 00 47 11 00 00 A3 03 00 00 73 00".Replace(" ", "")));

            
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.packet = packet;
            this.client = client;
        }
    }
}
