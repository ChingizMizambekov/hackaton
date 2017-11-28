using Hackaton.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton.Data
{
    public class DroidContext : DbContext
    {
        public DroidContext(DbContextOptions<DroidContext> options)
            : base(options)
        {}
        public DbSet<Droid> Droids { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Droid>()
                 .HasIndex(e => e.Name)
                 .IsUnique(true);
        }
    }
}
