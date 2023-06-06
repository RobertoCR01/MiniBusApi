using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusManagement.Domain.Models.Administration
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public Company? companyId { get; set; }
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