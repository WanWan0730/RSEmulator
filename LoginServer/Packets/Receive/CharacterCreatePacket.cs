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
    public class CharacterCreatePacket : INetworkPacketAdapter
    {

        private byte[] packet;
        private RSLIB.Network.Client client;
        private Server server;

        private void Run()
        {
            NetworkPacket packetWorker = new NetworkPacket(packet);
            byte[] decrypted = packetWorker.Decrypt();
            byte[] job = Helper.GetBytesFromBegin(decrypted, 1);
            decrypted = Helper.JumpBytesFromBebin(decrypted, 8);
            string name = Encoding.UTF8.GetString(Helper.GetBytesUntilNull(Helper.GetBytesFromBegin(decrypted, 16)));
            CharacterModel character = new CharacterModel(name, job[0], 1, 0, 433, 35, 35, (string)this.client.info["username"]);

            if (character.NameInUse())
            {
                byte[] alreadyExistsResponse = Convert.FromHexString("3C000411000002000000A72E0000454D50545900000000000000000000000000FFFF000000000000000000003139322E3136382E302E320000000000");
                this.client.socket.Send(alreadyExistsResponse);
            } else
            {
                int index = new CharacterModel().SelectCharacter((string)this.client.info["username"]).Count;
                character.SavePlayer();
                CharacterCreatedPacketResponse createdResponse = new CharacterCreatedPacketResponse((byte)index, name, job[0], 35, 35, 433, "127.0.0.1", this.client);
                createdResponse.Send();
            }
        }

        public void SetParams(RSLIB.Network.Client client, Server server, byte[] buffer)
        {
            this.client = client;
            this.server = server;
            this.packet = buffer;
            this.Run();
        }
    }
}
