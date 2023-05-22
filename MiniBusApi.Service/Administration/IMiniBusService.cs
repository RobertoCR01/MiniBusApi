using MiniBusManagement.Domain.Models.Administration;

namespace MiniBusManagement.Service.Administration
{
    public interface IMiniBusService
    {
        Task<IEnumerable<MiniBus>> GetMinibus(string loggedUser, DateTime currentDate);
        Task<MiniBus> GetMiniBusByID(int minibusID, string loggedUser, DateTime currentDate);
        Task<int> InsertMinibus(MiniBus minibus, string loggedUser, DateTime currentDate);
        Task<int> DeleteMinibus(int minibusID, string loggedUser, DateTime currentDate);
        Task<int> UpdateMinibus(int minibusID, MiniBus minibus, string loggedUser, DateTime currentDate);
    }
}
