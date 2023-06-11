using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusManagement.Repositories.Entities.Administration
{
    [Table("Users")]
    public class UserDBEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("ConpanyId")]
        public CompanyDBEntity? Company { get; set; }
        [Column("RolId")]
        public ICollection<RolDBEntity>? Roles { get; set; }
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
