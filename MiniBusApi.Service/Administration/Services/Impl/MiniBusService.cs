using Microsoft.AspNetCore.Mvc;
using MiniBusApi.Domain.Models;
using MiniBusApi.Repository.administration.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusApi.Service.Administration.Services.Impl
{
    public class MiniBusService : IMiniBusService
        {
        private IMiniBusRepository _miniBusRepository;

        public MiniBusService(IMiniBusRepository miniBusRepository)
        {
            this._miniBusRepository = miniBusRepository;
        }
        public async Task<ActionResult<MiniBus>> DeleteMinibus(int minibusID, string loggedUser, DateTime currentDate)
            {
                throw new NotImplementedException();
            }

            public async Task<IEnumerable<MiniBus>> GetMinibus(string loggedUser, DateTime currentDate)
            {
                throw new NotImplementedException();
            }

            public async Task<ActionResult<MiniBus>> GetMiniBusByID(int minibusID, string loggedUser, DateTime currentDate)
            {
                MiniBus minibus = await _miniBusRepository.GetMinibusByID(minibusID);
                return minibus;
            }

            public async Task<MiniBus> InsertMinibus(MiniBus minibusProcesar, string loggedUser, DateTime currentDate)
            {
                throw new NotImplementedException();
            }

            void IMiniBusService.Save()
            {
                throw new NotImplementedException();
            }

            public async Task<ActionResult<MiniBus>> UpdateMinibus(int minibusID, MiniBus minibus, string loggedUser, DateTime currentDate)
            {
                throw new NotImplementedException();
            }
        }
    }

