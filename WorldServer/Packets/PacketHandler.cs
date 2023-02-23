using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldServer.Packets;
using WorldServer.Packets.Receive;

namespace WorldServer
{
    internal class PacketHandler
    {
        private IPacketHandler[] handlers = new IPacketHandler[50000];

        public PacketHandler()
        {
            this.InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.handlers[28673] = new UnknowPacketReceive01();
        }

        public void Execute(byte[] packet, Client client)
        {
            uint packetID = Helper.GetCipherID(Helper.BytesToString(packet));
            Log.Packet(packet);
            Log.Debug($"ID: {packetID}");
            if (this.handlers[packetID] != null)
            {
                this.handlers[packetID].SetPacketAndClient(packet, client);
                this.handlers[packetID].Run();
            }
            else
            {
                Log.Debug($"ID [{packetID}] - Package not implemented \n {RSLIB.Helper.BytesToString(packet)}");
            }
        }
    }
}
