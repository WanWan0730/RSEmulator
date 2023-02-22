using LoginServer.Packets;
using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class SendCharacterToWorld : IPacketHandler
    {
        private byte[] packet;
        private Client client;
        public Client[]? clients;

        public void Run()
        {
            NetworkPacket packetWorker = new NetworkPacket(packet);
            byte[] decrytped = packetWorker.Decrypt();
            Log.Info($"Sending player to world: {Encoding.UTF8.GetString(decrytped)}");
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.client = client;
            this.packet= packet;
        }


    }
}
