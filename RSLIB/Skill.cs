using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB
{
    public static class Skill
    {

        public static byte[] GetSkillsBytesByJob(byte job)
        {
            int skills_per_job = 25;
            int begin = job * skills_per_job;
            int end = begin + skills_per_job;

            List<byte> result = new List<byte>();

            for(int index = begin; index < end; index++) {

                byte[] skill_index = BitConverter.GetBytes((short)index);

                result.AddRange(skill_index);
                //Skill level
                result.AddRange(new byte[]{0x01, 0x00});
            }
            return result.ToArray();
        }

    }
}
