using GameServer.Packets.Send;
using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Packets.Receive
{
    internal class LocalMessageRequestPacket : IPacketHandler
    {
        private byte[] packet;
        private Client client;
        private Client[] clients;

        public void Run()
        {
            string msg = Helper.GetStringFromRange(packet, 26, packet.Length - 26);

            if ( msg.StartsWith("@warp") )
            {
                WarpPacketSender warp = new WarpPacketSender(client);
                warp.SendToMap(msg);
            } else
            {
                Log.Info(msg);
            }

        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.client = client;
            this.packet = packet;
        }

        private byte[] DecodeLoginString(ushort securityCode, byte[] str)
        {
            const uint EncryptionSeed = 0x64;
            var rand = new CryptRandom(securityCode);
            uint range = securityCode % EncryptionSeed + EncryptionSeed;
            uint sum = 0;
            List<byte> decoded = new List<byte>();
            foreach (byte b in str)
            {
                sum += b;
                decoded.Add((byte)(b - (byte)rand.Next(range)));
            }
            return Helper.GetBytesUntilNull(decoded.ToArray());
        }

    }
}
