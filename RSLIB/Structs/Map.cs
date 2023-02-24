using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Structs
{
    public struct Map
    {

        public Map()
        {
        }

        public static string GetMapFileNameBytesByNumber(int mapNumber)
        {

            string mapId = mapNumber.ToString();
            switch (mapId.Length)
            {
               case 1:
                    mapId = $"00{mapId}";
                    break;
                case 2:
                    mapId = $"0{mapId}";
                    break;
                case 3:
                    break;
                default:
                    mapId = "000";
                    break;
            }

            string mapsFolder = @"C:\Users\samue\source\repos\RSEmulator\RSLIB\Data\Scenario\Red_Stone\Map\";
            string searchPattern = $"[{mapId}]*.rmd";
            string filePath = Directory.EnumerateFiles(mapsFolder, searchPattern).FirstOrDefault();
            string mathFile = Path.GetFileName(filePath) ?? "[028]Prison.rmd";
            return mathFile;
        }

    }
}
