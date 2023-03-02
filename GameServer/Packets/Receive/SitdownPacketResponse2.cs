using GameServer.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class SitdownPacketResponse2 : IPacketHandler
    {
        private byte[] packet;
        private Client client;

        public void Run()
        {

            this.client.socket.Send(Convert.FromHexString("2C 00 28 11 CD CD CD CD 01 00 00 00 20 00 B0 11 00 00 2B 00 00 00 20 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 C0".Replace(" ", "")));

            
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.packet = packet;
            this.client = client;
        }
    }
}
