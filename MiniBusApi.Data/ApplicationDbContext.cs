using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Data.Configurations;
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

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new MiniBusConfiguration());

        }
    }
}
