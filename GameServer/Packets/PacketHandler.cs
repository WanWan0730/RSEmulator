using GameServer.Packets;
using GameServer.Packets.Receive;
using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    internal class PacketHandler
    {
        private IPacketHandler[] handlers = new IPacketHandler[20000];

        public PacketHandler()
        {
            this.InitializeHandlers();
        }

        private void InitializeHandlers()
        {

            this.handlers[4129] = new AccountJoinGameRequest();

            this.handlers[4287] = new RequestJoinGameResponse();


            this.handlers[4130] = new MapInfoRequestPacket();
            this.handlers[4257] = new NPCInfoRequestPacket();
            
            this.handlers[4131] = new MovementPacket();

            //Sem esses não carrega o mapa


            //this.handlers[4132] = new UnknowWalkPacketResponse();
            //this.handlers[4135] = new TurnOnRunPacketResponse();
            //this.handlers[4136] = new UpdateObjectsPacket();

            //this.handlers[4258] = new UnknowWalkPacketResponse2();
            //this.handlers[4153] = new UnknowWalkPacketResponse();
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
                Log.Debug($"[-->] ID [{packetID}] SIZE [{packet.Length}] - Package not implemented \n {RSLIB.Helper.BytesToString(packet)}");
            }
        }
    }
}
