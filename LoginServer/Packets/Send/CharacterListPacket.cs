using LoginServer.Packets;
using MySqlX.XDevAPI.Common;
using RSLIB;
using RSLIB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class CharacterListPacket : IPacketHandler
    {
        private byte[] packet;
        private Client client;
        private const int CHARACTER_PER_ACCOUNT = 6;
        public void Run()
        {
            List<byte> result = new List<byte>();
            CharacterModel characterModel = new CharacterModel();
            List<Dictionary<string, object>> characters = characterModel.SelectCharacter(this.client.username);
            byte index = 0;
            foreach (Dictionary<string, object> character in characters)
            {
                string name = character["name"].ToString();
                byte job = (byte)Convert.ToInt32(character["job"]);
                short level = (short)Convert.ToInt32(character["level"]);
                short location = (short)Convert.ToInt32(character["place_code"]);

                result.AddRange(new Character(name, job, index, location, 409, 165, level, "192.168.0.5").GetBytes());
                index++;
            }
            if (characters.Count == 0)
            {
                result.AddRange(Character.GetEmpty(true));
            }
            int amountOfEmptyToAdd = characters.Count == 0 ? CHARACTER_PER_ACCOUNT - 1 : CHARACTER_PER_ACCOUNT - characters.Count;
            for (int i = 0; i < amountOfEmptyToAdd; i++)
            {
                result.AddRange(Character.GetEmpty());
            }
            this.client.socket.Send(result.ToArray());
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.packet = packet;
            this.client = client;
        }
    }
}