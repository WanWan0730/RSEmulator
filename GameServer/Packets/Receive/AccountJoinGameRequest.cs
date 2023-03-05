using GameServer.Packets;
using RSLIB;
using RSLIB.Database;
using RSLIB.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class AccountJoinGameRequest : INetworkPacketAdapter
    {

        private byte[] packet;
        private Client client;
        private Server server;

        private void Run()
        {
            string name = RSLIB.Helper.GetStringFromRange(packet, 8, 10);
            string avatar_name = RSLIB.Helper.GetStringFromRange(packet, 32, 16);
            string mac_address = RSLIB.Helper.GetStringFromRange(packet, 50, 17);

            this.client.info.Add("account_name", name);
            this.client.info.Add("avatar_name", avatar_name);
            this.client.info.Add("mac_address", mac_address);

            using var db = new RedStoneContext();
            var avatar = db?.Avatars?.Where(context => context.Name == avatar_name).FirstOrDefault();

            if (avatar != null)
            {
                string mapFileName = RSLIB.Structs.Map.GetMapFileNameBytesByNumber(avatar.LastField);

                this.client.info.Add("job", avatar.Job);
                this.client.info.Add("pos_x", avatar.PositionX);
                this.client.info.Add("pos_y", avatar.PositionY);

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


                byte[] position_x = BitConverter.GetBytes((ushort)(((int)this.client.info["pos_x"] * 64) + 48));
                byte[] position_y = BitConverter.GetBytes((ushort)(((int)this.client.info["pos_y"] * 32) + 16));
                List<byte> toOthersData = new List<byte>();
                toOthersData.AddRange(Convert.FromHexString("93 00 28 11 CD CD CD CD 03 00 00 00 47 00 22 11 00 00 CC CC FC 6B 00 40 F0 FF 83 05 00 80 00 00 51 01 00 C0 A1 8F 31 C8".Replace(" ", "")));
                toOthersData.AddRange(position_x);
                toOthersData.AddRange(position_y);
                toOthersData.AddRange(Convert.FromHexString("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 74 65 73 74 31 31 00 00 00 CC CC CC CC CC CC CC CC 20 00 B0 11 00 00 2C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 FF FF 00 C0 20 00 B0 11 00 00 2C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 C0".Replace(" ", "")));

                foreach (KeyValuePair<string, Client> client in this.client.server.clients)
                {
                    if (client.Value.id != this.client.id)
                    {
                        client.Value.socket.Send(toOthersData.ToArray());
                    }
                }
            } else
            {
                Log.Error("Avatar not found");
            }
        }


        public void SetParams(Client client, Server server, byte[] buffer)
        {
            this.client = client;
            this.server = server;
            this.packet = buffer;
            this.Run();
        }
    }
}
