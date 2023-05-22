using Microsoft.AspNetCore.Mvc;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repository.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusManagement.Service.Administration
{
    public class MiniBusService : IMiniBusService
    {
        private readonly IMiniBusRepository _miniBusRepository;

        public MiniBusService(IMiniBusRepository miniBusRepository)
        {
            _miniBusRepository = miniBusRepository;
        }
        public async Task<MiniBusDomain> DeleteMinibus(int minibusID, string loggedUser, DateTime currentDate)
        {
            MiniBusDomain miniBus = await _miniBusRepository.DeleteMinibus(minibusID);
            return miniBus;
        }

        public async Task<IEnumerable<MiniBusDomain>> GetMinibus(string loggedUser, DateTime currentDate)
        {
            var minibuses = await _miniBusRepository.GetMinibus();
            return minibuses;
        }

        public async Task<MiniBusDomain> GetMiniBusByID(int minibusID, string loggedUser, DateTime currentDate)
        {
            MiniBusDomain minibus = await _miniBusRepository.GetMinibusByID(minibusID);
            return minibus;
        }

        public async Task<MiniBusDomain> InsertMinibus(MiniBusDomain minibusProcesar, string loggedUser, DateTime currentDate)
        {
            minibusProcesar.InsertionDate = currentDate;
            minibusProcesar.ModificationDate = currentDate;
            minibusProcesar.UserInsert = loggedUser;
            minibusProcesar.UserModifies = loggedUser;
            MiniBusDomain minibus = await _miniBusRepository.InsertMinibus(minibusProcesar);
            return minibus;
        }

        public async Task<MiniBusDomain> UpdateMinibus(int minibusID, MiniBusDomain minibusUpdated, string loggedUser, DateTime currentDate)
        {
            MiniBusDomain minibusActual = await _miniBusRepository.GetMinibusByID(minibusID);
            minibusActual.IdCompany = minibusUpdated.IdCompany;
            minibusActual.Brand = minibusUpdated.Brand;
            minibusActual.Tipo = minibusUpdated.Tipo;
            minibusActual.Year = minibusUpdated.Year;
            minibusActual.Capacity = minibusUpdated.Capacity;
            minibusActual.UserModifies = loggedUser;
            minibusActual.ModificationDate = currentDate;

            MiniBusDomain minibusProcesado = await _miniBusRepository.UpdateMinibus(minibusActual);
            return minibusProcesado;
        }
    }
}

