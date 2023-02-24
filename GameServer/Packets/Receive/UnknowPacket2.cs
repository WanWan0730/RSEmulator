﻿using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Packets.Receive
{
    internal class UnknowPacket2 : IPacketHandler
    {
        private byte[] packer;
        private Client client;

        public void Run()
        {
            this.client.socket.Send(Convert.FromHexString("0C 00 24 11 00 00 67 00 B8 0B B8 0B 0C 00 8A 11 00 00 90 01 B8 0B B8 0B 18 00 70 12 00 00 2D DD 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 40 03 2A 11 00 00 67 00 00 20 02 00 5A 03 05 01 01 20 02 00 8B 0B FD 05 02 20 02 00 16 02 44 07 03 20 02 00 22 04 E0 07 04 20 02 00 1C 09 BA 07 05 20 02 00 AA 07 C5 04 06 20 02 00 6F 0B BF 07 07 20 02 00 94 08 2E 07 08 20 02 00 1E 09 31 07 09 20 02 00 A1 09 3B 07 0A 20 02 00 93 08 AE 06 0B 20 02 00 1A 09 AE 06 0C 20 02 00 A1 09 A3 06 0D 20 02 00 6A 06 18 07 0E 20 02 00 C8 06 18 07 0F 20 02 00 67 06 C2 06 10 20 02 00 A4 01 81 07 11 20 02 00 D6 0B C0 07 12 20 02 00 E0 02 E3 06 13 20 02 00 7B 09 BC 04 14 20 02 00 A3 09 BB 07 15 20 02 00 95 08 BC 07 16 20 02 00 25 09 39 08 17 20 02 00 AC 09 38 08 18 20 02 00 78 07 8A 09 19 20 02 00 36 0C C1 07 1A 20 02 00 D4 0B 58 07 1B 20 02 00 A7 01 52 08 1C 20 02 00 8A 02 18 07 1D 20 02 00 10 02 53 08 1E 20 02 00 79 02 52 08 1F 20 02 00 37 0C 5C 07 20 20 02 00 C1 06 BC 06 21 20 02 00 E5 04 E3 07 22 20 02 00 6C 06 ED 07 23 20 02 00 EE 06 EC 07 24 20 02 00 73 06 6D 08 25 20 02 00 F7 06 70 08 26 20 02 00 75 06 01 09 27 20 02 00 30 0B B1 03 28 20 02 00 56 07 CD 06 29 20 02 00 A9 07 CB 06 2A 20 02 00 73 0B 62 07 2B 20 02 00 D8 03 58 06 2C 20 02 00 6E 06 32 06 2D 20 02 00 29 0C DF 06 2E 20 02 00 E5 05 29 07 2F 20 02 00 07 06 33 06 30 20 02 00 73 03 8D 06 31 20 02 00 55 07 3A 07 32 20 02 00 F5 07 CB 06 33 20 02 00 2C 04 33 06 34 20 02 00 26 0C 91 06 35 20 02 00 13 09 BC 04 36 20 02 00 BA 0D 85 05 37 20 02 00 ED 0A 94 06 38 20 02 00 3E 0B 93 06 39 20 02 00 89 0B 92 06 3A 20 02 00 D6 0B 92 06 3B 20 02 00 EE 0A E5 06 3C 20 02 00 3D 0B E2 06 3D 20 02 00 8B 0B E0 06 3E 20 02 00 D6 0B DF 06 3F 20 02 00 AF 08 BB 04 40 20 02 00 37 0C 82 05 41 20 02 00 F6 0C 82 05 42 20 02 00 DA 09 BC 04 43 20 02 00 A3 08 36 05 44 20 02 00 38 08 37 05 45 20 02 00 05 07 01 09 46 20 02 00 34 08 C2 04 47 20 02 00 38 0A B9 04 48 20 02 00 E5 09 33 05 49 20 02 00 3F 0A 33 05 4A 20 02 00 1C 04 8F 08 4B 00 FF FF BB 0A E1 00 4C 00 FF FF EE 0A 07 01 4D 00 FF FF 21 0C 07 01 4E 00 FF FF 65 0A 70 01 4F 00 FF FF D7 0B 99 01 50 00 FF FF 68 0C B5 01 51 00 FF FF 0B 0D 70 01 52 00 FF FF AD 0A 3C 02 53 00 FF FF BB 0B DA 01 54 00 FF FF A5 0B EB 01 55 00 FF FF 0B 0D 2C 02 56 00 FF FF 2B 0D C2 01 57 00 FF FF 3F 0B AE 02 58 00 FF FF 97 0B 6F 02 59 00 FF FF FC 0B C9 02 5A 00 FF FF 88 0A F4 02 5B 00 FF FF 77 0B E5 02 5C 00 FF FF FC 0B 3A 03 5D 00 FF FF E7 0C E2 02 5E 00 FF FF E3 0B B5 03 5F 00 FF FF 48 0D 91 03 60 00 FF FF 06 0E D9 03 61 00 FF FF 0E 09 5B 05 62 00 FF FF 6A 09 43 05 63 00 FF FF A8 0C 30 04 64 00 FF FF 3D 0D 88 04 65 00 FF FF F4 0D 5E 04 66 00 FF FF 15 07 5E 06 8C 03 15 12 00 00 4B 00 01 E0 31 0C 01 64 5A 03 05 01 00 00 05 20 32 0C 12 64 8B 0B FD 05 00 00 09 E0 31 0B 01 64 16 02 44 07 00 00 0D 00 31 08 01 64 22 04 E0 07 00 00 11 20 30 08 01 64 1C 09 BA 07 00 00 15 80 2C 08 01 64 AA 07 C5 04 00 00 19 A0 2F 08 03 64 6F 0B BF 07 00 00 1D 20 31 08 01 64 94 08 2E 07 00 00 21 20 31 08 01 64 1E 09 31 07 00 00 25 20 31 08 01 64 A1 09 3B 07 00 00 29 60 18 08 01 64 93 08 AE 06 00 00 2D 60 18 08 01 64 1A 09 AE 06 00 00 31 60 18 08 01 64 A1 09 A3 06 00 00 35 80 2C 08 01 64 6A 06 18 07 00 00 39 80 2C 08 01 64 C8 06 18 07 00 00 3D 80 2C 0C 01 64 67 06 C2 06 00 00 41 E0 31 0B 01 64 A4 01 81 07 00 00 45 A0 2F 08 01 64 D6 0B C0 07 00 00 49 E0 31 0B 01 64 E0 02 E3 06 00 00 4D 60 0E 0C 01 64 7B 09 BC 04 00 00 51 20 30 08 01 64 A3 09 BB 07 00 00 55 20 30 08 01 64 95 08 BC 07 00 00 59 20 30 08 01 64 25 09 39 08 00 00 5D 20 30 08 01 64 AC 09 38 08 00 00 61 80 2C 08 01 64 78 07 8A 09 00 00 65 A0 2F 08 01 64 36 0C C1 07 00 00 69 A0 2F 0C 01 64 D4 0B 58 07 00 00 6D 80 2C 08 01 64 A7 01 52 08 00 00 71 E0 31 0B 01 64 8A 02 18 07 00 00 75 80 2C 08 01 64 10 02 53 08 00 00 79 80 2C 08 01 64 79 02 52 08 00 00 7D A0 2F 0C 01 64 37 0C 5C 07 00 00 81 80 2C 08 01 64 C1 06 BC 06 00 00 85 C0 2B 0C 01 64 E5 04 E3 07 00 00 89 60 18 0C 01 64 6C 06 ED 07 00 00 8D 60 18 0C 01 64 EE 06 EC 07 00 00 91 60 18 0C 01 64 73 06 6D 08 00 00 95 60 18 0C 01 64 F7 06 70 08 00 00 99 60 18 0C 01 64 75 06 01 09 00 00 9D E0 31 0C 01 64 30 0B B1 03 00 00 A1 00 33 0C 01 64 56 07 CD 06 00 00 A5 00 33 0C 01 64 A9 07 CB 06 00 00 A9 00 33 0C 01 64 73 0B 62 07 00 00 AD 00 33 0B 01 64 D8 03 58 06 00 00 B1 60 52 08 01 64 6E 06 32 06 00 00 B5 60 2E 04 01 64 29 0C DF 06 00 00 B9 60 2E 08 01 64 E5 05 29 07 00 00 BD 60 52 0C 01 64 07 06 33 06 00 00 C1 60 89 0B 01 64 73 03 8D 06 00 00 C5 00 33 08 01 64 55 07 3A 07 00 00 C9 60 32 0C 01 64 F5 07 CB 06 00 00 CD 40 84 0B 01 64 2C 04 33 06 00 00 D1 60 2E 0C 01 64 26 0C 91 06 00 00 D5 60 2E 0C 01 64 13 09 BC 04 00 00 D9 C0 30 0C 01 64 BA 0D 85 05 00 00 DD 60 2E 0C 01 64 ED 0A 94 06 00 00 E1 60 2E 0C 01 64 3E 0B 93 06 00 00 E5 60 2E 0C 01 64 89 0B 92 06 00 00 E9 60 2E 0C 01 64 D6 0B 92 06 00 00 ED 60 2E 0C 01 64 EE 0A E5 06 00 00 F1 60 2E 0C 01 64 3D 0B E2 06 00 00 F5 60 2E 0C 01 64 8B 0B E0 06 00 00 F9 60 2E 0C 01 64 D6 0B DF 06 00 00 FD 00 33 0C 01 64 AF 08 BB 04 00 00 01 21 30 0C 01 64 37 0C 82 05 00 00 05 E1 30 0C 01 64 F6 0C 82 05 00 00 09 41 2C 0C 01 64 DA 09 BC 04 00 00 0D 01 31 08 0A 64 A3 08 36 05 00 00 11 E1 2C 0C 01 64 38 08 37 05 00 00 15 61 18 0C 01 64 05 07 01 09 00 00 19 01 97 04 01 46 34 08 C2 04 00 00 1D 81 2C 0C 01 64 38 0A B9 04 00 00 21 E1 2C 0C 01 64 E5 09 33 05 00 00 25 E1 2B 0C 01 64 3F 0A 33 05 00 00 29 01 31 0C 01 64 1C 04 8F 08 00 00".Replace(" ", "")));
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.client = client;
            this.packer = packet;
        }
    }
}