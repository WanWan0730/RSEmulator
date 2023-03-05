using Microsoft.EntityFrameworkCore;
using RSLIB.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Database
{
    public class RedStoneContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Avatar>? Avatars { get; set; }
        public DbSet<Session>? Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            new SetEnvironment();
            
            string? host = Environment.GetEnvironmentVariable("DB_HOST");
            string? port = Environment.GetEnvironmentVariable("DB_PORT");
            string? user = Environment.GetEnvironmentVariable("DB_USER");
            string? password = Environment.GetEnvironmentVariable("DB_PWRD");
            string? dbName = Environment.GetEnvironmentVariable("DB_NAME");

            optionsBuilder.UseMySQL($"server={host};database={dbName};port={port};uid={user};pwd={password}");
        }
    }
}
