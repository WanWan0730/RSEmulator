using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.Packets.Send
{
    public class TestPacket : IPacketHandler
    {
        private byte[] packet;
        private Client client;
        public Client[]? clients;

        public void Run()
        {
            packet = Helper.JumpBytesFromBebin(packet, 0x4);

            Log.Packet($"Chegou no run: client length: {clients?.Length}");

            for (int clientIndex = 0; clientIndex < clients?.Length; clientIndex++)
            {
                if (clients[clientIndex] != null)
                {
                    Log.Debug(BitConverter.ToString(packet));
                    clients[clientIndex].socket.Send(packet);
                }
            }
            
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.client = client;
            this.packet= packet;
        }

        public void SetClients(byte[] data, Client[] clients)
        {
            this.packet = data;
            this.clients = clients;
        }
    }
}
