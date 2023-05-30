using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBusManagement.Domain.Models.Administration
{
    public class MiniBus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdCompany { get; set; }
        public string? Brand { get; set; } 
        public string? Tipo { get; set; }
        public int Year { get; set; }
        public string? Capacity { get; set; }
        public string? UserInsert { get; set; }
        public DateTime? InsertionDate { get; set; }
        public string? UserModifies { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
