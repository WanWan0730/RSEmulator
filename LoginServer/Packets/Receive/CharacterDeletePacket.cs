using LoginServer.Packets;
using RSLIB;
using RSLIB.Database;
using RSLIB.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class CharacterDeletePacket : INetworkPacketAdapter
    {
        private RSLIB.Network.Client client;
        private RSLIB.Network.Server server;
        byte[] packet;
        
        
        private void Run()
        {
            NetworkPacket packetWorker = new NetworkPacket(packet);
            byte[] decrypted = packetWorker.Decrypt();

            decrypted = Helper.JumpBytesFromBebin(decrypted, 6);
            string decrypted_name = Encoding.UTF8.GetString(Helper.GetBytesUntilNull(Helper.GetBytesFromBegin(decrypted, 16)));

            CharacterModel characterModel = new CharacterModel();
            characterModel.DeletePlayerByName(decrypted_name);
            this.client.socket.Send(Convert.FromHexString("0A00051100000000DF54"));
        }

        public void SetParams(RSLIB.Network.Client client, Server server, byte[] buffer)
        {
            this.packet = buffer;
            this.client = client;
            this.server = server;
            this.Run();
        }
    }
}
