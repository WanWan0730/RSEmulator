using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Packets.Receive
{
    internal class MovementPacket : IPacketHandler
    {
        private byte[] packet;
        private Client client;

        public void Run()
        {
            //walk
            //this.client.socket.Send(Convert.FromHexString("18 00 28 11 CD CD CD CD 01 00 00 00 0C 00 29 11 00 00 C8 00 10 27 00 00".Replace(" ", "")));
            this.client.socket.Send(Convert.FromHexString("18 00 28 11 CD CD CD CD 01 00 00 00 0C 00 29 11 00 00 91 01 91 00 00 00".Replace(" ", "")));
                    

                    

            
               

        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.client = client;
            this.packet = packet;
        }
    }
}
