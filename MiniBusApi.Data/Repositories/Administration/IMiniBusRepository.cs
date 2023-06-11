using MiniBusManagement.Domain.Models.Administration;


namespace MiniBusManagement.Data.Repositories.Administration
{
    public interface IMiniBusRepository : IDisposable
    {
        Task<IEnumerable<MiniBus>> GetMinibus();
        Task<MiniBus> GetMinibusByID(int minibusID);
        Task<int> InsertMinibus(MiniBus minibus);
        Task<int> DeleteMinibus(int minibusID);
        Task<int> UpdateMinibus(MiniBus minibus);
        void Save();
    }
}
