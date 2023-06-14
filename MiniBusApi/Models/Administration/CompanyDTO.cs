using MiniBusManagement.Repositories.Entities.Administration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBusManagement.Api.Models.Administration
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public ICollection<MiniBusDTO>? Minibuses { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? ContactName { get; set; }
        [Required]
        public string? ContactNumber { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? UserInsert { get; set; }
        [Required]
        public DateTime? InsertionDate { get; set; }
        [Required]
        public string? UserModifies { get; set; }
        [Required]
        public DateTime? ModificationDate { get; set; }
    }
}

