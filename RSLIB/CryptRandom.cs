using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB
{
    internal class CryptRandom
    {
        private uint Seed = 0;
        private const uint MULTIPLIER = 0x343FD;
        private const uint ADDEND = 0x269EC3;
        private const int SHIFT_VALUE = 0x10;
        private const uint MASK_VALUE = 0x7FFF;

        public CryptRandom(uint seed)
        {
            Seed = seed;
        }

        public uint Next(uint maxValue)
        {
            Seed = Seed * MULTIPLIER + ADDEND;
            uint resultBySeed = (Seed >> SHIFT_VALUE) & MASK_VALUE;
            return resultBySeed % maxValue;
        }
    }
}