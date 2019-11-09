
namespace _0041_First_Application.Models.Contexts
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Transactions;

    public class DefaultContext : IdentityDbContext
    {
        public DefaultContext() { }

        public DefaultContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Wookie>().HasOne(item => item.Famille)
                .WithMany(item => item.Wookies)
                .HasForeignKey(item => item.FamilyId);
        }

        public DbSet<Wookie> Wookies { get; set; }

        public DbSet<Family> Familles { get; set; }
    }
}
