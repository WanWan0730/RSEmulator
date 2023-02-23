using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Packets.Receive
{
    public class TurnOnRunPacketResponse : IPacketHandler
    {
        private byte[] _packet;
        private Client Client_client;

        public void Run()
        {
            this.Client_client.socket.Send(Convert.FromHexString("14 00 28 11 CD CD CD CD 01 00 00 00 08 00 2D 11 00 00 91 01".Replace(" ", "")));
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this._packet = packet;
            Client_client = client;
        }
    }
}
