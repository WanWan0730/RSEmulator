using GameServer.Packets;
using RSLIB;
using RSLIB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class AccountJoinGameRequest : IPacketHandler
    {

        private byte[] _packet;
        private Client client;

        public void Run()
        {
            string name = RSLIB.Helper.GetStringFromRange(_packet, 8, 10);
            string avatar_name = RSLIB.Helper.GetStringFromRange(_packet, 32, 16);
            string mac_address = RSLIB.Helper.GetStringFromRange(_packet, 50, 17);

            this.client.avatar.Add("account_name", name);
            this.client.avatar.Add("avatar_name", avatar_name);
            this.client.avatar.Add("mac_address", mac_address);

            CharacterModel avatar = new CharacterModel();
            List<Dictionary<string, object>> characters = avatar.Query($"SELECT * FROM characters WHERE name = '{avatar_name}'");
            Dictionary<string, object> character = characters[0];
            string mapFileName = RSLIB.Structs.Map.GetMapFileNameBytesByNumber((int)character["place_code"]);

            this.client.avatar.Add("job", character["job"]);
            this.client.avatar.Add("pos_x", character["position_x"]);
            this.client.avatar.Add("pos_y", character["position_y"]);

           

            List<byte> response = new List<byte>();

            //Header
            response.AddRange(new byte[] { 0x6F, 0x00, 0x20, 0x11, 0x00, 0x00, 0x00, 0x00 });
            //Unknow bytes
            response.AddRange(new byte[] { 0xFF, 0xFF, 0x6B, 0x1E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xCC, 0xCC, 0x02, 0x00, 0x00, 0x00 });

            byte[] fileName = Encoding.UTF8.GetBytes(mapFileName);
            byte[] fileNameBytes = new byte[87];
            Array.Copy(fileName, 0, fileNameBytes, 0, fileName.Length);
            response.AddRange(fileNameBytes);
            
            this.client.socket.Send(response.ToArray());


            byte[] position_x = BitConverter.GetBytes((ushort)(((int)this.client.avatar["pos_x"] * 64) + 48));
            byte[] position_y = BitConverter.GetBytes((ushort)(((int)this.client.avatar["pos_y"] * 32) + 16));
            List<byte> toOthersData = new List<byte>();
            toOthersData.AddRange(Convert.FromHexString("93 00 28 11 CD CD CD CD 03 00 00 00 47 00 22 11 00 00 CC CC FC 6B 00 40 F0 FF 83 05 00 80 00 00 51 01 00 C0 A1 8F 31 C8".Replace(" ", "")));
            toOthersData.AddRange(position_x);
            toOthersData.AddRange(position_y);
            toOthersData.AddRange(Convert.FromHexString("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 74 65 73 74 31 31 00 00 00 CC CC CC CC CC CC CC CC 20 00 B0 11 00 00 2C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 FF FF 00 C0 20 00 B0 11 00 00 2C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 C0".Replace(" ", "")));

            foreach (Client c in this.client.server.clients)
            {
                if (c != null && c.clientID != this.client.clientID)
                {
                    c.socket.Send(toOthersData.ToArray());
                }
            }
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this._packet = packet;
            this.client = client;
        }
    }
}
