using GameServer.Packets;
using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class RequestJoinGameResponse : IPacketHandler
    {
        private byte[] packet;
        private Client client;

        
        public void Run()
        {
            this.client.socket.Send(new byte[] { 0x06, 0x00, 0x3E, 0x12, 0x00, 0x00 });
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.client = client;
            this.packet = packet;
        }
    }
}


