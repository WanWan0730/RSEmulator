using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Structs
{
    public struct Map
    {
        public byte[] HighBrunenstig = { 0x00, 0x00 };
        public byte[] GMROOM = { 0x1C, 0x00 };
        public byte[] CentralPlatenBoulevardEntranceArea = { 0xB1, 0x01 };

        public Map()
        {
        }
    }
}
