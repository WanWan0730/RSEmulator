using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldServer
{
    public interface IPacketHandler
    {
        public void SetPacketAndClient(byte[] packet, Client client);
        public void SetClients(byte[] packet, Client[] client) {}
        public void Run();
    }
}
