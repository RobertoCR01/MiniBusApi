using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBusManagement.Repositories.Entities.Administration
{
    [Table("Minibuses")]
    public class MiniBusDBEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[ForeignKey("CompanyId")]
        //public CompanyDBEntity? Company { get; set; }
        public int ? CompanyId { get; set; }
        public string? Brand { get; set; }
        public string? Plate { get; set; }
        public string? Tipo { get; set; }
        public int Year { get; set; }
        public int Capacity { get; set; }
        public string? UserInsert { get; set; }
        public DateTime? InsertionDate { get; set; }
        public string? UserModifies { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
