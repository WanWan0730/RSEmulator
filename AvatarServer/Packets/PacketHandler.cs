using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldServer
{
    public class PacketHandler
    {
        private IPacketHandler[] handlers = new IPacketHandler[20000];

        public PacketHandler()
        {
            this.InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            //this.handlers[4103] = new ServerListPacket();
        }

        public void Execute(byte[] packet, Client client)
        {
            uint packetID = Helper.GetCipherID(Helper.BytesToString(packet));
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
