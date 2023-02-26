﻿using GameServer.Packets;
using RSLIB;
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

            //skill_points | offset 0x1C, len 3
            //status_points | offset 0x0738, len 2
            Log.Debug($"JOB {Client_client.avatar["job"]}");

            byte[] response_1 = Convert.FromHexString("90 08 3D 12 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 EC 13 00 00 B8 0B 00 00 00 00 00 00 00 00 00 00 64 00 64 00 19 00 0F 00 14 00 0A 00 05 00 0F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 FF FF 00 00 00 00 FF FF 00 00 FF FF 00 00 FF FF 00 00 00 00 00 00 74 65 6D 70 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 74 61 73 64 73 61 64 00 00 00 00 00 00 00 00 00 00 00 09 00 00 00 00 00 00 00 00 00 00 00 B8 0B 00 00 B8 0B 00 00 00 00 00 00 00 00 00 00 00 00 C8 00 01 00 C9 00 01 00 CA 00 01 00 CB 00 01 00 CC 00 01 00 CD 00 01 00 CE 00 01 00 CF 00 01 00 D0 00 01 00 D1 00 01 00 D2 00 01 00 D3 00 01 00 D4 00 01 00 D5 00 01 00 D6 00 01 00 D7 00 01 00 D8 00 01 00 D9 00 01 00 DA 00 01 00 DB 00 01 00 DC 00 01 00 DD 00 01 00 DE 00 01 00 DF 00 01 00 E0 00 01 00 E1 00 01 00 E2 00 01 00 E3 00 01 00 E4 00 01 00 E5 00 01 00 E6 00 01 00 E7 00 01 00 E8 00 01 00 E9 00 01 00 EA 00 01 00 EB 00 01 00 EC 00 01 00 ED 00 01 00 EE 00 01 00 EF 00 01 00 F0 00 01 00 F1 00 01 00 F2 00 01 00 F3 00 01 00 F4 00 01 00 F5 00 01 00 F6 00 01 00 F7 00 01 00 F8 00 01 00 F9 00 01 00 FF FF 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00".Replace(" ", ""));
            this.Client_client.socket.Send(response_1);

        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this._packet = packet;
            Client_client = client;
        }
    }
}


