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
            throw new NotImplementedException();
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

        public async Task<ActionResult<MiniBus>> InsertMinibus(MiniBus minibus)
        {
            throw new NotImplementedException();
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
