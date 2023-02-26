using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB
{
    public struct Job
    {
        public const byte Squire = 0x00;
        public const byte Warrior = 0x01;
        public const byte Magician = 0x02;
        public const byte Wolf = 0x03;
        public const byte Archer = 0x09;
        public const byte Lancer = 0x08;
        public const byte Priest = 0x04;
        public const byte Fallen = 0x05;
        public const byte Thief = 0x06;
        public const byte Monk = 0x07;
        public const byte Tamer = 0x0A;
        public const byte Summoner = 0x0B;
        public const byte Princess = 0x0C;
        public const byte LittleWitch = 0x0D;
        public const byte Necromancer = 0x0E;
        public const byte Demon = 0x0F;
        public const byte Spiritualist = 0x10;
        public const byte Champion = 0x11;
        public const byte Opticalist = 0x12;
        public const byte Opticalist2 = 0x13;

        public Job()
        {
        }

        public static byte GetTransformJob(byte job)
        {
            switch(job)
            {
                case Squire: return Warrior;
                case Magician: return Wolf;
                case Archer: return Lancer;
                case Priest: return Fallen;
                case Thief: return Monk;
                case Tamer: return Summoner;
                case Princess: return LittleWitch;
                case Necromancer: return Demon;
                case Spiritualist: return Champion;
                case Opticalist: return Opticalist2;

                case Lancer: return Archer;
                case Wolf: return Magician;
                case Monk: return Thief;
                case Warrior: return Squire;
                case Summoner: return Tamer;
                case LittleWitch: return Princess;
                case Demon: return Necromancer;
                default: return Warrior;

            }
        }
    }
}