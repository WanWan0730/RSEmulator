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
    public class CharacterListPacket
    {
        private byte[] packet;
        private RSLIB.Network.Client client;
        private const int CHARACTER_PER_ACCOUNT = 6;
        public void Run()
        {
            List<byte> result = new List<byte>();
            CharacterModel characterModel = new CharacterModel();
            string username = (string)this.client.info["username"];
            List<Dictionary<string, object>> characters = characterModel.SelectCharacter(username);
            byte index = 0;
            foreach (Dictionary<string, object> character in characters)
            {
                string name = character["name"].ToString();
                byte job = (byte)Convert.ToInt32(character["job"]);
                short level = (short)Convert.ToInt32(character["level"]);
                short location = (short)Convert.ToInt32(character["place_code"]);
                short position_x = (short)Convert.ToInt32(character["position_x"]);
                short position_y = (short)Convert.ToInt32(character["position_y"]);

                result.AddRange(new Character(name, job, index, location, position_x, position_y, level, "127.0.0.1").GetBytes());
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

        public void SetPacketAndClient(byte[] packet, RSLIB.Network.Client client)
        {
            this.packet = packet;
            this.client = client;
        }
    }
}