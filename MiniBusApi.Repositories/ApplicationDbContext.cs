using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Entities.Administration;
using System.Net;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

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
        public DbSet<CompanyDBEntity> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyDBEntity>().HasData(
                new CompanyDBEntity
                {
                    Id = 1,
                    ContactNumber = "2655666",
                    ContactName = "Roberto Diaz",
                    City = "San Jose",
                    Address = "359 Avon",
                    Email = "Roberto@gmail.com",
                    Name = "Prueba",
                    Phone = "25655656",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    UserInsert = "Roberto",
                    UserModifies = "RobertoM"
                }
            );
            modelBuilder.Entity<MiniBusDBEntity>().HasData(
               new MiniBusDBEntity
               {
                   Id = 1,
                   Brand = "Toyota",
                   Plate = "PAK715",
                   Capacity = 3,
                   Tipo = "Van",
                   InsertionDate = DateTime.Now,
                   ModificationDate = DateTime.Now
               }
        );
        }
    }
}
