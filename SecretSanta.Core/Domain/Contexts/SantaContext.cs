using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.EntityFrameworkCore;
    
namespace SecretSanta.Core.Domain.Contexts
{
    public class SantaContext : DbContext
    {
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

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySQL("");
        // }
    }
}
