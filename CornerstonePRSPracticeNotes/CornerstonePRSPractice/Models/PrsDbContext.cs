using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CornerstonePRSPractice.Models {
    public class PrsDbContext : DbContext {

        public virtual DbSet<User> Users { get; set; }


        public PrsDbContext(DbContextOptions<PrsDbContext>options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder) {

            builder.Entity<User>(e => { e.HasIndex(u => u.Username).IsUnique(true); });

            //builder.Entity<Vendor>(e => { e.HasIndex(c => c.Code).IsUnique(true); });

            //builder.Entity<Product>(e => { e.HasIndex(p => p.PartNbr).IsUnique(true); });

        }
    }
}
