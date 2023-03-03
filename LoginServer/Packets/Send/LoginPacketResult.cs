using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoginServer.Packets.Send
{
    internal class LoginPacketResult
    {
        private RSLIB.Network.Client client;

        public void SuccessfullyLoggedIn()
        {
            string data = "110001110000070000001C020000660700";
            this.client.socket.Send(Helper.HexStringToByte(data));
        }

        public void InvalidCredentials()
        {
            string data = "110001110000010000001C020000CAB000";
            this.client.socket.Send(Helper.HexStringToByte(data));
        }

        public void AlreadyLoggedIn()
        {
            string data = "110001110000020000001C020000660700";
            this.client.socket.Send(Helper.HexStringToByte(data));
        }

        public void SetPacketAndClient(RSLIB.Network.Client client)
        {
            this.client = client;
        }
    }
}
