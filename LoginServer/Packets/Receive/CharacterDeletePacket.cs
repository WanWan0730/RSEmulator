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
            NetworkSecurity packetWorker = new NetworkSecurity(packet);
            byte[] decrypted = packetWorker.Decrypt();

            decrypted = Helper.JumpBytesFromBebin(decrypted, 6);
            string decrypted_name = Encoding.UTF8.GetString(Helper.GetBytesUntilNull(Helper.GetBytesFromBegin(decrypted, 16)));

            using var db = new RedStoneContext();

            var avatar = db.Avatars.Where(context => context.Name == decrypted_name).FirstOrDefault();
            if(avatar != null)
            {
                db.Avatars.Remove(avatar);
                db.SaveChanges();
            }
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
