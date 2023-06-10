using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusManagement.Domain.Models.Administration
{
    public class User
    {
        public int Id { get; set; }
        public Company? Company { get; set; }
        public ICollection<Rol>? Roles { get; set; }
        public string login { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserPhone { get; set; } = string.Empty;
        public string? UserInsert { get; set; }
        public DateTime? InsertionDate { get; set; }
        public string? UserModifies { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
