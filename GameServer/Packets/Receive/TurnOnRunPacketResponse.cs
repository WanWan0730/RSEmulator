using RSLIB.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Packets.Receive
{
    public class TurnOnRunPacketResponse : INetworkPacketAdapter
    {
        private byte[] packet;
        private Client client;
        private Server server;

        private void Run()
        {
            this.client.socket.Send(Convert.FromHexString("14 00 28 11 CD CD CD CD 01 00 00 00 08 00 2D 11 00 00 91 01".Replace(" ", "")));
        }

        public void SetParams(Client client, Server server, byte[] buffer)
        {
            this.packet = buffer;
            this.client = client;
            this.server = server;
            this.Run();
        }
    }
}
