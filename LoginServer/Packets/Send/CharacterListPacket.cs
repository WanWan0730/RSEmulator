using LoginServer.Packets;
using RSLIB;
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
        private byte[] packet;
        private Client client;

        public void Run()
        {
            List<byte> result= new List<byte>();


            Character char1 = new Character("Moyka", RSLIB.Job.Archer, 0, 0, 409, 165, 1250, "192.168.0.5");
            result.AddRange(char1.GetBytes());
            //result.AddRange(Character.GetEmpty(true));

            Character char2 = new Character("Jesuit", RSLIB.Job.Fallen, 1, 0xF0, 409, 165, 1057, "192.168.0.5");
            result.AddRange(char2.GetBytes());
            //result.AddRange(Character.GetEmpty());

            //Character char3= new Character("Jesuit2", RSLIB.Job.Summoner, 2, 28, 409, 165, 450, "192.168.0.5");
            //result.AddRange(char3.GetBytes());
            result.AddRange(Character.GetEmpty());

            //Character char4 = new Character("Jesui3t", RSLIB.Job.Opticalist, 3, 28, 409, 165, 450, "192.168.0.5");
            //result.AddRange(char4.GetBytes());
            result.AddRange(Character.GetEmpty());

            //Character char5 = new Character("Jesuit4", RSLIB.Job.Magician, 4, 28, 409, 165, 450, "192.168.0.5");
            //result.AddRange(char5.GetBytes());
            result.AddRange(Character.GetEmpty());

            //Character char6 = new Character("Jesuit333", RSLIB.Job.LittleWitch, 5, 28, 409, 165, 450, "192.168.0.5");
            //result.AddRange(char6.GetBytes());
            result.AddRange(Character.GetEmpty());


            Log.Debug($"PACKET: {BitConverter.ToString(result.ToArray()).Replace("-", "")}");
            //Log.Debug($"EMPTY PACKET: {BitConverter.ToString(empty.ToArray()).Replace("-", "")}");
            this.client.socket.Send(result.ToArray());
        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.packet = packet;
            this.client = client;
        }
    }
}

//Char level little endian -> 1E | 30 [2bytes]

//Char name -> A | 10 [12bytes]

//IP -> 28 | 40 [16bytes]