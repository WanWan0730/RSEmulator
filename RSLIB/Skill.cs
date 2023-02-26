using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB
{
    public class Skill
    {
        private string path;

        public Skill()
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding sjis = Encoding.GetEncoding("shift_jis");
            Console.OutputEncoding = sjis;

            string csvpath = @"C:\Users\samue\source\repos\RSEmulator\RSLIB\Data\skill2_decrypted.txt";

            this.path = @"C:\Users\samue\source\repos\RSEmulator\RSLIB\Data\skill2_decrypted.dat";
            byte[] content = File.ReadAllBytes(this.path);
            byte[] all_skills = Helper.GetBytesFromRange(content, 12, content.Length - 12);
            
           
            int skill_length = 0x82C;
            
            int all_skills_len = all_skills.Length / skill_length;

            using ( StreamWriter writer = new StreamWriter(csvpath))
            {

               string skill_data = "";
                
                for (var index = 0; index < all_skills_len; index++)
                {
                    int skill_index = index * skill_length;
                    byte[] skill = Helper.GetBytesFromRange(all_skills, skill_index, skill_length);

                    string skill_name = sjis.GetString(Helper.GetBytesUntilNull(Helper.GetBytesFromRange(skill, 26, 32)));

                    if ( skill_name.StartsWith("valid") )
                    {
                        break;
                    }

                    byte[] skill_job = Helper.GetBytesFromRange(skill, 20, 1);
                     
                    string skill_description = sjis.GetString(Helper.GetBytesUntilNull(Helper.GetBytesFromRange(skill, 1776, 48)));

                    

                    if ((skill_job[0] == 0x08 || skill_job[0] == 0x09) && skill_description.Length > 0)
                    {
                        skill_data +=  $"{index.ToString("X")}000100";

                        Log.Debug(index.ToString());

                        //Log.Debug(skill_name);
                        //Log.Debug(skill_description);

                        // writer.WriteLine($"{skill_name}, {skill_description}");
                    }

                }

                Log.Debug(skill_data);

            }


        }


    }
}
