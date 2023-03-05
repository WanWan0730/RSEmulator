using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB
{
    public class SetEnvironment
    {
        private string path = "C:\\Users\\samue\\source\\repos\\RSEmulator\\RSLIB\\.env";

        public SetEnvironment()
        {
            string[] enviroment = File.ReadAllLines(path);
            foreach(var line in enviroment)
            {
                string key = line.Split('=')[0];
                string value = line.Split("=")[1];
                Environment.SetEnvironmentVariable(key, value);
            }
        }

    }
}
