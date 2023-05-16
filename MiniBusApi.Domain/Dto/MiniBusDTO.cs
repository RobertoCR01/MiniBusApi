using System.ComponentModel.DataAnnotations;

namespace MiniBusApi.Domain.Dto
{
    public class MiniBusDTO
    {
        public int Id { get; set; }
        public int IdCompany { get; set; }

        [Required]
        [MaxLength(10)]
        public string Brand { get; set; }
        public string Tipo { get; set; }
        public int Year { get; set; }
        public string Capacity { get; set; }
        public string? UserInsert { get; set; }
        public DateTime? InsertionDate { get; set; }
        public string? UserModifies { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
