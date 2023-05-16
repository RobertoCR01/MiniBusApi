using Microsoft.EntityFrameworkCore;
using MiniBusApi.Domain.Dto;
using MiniBusApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusApi.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base (options)
        { 
        
        }
        public DbSet<MiniBus> Minibuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MiniBus>().HasData(
                new MiniBus
                {
                    Id = 1,
                    IdCompany = 1,
                    Brand = "Toyota",
                    Capacity = "3",
                    Tipo = "Van",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new MiniBus
                {
                    Id = 2,
                    IdCompany = 1,
                    Brand = "Mazada",
                    Capacity = "6",
                    Tipo = "Car",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new MiniBus
                {
                    Id = 3,
                    IdCompany = 1,
                    Brand = "Isuzu",
                    Capacity = "7",
                    Tipo = "Bus",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new MiniBus
                {
                    Id = 4,
                    IdCompany = 1,
                    Brand = "Ford",
                    Capacity = "8",
                    Tipo = "Tri",
                    InsertionDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                }
         );
        }

    }
}
