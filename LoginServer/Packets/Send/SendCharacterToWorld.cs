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
            byte[] response = new byte[] { 0x0C, 0x00, 0x09, 0x11, 0x00, 0x00, 0x00, 0x00, 0xE8, 0xD7, 0x00, 0x00 };
            this.client.socket.Send(response);
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.client = client;
            this.packet= packet;
        }


    }
}
