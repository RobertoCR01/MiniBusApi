using MiniBusManagement.Domain.Models.Administration;


namespace MiniBusManagement.Repository.Administration
{
    public interface IMiniBusRepository : IDisposable
    {
        Task<IEnumerable<MiniBusDomain>> GetMinibus();
        Task<MiniBusDomain> GetMinibusByID(int minibusID);
        Task<MiniBusDomain> InsertMinibus(MiniBusDomain minibus);
        Task<MiniBusDomain> DeleteMinibus(int minibusID);
        Task<MiniBusDomain> UpdateMinibus(MiniBusDomain minibus);
        void Save();
    }
}
