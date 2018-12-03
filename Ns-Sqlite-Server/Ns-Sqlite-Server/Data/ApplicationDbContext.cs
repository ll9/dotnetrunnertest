using Microsoft.EntityFrameworkCore;
using NsSqliteServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NsSqliteServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Lichtpunkt> Lichtpunkt { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lichtpunkt>()
                .Property(lp => lp.Id).HasDefaultValueSql("hex(randomblob(16))");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=""C:\Users\Lenovo G50-45\Desktop\tmp\dotnetrunnertest\Ns-Sqlite-Server\Ns-Sqlite-Server\test.db""");
        }
    }
}
