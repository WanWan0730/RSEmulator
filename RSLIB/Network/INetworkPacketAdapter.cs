using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Network
{
    public interface INetworkPacketAdapter
    {
        public void SetParams(Client client, Server server, byte[] buffer);
    }
}
