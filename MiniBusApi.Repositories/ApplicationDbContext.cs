using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Entities.Administration;

namespace MiniBusManagement.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public readonly DbSet<MiniBus> MiniBuses;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<MiniBusDBEntity> Minibuses { get; set; }
        public DbSet<PlaceDBEntity> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MiniBusDBEntity>().HasData(
                 new MiniBusDBEntity
                 {
                     Id = 1,
                     IdCompany = 1,
                     Brand = "Toyota",
                     Plate = "PAK715",
                     Capacity = "3",
                     Tipo = "Van",
                     InsertionDate = DateTime.Now,
                     ModificationDate = DateTime.Now
                 },
                 new MiniBusDBEntity
                 {
                     Id = 2,
                     IdCompany = 1,
                     Brand = "Mazada",
                     Plate = "CL1715",
                     Capacity = "6",
                     Tipo = "Car",
                     InsertionDate = DateTime.Now,
                     ModificationDate = DateTime.Now
                 },
                 new MiniBusDBEntity
                 {
                     Id = 3,
                     IdCompany = 1,
                     Brand = "Isuzu",
                     Plate = "BUS715",
                     Capacity = "7",
                     Tipo = "Bus",
                     InsertionDate = DateTime.Now,
                     ModificationDate = DateTime.Now
                 },
                 new MiniBusDBEntity
                 {
                     Id = 4,
                     IdCompany = 1,
                     Brand = "Ford",
                     Plate = "625630",
                     Capacity = "8",
                     Tipo = "Tri",
                     InsertionDate = DateTime.Now,
                     ModificationDate = DateTime.Now
                 }
          );
            modelBuilder.Entity<PlaceDBEntity>().HasData(
                new PlaceDBEntity
                {
                    Id = 1,
                    Provincia = "San José",
                    Canton = "Puriscal",
                    Name = "Ruta Herradura",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    UserInsert = "Roberto Diaz",
                    UserModifies = "Roberto"
                },
                new PlaceDBEntity
                {
                    Id = 2,
                    Provincia = "San José",
                    Canton = "Ciudad Colón",
                    Name = "Ruta del Sol",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    UserInsert = "Roberto Diaz",
                    UserModifies = "Roberto"
                }
            );
        }
    }
}
