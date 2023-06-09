
using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Entities.Administration;
using AutoMapper;

namespace MiniBusManagement.Repositories.Data.Administration
{
    public class MinibusRepository : IMiniBusRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public MinibusRepository(ApplicationDbContext context , IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public async Task<int> DeleteMinibus(int minibusID)
        {
            try
            {
                MiniBusDBEntity? miniBus = _db.Minibuses.FirstOrDefault(u => u.Id == minibusID);
                if (miniBus == null)
                {
                    return 404;
                }
                else
                {
                    _db.Minibuses.Remove(miniBus);
                    _db.SaveChanges();
                    MiniBus miniBusDomain = _mapper.Map<MiniBus>(miniBus);
                    return 204;
                }
            }
            catch (Exception)
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
                var minibuses = _db.Minibuses.Include(p => p.Company).ToList();
                List<MiniBus> minBusDomain = new();
                foreach (MiniBusDBEntity minibusList in minibuses)
                {
                    minBusDomain.Add(_mapper.Map<MiniBus>(minibusList));
                }
                return minBusDomain;
            }
            catch (Exception)
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
            }
            else
            {
                CompanyDBEntity? company = await _db.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == miniBus.Id);
                if (company != null)
                {
                    miniBus.Company = company;  
                }
                MiniBus miniBusDomain = _mapper.Map<MiniBus>(miniBus);
                return miniBusDomain;
            }
        }

        public async Task<int> InsertMinibus(MiniBus minibusDomainInsert)
        {
            try
            {
                MiniBusDBEntity miniBusDB = _mapper.Map<MiniBusDBEntity>(minibusDomainInsert);
                _db.Minibuses.Add(miniBusDB);
                _db.SaveChanges();
                MiniBus miniBusDomain = _mapper.Map<MiniBus>(miniBusDB);
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
                MiniBusDBEntity miniBusDB = _mapper.Map<MiniBusDBEntity>(minibusDomainUpdate);
                if (miniBusDB.Id == 0)
                {
                    return 400;
                }
                _db.Minibuses.Update(miniBusDB);
                _db.SaveChanges();
                MiniBus miniBusDomain = _mapper.Map<MiniBus>(miniBusDB);
                return 204;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
