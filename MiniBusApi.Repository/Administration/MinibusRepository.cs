﻿
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
        public async Task<MiniBusDomain> DeleteMinibus(int minibusID)
        {
            
            MiniBus miniBus = _db.Minibuses.FirstOrDefault(u => u.Id == minibusID);
            _db.Minibuses.Remove(miniBus);
            _db.SaveChanges();
            MiniBusDomain miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);

            return miniBusDomain;
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MiniBusDomain>> GetMinibus()
        {
            var minibuses = _db.Minibuses.ToList();
            List<MiniBusDomain> minBusDomain = new List<MiniBusDomain>();
            foreach (MiniBus minibus in minibuses)
            {
               minBusDomain.Add(_mapper.MinibusToMiniBusDomain(minibus));
            }
            return minBusDomain;
        }


        public async Task<MiniBusDomain> GetMinibusByID(int minibusID)
        {
            MiniBus miniBus = await  _db.Minibuses.AsNoTracking().FirstOrDefaultAsync(m => m.Id == minibusID);
            MiniBusDomain miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);
            return miniBusDomain;
        }

        public async Task<MiniBusDomain> InsertMinibus(MiniBusDomain minibusDomainInsert)
        {
            MiniBus miniBus = _mapper.MinibusDomainToMiniBus(minibusDomainInsert);
            _db.Minibuses.Add(miniBus);
            _db.SaveChanges();
            MiniBusDomain miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);
            return miniBusDomain;
        }

        void IMiniBusRepository.Save()
        {
            throw new NotImplementedException();
        }

        public async Task<MiniBusDomain> UpdateMinibus(MiniBusDomain minibusDomainUpdate)
        {
            MiniBus miniBus = _mapper.MinibusDomainToMiniBus(minibusDomainUpdate);
            _db.Minibuses.Update(miniBus);
            _db.SaveChanges();
            MiniBusDomain miniBusDomain = _mapper.MinibusToMiniBusDomain(miniBus);
            return miniBusDomain;
        }
    }
}