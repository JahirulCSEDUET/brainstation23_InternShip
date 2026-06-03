using Microsoft.EntityFrameworkCore;
using PracticeDay3.Models;

namespace PracticeDay3.Data
{
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options):base(options) { }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaAmenity> VillasAmenities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>()
                .HasData(
                new Villa { Id = 1, Name = "Jahir Villa", Price = 65324789 },
                new Villa { Id = 2, Name = "Raza Villa", Price = 732889.90 }
                );
            modelBuilder.Entity<VillaAmenity>()
                .HasData(
                new VillaAmenity { Id = 1, Name = "Velcony", VillaId = 1 },
                new VillaAmenity { Id = 2, Name = "Plambing Service", VillaId = 2 },
                new VillaAmenity { Id = 3, Name = "Private Pool", VillaId = 2 },
                new VillaAmenity { Id = 4, Name = "Pond", VillaId = 1 });
        }
    }
}
