using MiniBusManagement.Domain.Models.Administration;


namespace MiniBusManagement.Repository.Administration
{
    public interface IMiniBusRepository : IDisposable
    {
        Task<IEnumerable<MiniBus>> GetMinibus();
        Task<MiniBus> GetMinibusByID(int minibusID);
        Task<MiniBus> InsertMinibus(MiniBus minibus);
        Task<MiniBus> DeleteMinibus(int minibusID);
        Task<MiniBus> UpdateMinibus(MiniBus minibus);
        void Save();
    }
}
