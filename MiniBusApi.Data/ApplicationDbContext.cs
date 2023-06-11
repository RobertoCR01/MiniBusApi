using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Entities.Administration;
using System.Net;
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
            modelBuilder.Entity<UserDBEntity>().HasData(
              new UserDBEntity
              {
                  Id = 1,
                  login="Rdiaz",
                  UserEmail="prueba01@gmail.com",
                  UserName="Usuario 01",
                  UserPassword="pass01",
                  UserPhone="25365600",
                  InsertionDate = DateTime.Now,
                  ModificationDate = DateTime.Now,
                  UserInsert = "Roberto",
                  UserModifies = "RobertoM"
              },
              new UserDBEntity
              {
                  Id = 2,
                  login = "Rdiaz02",
                  UserEmail = "prueba02@gmail.com",
                  UserName = "Usuario 02",
                  UserPassword = "pass02",
                  UserPhone = "25365600",
                  InsertionDate = DateTime.Now,
                  ModificationDate = DateTime.Now,
                  UserInsert = "Roberto",
                  UserModifies = "RobertoM"
              }
          );
            modelBuilder.Entity<RolDBEntity>().HasData(
              new RolDBEntity
              {
                  Id = 1,
                  Description="Rol 01 de Gerentes de tiendas",
                  Name= "Gerentes",
                  InsertionDate = DateTime.Now,
                  ModificationDate = DateTime.Now,
                  UserInsert = "Roberto",
                  UserModifies = "RobertoM"
              },
              new RolDBEntity
              {
                  Id = 2,
                  Description = "Rol 02 de Gerentes de ferreterias",
                  Name = "Gerentes Ferrteria",
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
                },
                new MiniBusDBEntity
                {
                    Id = 2,
                    // CompanyId  = 1,
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
                    // CompanyId = 1,
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
                    //CompanyId = 1,
                    Brand = "Ford",
                    Plate = "625630",
                    Capacity = 8,
                    Tipo = "Tri",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                }
        );
        }
    }
}
