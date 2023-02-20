using System.Net.Sockets;
using System.Text;

namespace RSLIB
{
    public static class Helper
    {
        public static byte[] HexStringToByte(string hex)
        {
            hex = hex.Replace(" ", "");
            return Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
        }

        public static byte[] FillLength(string value, int size)
        {
            byte[] valueByte = Encoding.UTF8.GetBytes(value);
            byte[] bytes = new byte[size];
            Boolean first = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i < value.Length)
                {
                    bytes[i] = valueByte[i];
                }
                else
                {
                    if (first)
                    {
                        bytes[i] = 0x00;
                        first = false;
                    }
                    else
                    {
                        bytes[i] = 0xFF;
                    }
                }
            }
            return bytes;
        }

        public static byte[] JumpBytesFromBebin(byte[] bytes, int size)
        {
            Array.Reverse(bytes);
            byte[] result = bytes.Take(bytes.Length - size).ToArray();
            Array.Reverse(result);
            return result;
        }

        public static byte[] GetBytesFromBegin(byte[] bytes, int size)
        {
            MemoryStream stream = new MemoryStream(bytes);
            BinaryReader reader = new BinaryReader(stream);
            return reader.ReadBytes(size);
        }

        public static ushort GetReadUint16(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            BinaryReader reader = new BinaryReader(stream);
            return reader.ReadUInt16();
        }

        public static byte[] GetBytesUntilNull(byte[] input)
        {
            int length = Array.IndexOf(input, (byte)0);
            if (length < 0)
            {
                length = input.Length;
            }
            byte[] result = new byte[length];
            Buffer.BlockCopy(input, 0, result, 0, length);
            return result;
        }

        public static uint GetCipherID(string bytes)
        {
            NetworkPacket packetWorker = new NetworkPacket(HexStringToByte(bytes));
            return packetWorker.cipherId;
        }

        public static void SendPacketResponse(Socket socket, string data)
        {
            if (data != null)
            {
                data = data.Replace(" ", "");
                socket.Send(HexStringToByte(data));
            }
        }

        public static string BytesToString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public static string ReplaceBytes(string originalBytesString, string newValue, int startIndex, int size)
        {
            byte[] originalBytes = HexStringToByte(originalBytesString);
            byte[] newBytes = Encoding.ASCII.GetBytes(newValue);
            Array.Resize(ref newBytes, size);
            byte[] result = new byte[originalBytes.Length];
            Array.Copy(originalBytes, result, originalBytes.Length);
            int bytesToReplace = Math.Min(newBytes.Length, originalBytes.Length - startIndex);
            Array.Copy(newBytes, 0, result, startIndex, bytesToReplace);
            return BitConverter.ToString(result).Replace("-", "");
        }
    }
}