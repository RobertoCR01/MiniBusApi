using MiniBusManagement.Domain.Models.Administration;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace MiniBusManagement.Api.Models.Administration
{
    public class RolDTO
    {
        public int Id { get; set; }
        public Company? Company { get; set; }
        public ICollection<UserDTO>? Users { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? UserInsert { get; set; }
        public DateTime? InsertionDate { get; set; }
        public string? UserModifies { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
