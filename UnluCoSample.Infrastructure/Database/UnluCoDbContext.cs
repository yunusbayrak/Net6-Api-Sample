using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCoSample.Domain.Entities;

namespace UnluCoSample.Infrastructure.Database
{
    public class UnluCoDbContext : DbContext
    {
        public UnluCoDbContext(DbContextOptions<UnluCoDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<NumberPlate> NumberPlates { get; set; }
    }
}
