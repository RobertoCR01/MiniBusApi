using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Entities.Administration;
using System.Net;
using System.Numerics;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace MiniBusManagement.Data.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<MiniBusDBEntity> Minibuses { get; set; }
        public DbSet<CompanyDBEntity> Companies { get; set; }
        public DbSet<UserDBEntity> Users { get; set; }
        public DbSet<RolDBEntity> Roles { get; set; }




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
                },
                new CompanyDBEntity
                {
                    Id = 2,
                    ContactNumber = "250000",
                    ContactName = "Roberto Perez",
                    City = "San Jose",
                    Address = "359 chch",
                    Email = "Roberto@hotmail.com",
                    Name = "Prueba",
                    Phone = "25655656",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    UserInsert = "Roberto",
                    UserModifies = "RobertoM"
                }
            );

            modelBuilder.Entity<MiniBusDBEntity>()
           .HasOne(o => o.Company)
           .WithMany(c => c.Minibuses)
           .HasForeignKey(o => o.CompanyId);


            modelBuilder.Entity<MiniBusDBEntity>().HasData(
                new MiniBusDBEntity
                {
                    Id = 1,
                    CompanyId = 2,
                    Plate = "Pak715",
                    Capacity = 20,
                    Brand = "Toyota",
                    Tipo = "Van",
                    Year = 2020,
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    UserInsert = "Roberto",
                    UserModifies = "Roberto",
                },
                 new MiniBusDBEntity
                 {
                     Id = 2,
                     CompanyId  = 1,
                     Brand = "Mazada",
                     Plate = "CL1715",
                     Capacity = 6,
                     Tipo = "Car",
                     InsertionDate = DateTime.Now,
                     ModificationDate = DateTime.Now
                 },
                new MiniBusDBEntity
                {
                    Id = 3,
                    CompanyId = 1,
                    Brand = "Isuzu",
                    Plate = "BUS715",
                    Capacity = 7,
                    Tipo = "Bus",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new MiniBusDBEntity
                {
                    Id = 4,
                    CompanyId = 1,
                    Brand = "Ford",
                    Plate = "625630",
                    Capacity = 8,
                    Tipo = "Tri",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    UserInsert = "Roberto",
                    UserModifies = "RobertoM"
                }
                );

        }
    }
}
