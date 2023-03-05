using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Database.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? ServerName { get; set; }
        public string? MacAddress { get; set; }
        public string? ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}

    }
}
