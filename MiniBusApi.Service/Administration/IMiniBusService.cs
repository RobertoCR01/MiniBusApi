using MiniBusManagement.Domain.Models.Administration;

namespace MiniBusManagement.Service.Administration
{
    public interface IMiniBusService
    {
        Task<IEnumerable<MiniBusDomain>> GetMinibus(string loggedUser, DateTime currentDate);
        Task<MiniBusDomain> GetMiniBusByID(int minibusID, string loggedUser, DateTime currentDate);
        Task<MiniBusDomain> InsertMinibus(MiniBusDomain minibus, string loggedUser, DateTime currentDate);
        Task<MiniBusDomain> DeleteMinibus(int minibusID, string loggedUser, DateTime currentDate);
        Task<MiniBusDomain> UpdateMinibus(int minibusID, MiniBusDomain minibus, string loggedUser, DateTime currentDate);
    }
}
