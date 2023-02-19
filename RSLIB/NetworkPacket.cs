using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB
{
    public class NetworkPacket
    {
        private readonly uint[] EncryptionKey = new uint[] { 0x6F, 0x40 };
        private readonly uint[] StringEncryptionSeed = new uint[] { 0x64, 0x64 };
        private const uint RANDOM_OFFSET = 0x7C;
        private const int PACKET_SIZE = 0x2;
        private const int DECODEKEY_SIZE = 0x4;
        public readonly byte[] packetLength;
        public readonly byte[] decodeKeyBytes;
        public uint cipherId;
        private byte[] cipher;

        public NetworkPacket(byte[] data)
        {
            cipher = data;
            packetLength = Helper.GetBytesFromBegin(cipher, PACKET_SIZE);
            cipher = Helper.JumpBytesFromBebin(cipher, PACKET_SIZE);
            decodeKeyBytes = Helper.GetBytesFromBegin(cipher, DECODEKEY_SIZE);
            cipherId = BitConverter.ToUInt16(decodeKeyBytes);
            cipher = Helper.JumpBytesFromBebin(cipher, DECODEKEY_SIZE);
        }
  
        public byte[] Decrypt()
        {
            CryptRandom random = new CryptRandom(cipherId);
            uint range = cipherId % EncryptionKey[0] + EncryptionKey[1];
            cipher = cipher.Select(result => (byte)(result - (byte)(random.Next(range) + RANDOM_OFFSET))).ToArray();
            return cipher;
        }
        public byte[] Encrypt()
        {
            CryptRandom random = new CryptRandom(cipherId);
            uint range = cipherId % EncryptionKey[0] + EncryptionKey[1];
            cipher = cipher.Select(result => (byte)(result + (byte)(random.Next(range) + RANDOM_OFFSET))).ToArray();
            this.PrepareData();
            return cipher;
        }

        private byte[] PrepareData()
        {
            string data = BitConverter.ToString(packetLength).Replace("-", "")
                + BitConverter.ToString(decodeKeyBytes).Replace("-", "")
                + BitConverter.ToString(cipher).Replace("-", "");
            cipher = Helper.HexStringToByte(data);
            return cipher;
        }
    }
}
