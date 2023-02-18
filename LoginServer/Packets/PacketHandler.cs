using LoginServer.Packets;
using LoginServer.Packets.Send;
using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class PacketHandler
    {
        private IPacketHandler[] handlers = new IPacketHandler[10000];

        public PacketHandler()
        {
            this.InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.handlers[4103] = new ServerListPacket();
            this.handlers[4096] = this.handlers[4103];

            this.handlers[4097] = new LoginPacket();
        }

        public void Execute(byte[] packet, Client client)
        {
            NetworkPacket packetlib = new NetworkPacket(packet);

            if (this.handlers[packetlib.cipherId] != null)
            {
                this.handlers[packetlib.cipherId].SetPacketAndClient(packet, client);
                this.handlers[packetlib.cipherId].Run();
            }
            else
            {
                Log.Debug($"ID [{packetlib.cipherId}] - Package not implemented");
            }
        }
    }
}
