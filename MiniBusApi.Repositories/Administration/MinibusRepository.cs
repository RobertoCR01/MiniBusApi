
using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Repositories.Data;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repository.Maps.Administration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq.Expressions;

namespace MiniBusManagement.Repositories.Administration
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

        public async Task<int> DeleteMinibus(int minibusID)
        {
            try {
                MiniBusDBEntity? miniBus = _db.Minibuses.FirstOrDefault(u => u.Id == minibusID);
                if (miniBus == null)
                {
                    return 404;
                } else
                { 
                    _db.Minibuses.Remove(miniBus);
                    _db.SaveChanges();
                    MiniBus miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);
                    return 204;
                }
            } catch (Exception)
            {
                return 500;
            }
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<MiniBus>> GetMinibus()
        {
            try
            {
                var minibuses = _db.Minibuses.ToList();
                List<MiniBus> minBusDomain = new();
                foreach (MiniBusDBEntity minibus in minibuses)
                {
                    minBusDomain.Add(_mapper.MinibusToMiniBusDomain(minibus));
                }
                return minBusDomain;
            } catch (Exception)
            {
                return new List<MiniBus>();
            }
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

        public async Task<int> InsertMinibus(MiniBus minibusDomainInsert)
        {
            try
            {
                MiniBusDBEntity miniBus = _mapper.MinibusDomainToMiniBus(minibusDomainInsert);
                _db.Minibuses.Add(miniBus);
                _db.SaveChanges();
                MiniBus miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);
                return 201;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        void IMiniBusRepository.Save()
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateMinibus(MiniBus minibusDomainUpdate)
        {
            try
            {
                MiniBusDBEntity miniBus = _mapper.MinibusDomainToMiniBus(minibusDomainUpdate);
                if (miniBus.Id == 0)
                {
                    return 400;
                }
                _db.Minibuses.Update(miniBus);
                _db.SaveChanges();
                MiniBus miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);
                return 204;
            } catch (Exception)
            {
                return 500;
            }
        }
    }
}
