using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.Packets
{
    public interface IPacketReceive
    {
        public void SetPacketAndClient(byte[] packet, Client client);
    }
}
