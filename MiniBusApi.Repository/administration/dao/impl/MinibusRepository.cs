using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniBusApi.Domain.Models;
using MiniBusApi.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusApi.Repository.administration.dao.impl
{
    public class MinibusRepository : IMiniBusRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;
        public MinibusRepository(ApplicationDbContext context)
        {
            this._db = context;
        }
        public async Task<MiniBus> DeleteMinibus(int minibusID)
        {
            var miniBus = _db.Minibuses.FirstOrDefault(u => u.Id == minibusID);
            _db.Minibuses.Remove(miniBus);
            _db.SaveChanges();
            return miniBus;
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MiniBus>> GetMinibus()
        {
            throw new NotImplementedException();
        }


        public async Task<MiniBus> GetMinibusByID(int minibusID)
        {
            var miniBus = await _db.Minibuses.SingleOrDefaultAsync(m => m.Id == minibusID);
            return miniBus;
        }

        public async Task<MiniBus> InsertMinibus(MiniBus minibus)
        {
            _db.Minibuses.Add(minibus);
            _db.SaveChanges();
            return minibus;
        }

        void IMiniBusRepository.Save()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<MiniBus>> UpdateMinibus(int minibusID, MiniBus minibus)
        {
            throw new NotImplementedException();
        }
    }
}
