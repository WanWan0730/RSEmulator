using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Database.Models
{
    public class Avatar
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int LastField { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Level { get; set; }
        public int Job { get; set; }
        public string? Username { get; set; }
    }
}
