using Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Data.Context
{
    public class BussinessContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("ProgrammingTest3");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(product => product.Models)
                .WithOne(model => model.Product)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public virtual DbSet<Product> Addresses { get; set; }
        public virtual DbSet<Model.Model> Clients { get; set; }
    }
}
