using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.Packets
{
    public interface IPacketHandler
    {
        public void SetPacketAndClient(byte[] packet, Client client);
        public void Run();
    }
}
