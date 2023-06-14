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
    public class CompanyConfiguration : IEntityTypeConfiguration<CompanyDBEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyDBEntity> builder)
        {
        builder.HasData(
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
        }
    }
}
