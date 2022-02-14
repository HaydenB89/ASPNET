using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibraryProject.Models {

    public class PRSDbContext : DbContext {

        public virtual DbSet<User> Users { get; set; }

        public PRSDbContext() {}

        public PRSDbContext(DbContextOptions<PRSDbContext>options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if(!builder.IsConfigured) {
                builder.UseSqlServer(
                    "server=localhost\\sqlexpress;database=PRSLibraryProject;trusted_connection=true;"
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<User>(e/*entity*/ => {                       // the e. and p. could be called anything
                e.HasIndex(p/*property*/ => p.UserName).IsUnique(true); //sql will not let tables have save name
            });
        }


    }
}
