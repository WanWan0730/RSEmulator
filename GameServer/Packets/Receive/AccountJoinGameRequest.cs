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
            Log.Debug(mapFileName);
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
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this._packet = packet;
            this.client = client;
        }
    }
}
