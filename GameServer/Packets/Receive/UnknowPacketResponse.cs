using GameServer.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class UnknowPacketResponse : IPacketHandler
    {
        private byte[] packet;
        private Client client;

        public UnknowPacketResponse(byte[] packet) {
            this.packet = packet;
        }

        public UnknowPacketResponse(string packet) {
            this.packet = Convert.FromHexString(packet.Replace(" ", ""));
        } 
        public void Run()
        {
            this.client.socket.Send(this.packet);
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.client = client;
            this.packet = packet;
        }
    }
}


