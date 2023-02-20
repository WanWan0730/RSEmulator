using LoginServer.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class CharacterListPacket : IPacketHandler
    {
        private string packetString = "28 01 03 11 00 00 59 0D 00 00 41 72 71 75 65 69 72 61 00 00 00 00 00 00 00 00 00 00 09 00 01 00 F0 00 FF FF FF FF 00 00 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 01 00 74 65 73 74 65 00 00 00 00 00 00 00 00 00 00 00 00 00 04 00 01 00 DA 00 FF FF FF FF 00 00 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 02 00 31 32 33 31 32 33 00 00 00 00 00 00 00 00 00 00 00 00 0C 00 01 00 10 01 FF FF FF FF 00 00 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 03 00 31 32 33 31 32 33 34 00 00 00 00 00 00 00 00 00 00 00 0E 00 01 00 20 01 FF FF FF FF 00 00 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 04 00 61 73 64 61 73 64 00 00 00 00 00 00 00 00 00 00 00 00 07 00 01 00 FF FF FF FF FF FF 00 00 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 05 00 61 61 61 61 61 61 61 61 61 61 61 61 61 61 61 61 00 00 01 00 01 00 C9 00 C2 00 FF FF 00 00 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00";

        private string packetStringx = "28 01 03 11 00 00 BE 00 00 00 6E 6F 6D 65 6E 6F 6D 65 6E 6F 6D 65 6E 6F 6D 65 6E 6F 07 00 0F 01 00 07 F8 00 FF FF 00 00 31 39 32 2E 31 36 38 2E 31 36 30 2E 31 38 30 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
        private byte[] packet;
        private Client client;



        public void Run()
        {
            byte[] charlist = RSLIB.Helper.HexStringToByte(this.packetString);
            this.client.socket.Send(charlist);
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.packet = packet;
            this.client = client;
        }
    }
}

//Character class -> 1C | 28 [1byte]
//00 Squire
//01 Warrior
//02 Magician
//03 Wolf
//04 Priest
//05 Fallen
//06 Theif
//07 Monk
//08 Lancer
//09 Archer
//0A Tamer
//0B Summoner
//0C Princess
//0D Little Witch
//0E Necromancer
//0F Demon
//10 Spiritualist
//11 Champion
//12 Opticalist

//Char level little endian -> 1E | 30 [2bytes]

//Char name -> A | 10 [12bytes]

//IP -> 28 | 40 [16bytes]