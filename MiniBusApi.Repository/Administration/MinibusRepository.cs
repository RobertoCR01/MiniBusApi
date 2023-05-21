
using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Repository.Data;
using MiniBusManagement.Domain.Models.Administration;

namespace MiniBusManagement.Repository.Administration
{
    public class MinibusRepository : IMiniBusRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;
        public MinibusRepository(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task<MiniBusDomain> DeleteMinibus(int minibusID)
        {
            MiniBusDomain miniBusDomain = new MiniBusDomain();
            MiniBus miniBus = _db.Minibuses.FirstOrDefault(u => u.Id == minibusID);
            _db.Minibuses.Remove(miniBus);
            _db.SaveChanges();
            
            return miniBusDomain;
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MiniBusDomain>> GetMinibus()
        {
            List<MiniBusDomain> minBusDomain = new List<MiniBusDomain>();

            var minibuses = _db.Minibuses.ToList();
            return minBusDomain;
        }


        public async Task<MiniBusDomain> GetMinibusByID(int minibusID)
        {
            MiniBusDomain miniBusDomain = new MiniBusDomain();
            var miniBus = await _db.Minibuses.SingleOrDefaultAsync(m => m.Id == minibusID);
            return miniBusDomain;
        }

        public async Task<MiniBusDomain> InsertMinibus(MiniBusDomain minibusDomain)
        {
            MiniBusDomain miniBusDomain = new MiniBusDomain();
            //_db.Minibuses.Add(minibus);
            //_db.SaveChanges();
            return miniBusDomain;
        }

        void IMiniBusRepository.Save()
        {
            throw new NotImplementedException();
        }

        public async Task<MiniBusDomain> UpdateMinibus(MiniBusDomain minibusDomain)
        {
            //_db.Minibuses.Update(minibus);
            //_db.SaveChanges();
            return minibusDomain;
        }
    }
}
