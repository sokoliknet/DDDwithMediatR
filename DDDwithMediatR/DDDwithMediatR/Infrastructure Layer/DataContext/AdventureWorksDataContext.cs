using DDDwithMediatR.Domain_Layer;
using DDDwithMediatR.Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DDDwithMediatR.DataContext
{
    public class AdventureWorksDataContext : DbContext
    {
        public AdventureWorksDataContext(DbContextOptions<AdventureWorksDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessEntity>().ToTable("BusinessEntity", "Person");

            modelBuilder.Entity<Person>(entry =>
            {
                entry.ToTable("Person", "Person");
            });

        }

        public DbSet<BusinessEntity> BusinessEntities { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
