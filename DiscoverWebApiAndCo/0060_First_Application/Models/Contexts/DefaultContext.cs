
namespace _0041_First_Application.Models.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Transactions;

    public class DefaultContext : DbContext
    {
        public DefaultContext() { }

        public DefaultContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Wookie> Wookies { get; set; }
    }
}
