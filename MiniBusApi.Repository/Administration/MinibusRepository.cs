
using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Repository.Data;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repository.Maps.Administration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiniBusManagement.Repository.Administration
{
    public class MinibusRepository : IMiniBusRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;
        private readonly MiniBusMapper _mapper;
        public MinibusRepository(ApplicationDbContext context)
        {
            _db = context;
            _mapper = new MiniBusMapper();
        }

        public async Task<MiniBus> DeleteMinibus(int minibusID)
        {

            MiniBusDBEntity? miniBus = _db.Minibuses.FirstOrDefault(u => u.Id == minibusID);
            if (miniBus == null)
            {
                MiniBus miniBusDomain  = new();
                return miniBusDomain;
            } else
            {
                _db.Minibuses.Remove(miniBus);
                _db.SaveChanges();
                MiniBus miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);
                return miniBusDomain;
            }

        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<MiniBus>> GetMinibus()
        {
            var minibuses = _db.Minibuses.ToList();
            List<MiniBus> minBusDomain = new();
            foreach (MiniBusDBEntity minibus in minibuses)
            {
               minBusDomain.Add(_mapper.MinibusToMiniBusDomain(minibus));
            }
            return minBusDomain;
        }


        public async Task<MiniBus> GetMinibusByID(int minibusID)
        {
            MiniBusDBEntity? miniBus = await _db.Minibuses.AsNoTracking().FirstOrDefaultAsync(m => m.Id == minibusID);
            if (miniBus == null)
            {
                MiniBus minBusDomain = new();
                return minBusDomain;
            } else
            {
                MiniBus miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);
                return miniBusDomain;
            }
        }

        public async Task<MiniBus> InsertMinibus(MiniBus minibusDomainInsert)
        {
            MiniBusDBEntity miniBus = _mapper.MinibusDomainToMiniBus(minibusDomainInsert);
            _db.Minibuses.Add(miniBus);
            _db.SaveChanges();
            MiniBus miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);
            return miniBusDomain;
        }

        void IMiniBusRepository.Save()
        {
            throw new NotImplementedException();
        }

        public async Task<MiniBus> UpdateMinibus(MiniBus minibusDomainUpdate)
        {
            MiniBusDBEntity miniBus = _mapper.MinibusDomainToMiniBus(minibusDomainUpdate);
            _db.Minibuses.Update(miniBus);
            _db.SaveChanges();
            MiniBus miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);
            return miniBusDomain;
        }
    }
}
