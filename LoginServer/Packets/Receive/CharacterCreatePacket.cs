using LoginServer.Packets;
using RSLIB;
using RSLIB.Database;
using RSLIB.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LoginServer
{
    public class CharacterCreatePacket : INetworkPacketAdapter
    {

        private byte[] packet;
        private RSLIB.Network.Client client;
        private Server server;

        private void Run()
        {
            NetworkSecurity packetWorker = new NetworkSecurity(packet);
            byte[] decrypted = packetWorker.Decrypt();
            byte[] job = Helper.GetBytesFromBegin(decrypted, 1);
            decrypted = Helper.JumpBytesFromBebin(decrypted, 8);
            string name = Encoding.UTF8.GetString(Helper.GetBytesUntilNull(Helper.GetBytesFromBegin(decrypted, 16)));
            string username = (string)this.client.info["username"];
            using var db = new RedStoneContext();

            var avatar = db?.Avatars?.Where(context => context.Name == name).FirstOrDefault();

            if (avatar != null)
            {
                byte[] alreadyExistsResponse = Convert.FromHexString("3C000411000002000000A72E0000454D50545900000000000000000000000000FFFF000000000000000000003139322E3136382E302E320000000000");
                this.client.socket.Send(alreadyExistsResponse);
            } else
            {
                var index = db?.Avatars?.Where(context => context.Username == username).Count();

                ushort field = 433;
                byte x = 8;
                byte y = 19;
                ushort level = 25;

                db?.Avatars?.Add(new RSLIB.Database.Models.Avatar { Name = name, Job = job[0], Level = 1, LastField = field, PositionX = x, PositionY = y, Username = username });
                db?.SaveChanges();
                
                CharacterCreatedPacketResponse createdResponse = new CharacterCreatedPacketResponse((byte)index, name, level, job[0], x, y, field, "127.0.0.1", this.client);
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
