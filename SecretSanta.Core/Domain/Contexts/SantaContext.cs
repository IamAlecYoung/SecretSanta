using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.EntityFrameworkCore;
    
namespace SecretSanta.Core.Domain.Contexts
{
    public class SantaContext : DbContext
    {
        private IConfigurationRoot _config;
        
        public SantaContext() {}
        public SantaContext(DbContextOptions<SantaContext> options) : base(options) { }

        public DbSet<Peeps> Peeps { get; set; }
        public DbSet<whopickedwho> WhoPickedWho { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peeps>()
                .HasKey(c => new { c.ID });

            modelBuilder.Entity<whopickedwho>()
                .HasKey(c => new { c.Person1, c.Person2});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_config == null)
            {
                _config 
                    = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile(@Directory.GetCurrentDirectory() + "/../SecretSanta.Web/appsettings.json")
                        .Build();
            }
            if(_config != null)
                optionsBuilder.UseMySQL(_config.GetConnectionString("SantaContext"));
        }
    }
}
