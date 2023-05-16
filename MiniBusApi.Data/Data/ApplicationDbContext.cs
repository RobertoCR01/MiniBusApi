using Microsoft.EntityFrameworkCore;
using MiniBusApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusApi.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base (options)
        { 
        
        }
        public DbSet<MiniBus> Minibuses { get; set; }

    }
}
