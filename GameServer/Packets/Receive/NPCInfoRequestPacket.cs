﻿using GameServer.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class NPCInfoRequestPacket :IPacketHandler
    {
        private byte[] _packet;
        private Client Client_client;

        public void Run()
        {

            byte[] response_1 = Convert.FromHexString("90 08 3D 12 00 00 00 00 0F 27 00 00 00 00 00 00 00 00 00 00 EC 13 00 00 B8 0B 00 00 00 00 00 00 00 00 00 00 64 00 64 00 19 00 0F 00 14 00 0A 00 05 00 0F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 92 AF 4B 12 98 00 01 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 B5 5C AE 2E A5 00 01 00 01 0F FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 C8 54 32 3F AC 00 01 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 74 65 6D 70 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 47 4D 5F 42 69 67 72 69 64 62 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 B8 0B 00 00 B8 0B 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 01 00 01 00 02 00 01 00 03 00 01 00 04 00 01 00 05 00 01 00 06 00 01 00 07 00 01 00 08 00 01 00 09 00 01 00 0A 00 01 00 0B 00 01 00 0C 00 01 00 0D 00 01 00 0E 00 01 00 0F 00 01 00 10 00 01 00 11 00 01 00 12 00 01 00 13 00 01 00 14 00 01 00 15 00 01 00 16 00 01 00 17 00 01 00 18 00 01 00 19 00 01 00 1A 00 01 00 1B 00 01 00 1C 00 01 00 1D 00 01 00 1E 00 01 00 1F 00 01 00 20 00 01 00 21 00 01 00 22 00 01 00 23 00 01 00 24 00 01 00 25 00 01 00 26 00 01 00 27 00 01 00 28 00 01 00 29 00 01 00 2A 00 01 00 2B 00 01 00 2C 00 01 00 2D 00 01 00 2E 00 35 00 2F 00 01 00 30 00 01 00 31 00 01 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00".Replace(" ", ""));
            this.Client_client.socket.Send(response_1);

        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this._packet = packet;
            Client_client = client;
        }
    }
}


