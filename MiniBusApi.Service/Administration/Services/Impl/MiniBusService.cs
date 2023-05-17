using Microsoft.AspNetCore.Mvc;
using MiniBusApi.Domain.Models;
using MiniBusApi.Repository.administration.dao;
using MiniBusApi.Service.administration.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusApi.Service.administration.services.impl
{
    public class MiniBusService : IMiniBusService
    {
        private IMiniBusRepository _miniBusRepository;

        public MiniBusService(IMiniBusRepository miniBusRepository)
        {
            this._miniBusRepository = miniBusRepository;
        }
        public async Task<MiniBus> DeleteMinibus(int minibusID, string loggedUser, DateTime currentDate)
        {
            MiniBus miniBus = await _miniBusRepository.DeleteMinibus(minibusID);
            return miniBus;
        }

        public async Task<IEnumerable<MiniBus>> GetMinibus(string loggedUser, DateTime currentDate)
        {
            throw new NotImplementedException();
        }

        public async Task<MiniBus> GetMiniBusByID(int minibusID, string loggedUser, DateTime currentDate)
        {
            MiniBus minibus = await _miniBusRepository.GetMinibusByID(minibusID);
            return minibus;
        }

        public async Task<MiniBus> InsertMinibus(MiniBus minibusProcesar, string loggedUser, DateTime currentDate)
        {
            minibusProcesar.InsertionDate = currentDate;
            minibusProcesar.ModificationDate = currentDate;
            minibusProcesar.UserInsert = loggedUser;
            minibusProcesar.UserModifies = loggedUser;
            MiniBus minibus = await _miniBusRepository.InsertMinibus(minibusProcesar);
            return minibus;
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

