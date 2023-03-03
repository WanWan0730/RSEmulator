using GameServer.Packets;
using RSLIB;
using RSLIB.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class RequestJoinGameResponse : INetworkPacketAdapter
    {
        private byte[] packet;
        private Client client;
        private Server server;
        
        private void Run()
        {
            this.client.socket.Send(Convert.FromHexString("1A 00 28 11 CD CD CD CD 02 00 00 00 06 00 3E 12 00 00 08 00 0C 12 00 00 00 80".Replace(" ", "")));
            //this.client.socket.Send(new byte[] { 0x06, 0x00, 0x3E, 0x12, 0x00, 0x00 });
        }
             
        public void SetParams(Client client, Server server, byte[] buffer)
        {
            this.client = client;
            this.server = server;
            this.packet = buffer;
            this.Run();
        }
    }
}


