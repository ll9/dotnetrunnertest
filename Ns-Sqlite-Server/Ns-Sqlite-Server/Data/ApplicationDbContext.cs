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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lichtpunkt>()
                .Property(lp => lp.Id).HasDefaultValueSql("hex(randomblob(16))");
        }
    }
}
