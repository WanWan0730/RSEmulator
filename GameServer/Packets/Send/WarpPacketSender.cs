using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Packets.Send
{
    public class WarpPacketSender
    {
        public Client client;

        public WarpPacketSender(Client client) { 
            this.client = client;
        }

        public void SendToMap(string message)
        {

            this.client.socket.Send(Convert.FromHexString("6A 00 28 11 CD CD CD CD 01 00 00 00 5E 00 55 11 00 00 01 00 00 CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC 5B 30 30 30 5D 54 30 31 2E 72 6D 64 00 CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC FF FF 00 00 00 00".Replace(" ", "")));
            this.client.socket.Send(Convert.FromHexString("26 00 28 11 CD CD CD CD 02 00 00 00 14 00 81 11 00 00 01 64 E7 03 0A 00 00 00 70 C8 00 00 00 00 06 00 E4 11 00 00".Replace(" ", "")));

            string code = message.Split(' ')[1];
            int.TryParse(code, System.Globalization.NumberStyles.Integer, null, out int result);

            string mapFileName = RSLIB.Structs.Map.GetMapFileNameBytesByNumber(result);
            List<byte> response = new List<byte>();

            response.AddRange(new byte[] { 0x6F, 0x00, 0x20, 0x11, 0x00, 0x00, 0x00, 0x00 });
            response.AddRange(new byte[] { 0xFF, 0xFF, 0x6B, 0x1E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xCC, 0xCC, 0x02, 0x00, 0x00, 0x00 });
            byte[] fileName = Encoding.UTF8.GetBytes(mapFileName);
            byte[] fileNameBytes = new byte[87];
            Array.Copy(fileName, 0, fileNameBytes, 0, fileName.Length);
            response.AddRange(fileNameBytes);
            this.client.socket.Send(response.ToArray());
        }

    }
}
