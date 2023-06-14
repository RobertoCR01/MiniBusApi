
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MiniBusManagement.Api.Models.Administration
{
    public class MiniBusDTO
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public CompanyDTO? Company { get; set; }

        [Required]
        [MaxLength(10)]
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
