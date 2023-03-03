using GameServer.Packets.Send;
using RSLIB;
using RSLIB.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Packets.Receive
{
    internal class LocalMessageRequestPacket : INetworkPacketAdapter
    {
        private byte[] packet;
        private Client client;
        private Server server;

        private void Run()
        {
            string msg = Helper.GetStringFromRange(packet, 26, packet.Length - 26);

            if ( msg.StartsWith("@warp") )
            {
                WarpPacketSender warp = new WarpPacketSender(client);
                warp.SendToMap(msg);
            } else
            {
                Log.Info(msg);
            }

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
