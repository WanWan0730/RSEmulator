using LoginServer.Packets;
using RSLIB;
using RSLIB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class CreateCharacterPacket : IPacketHandler
    {

        private byte[] packet;
        private Client client;

        public void Run()
        {
            NetworkPacket packetWorker = new NetworkPacket(packet);
            byte[] decrypted = packetWorker.Decrypt();

            byte[] job = Helper.GetBytesFromBegin(decrypted, 1);
            decrypted = Helper.JumpBytesFromBebin(decrypted, 8);
            string name = Encoding.UTF8.GetString(Helper.GetBytesUntilNull(Helper.GetBytesFromBegin(decrypted, 16)));

            CharacterModel character = new CharacterModel(name, job[0], 1, 0, 433, 35, 35, this.client.username);

            if (character.NameInUse())
            {
                byte[] alreadyExistsResponse = Convert.FromHexString("3C000411000002000000A72E0000454D50545900000000000000000000000000FFFF000000000000000000003139322E3136382E302E320000000000");
                this.client.socket.Send(alreadyExistsResponse);
            } else
            {
                int index = new CharacterModel().SelectCharacter(this.client.username).Count;

                Log.Debug($"Count: {(byte)index}");

                character.SavePlayer();
                CharacterCreatedPacketResponse createdResponse = new CharacterCreatedPacketResponse((byte)index, name, job[0], 35, 35, 433, "192.168.0.2", this.client);
                createdResponse.Send();
                Log.Info($"Personagem de nome {name} criado com sucesso");
            }
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.packet= packet;
            this.client= client;
        }
    }
}
