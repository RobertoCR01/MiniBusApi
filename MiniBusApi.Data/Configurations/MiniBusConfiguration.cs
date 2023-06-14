using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBusManagement.Repositories.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusManagement.Data.Configurations
{
    internal class MiniBusConfiguration : IEntityTypeConfiguration<MiniBusDBEntity>
    {
        public void Configure(EntityTypeBuilder<MiniBusDBEntity> builder)
        {
            builder.HasOne(o => o.Company)
            .WithMany(c => c.Minibuses)
            .HasForeignKey(o => o.CompanyId);


            builder.HasData(
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
                     CompanyId = 1,
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
