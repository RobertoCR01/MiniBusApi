using MiniBusManagement.Domain.Models.Administration;

namespace MiniBusManagement.Api.Models.Administration
{
    public class UserDTO
    {
        public int Id { get; set; }
        public Company? Company { get; set; }
        public ICollection<RolDTO>? Roles { get; set; }
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
