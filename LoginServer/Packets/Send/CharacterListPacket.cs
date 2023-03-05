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
            using var db = new RedStoneContext();
            string username = (string)this.client.info["username"];

            List<byte> result = new List<byte>();
            
            var avatars = db.Avatars.Where(context => context.Username == username).ToList();
            byte index = 0;
            foreach (var avatar in avatars)
            {
                string name = avatar.Name;
                byte job = (byte)Convert.ToInt32(avatar.Job);
                short level = (short)Convert.ToInt32(avatar.Level);
                short location = (short)Convert.ToInt32(avatar.LastField);
                short position_x = (short)Convert.ToInt32(avatar.PositionX);
                short position_y = (short)Convert.ToInt32(avatar.PositionY);

                result.AddRange(new Character(name, job, index, location, position_x, position_y, level, "127.0.0.1").GetBytes());
                index++;
            }
            if (avatars.Count == 0)
            {
                result.AddRange(Character.GetEmpty(true));
            }
            int amountOfEmptyToAdd = avatars.Count == 0 ? CHARACTER_PER_ACCOUNT - 1 : CHARACTER_PER_ACCOUNT - avatars.Count;
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