using GameServer.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class JoinGameRequestPacket : IPacketHandler
    {

        private byte[] _packet;
        private Client Client_client;

        public void Run()
        {

            byte[] response_1 = Convert.FromHexString("6F 00 20 11 00 00 00 00 97 58 38 D2 00 00 00 00 00 00 CC CC 02 00 00 00 5B 30 32 38 5D 50 72 69 73 6F 6E 2E 72 6D 64 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00".Replace(" ", ""));
            this.Client_client.socket.Send(response_1);

        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this._packet = packet;
            Client_client = client;
        }
    }
}
