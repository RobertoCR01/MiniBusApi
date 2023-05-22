using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBusManagement.Repository.Administration
{
    public class MiniBusDBEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdCompany { get; set; }
        public string Brand { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public int Year { get; set; }
        public string Capacity { get; set; } = null!;
        public string? UserInsert { get; set; }
        public DateTime? InsertionDate { get; set; }
        public string? UserModifies { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
