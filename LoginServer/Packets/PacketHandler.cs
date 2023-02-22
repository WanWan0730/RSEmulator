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
        private IPacketHandler[] handlers = new IPacketHandler[20000];

        public PacketHandler()
        {
            this.InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.handlers[4103] = new ServerListPacket();
            this.handlers[4096] = this.handlers[4103];
            this.handlers[4097] = new LoginPacket();
            this.handlers[4100] = new CreateCharacterPacket();
            this.handlers[4101] = new CharacterDeletePacket();
            this.handlers[4102] = new SendCharacterToWorld();
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
