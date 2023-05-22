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
        public async Task<MiniBus> DeleteMinibus(int minibusID, string loggedUser, DateTime currentDate)
        {
            MiniBus miniBus = await _miniBusRepository.DeleteMinibus(minibusID);
            return miniBus;
        }

        public async Task<IEnumerable<MiniBus>> GetMinibus(string loggedUser, DateTime currentDate)
        {
            var minibuses = await _miniBusRepository.GetMinibus();
            return minibuses;
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

        public async Task<MiniBus> UpdateMinibus(int minibusID, MiniBus minibusUpdated, string loggedUser, DateTime currentDate)
        {
            MiniBus minibusActual = await _miniBusRepository.GetMinibusByID(minibusID);
            minibusActual.IdCompany = minibusUpdated.IdCompany;
            minibusActual.Brand = minibusUpdated.Brand;
            minibusActual.Tipo = minibusUpdated.Tipo;
            minibusActual.Year = minibusUpdated.Year;
            minibusActual.Capacity = minibusUpdated.Capacity;
            minibusActual.UserModifies = loggedUser;
            minibusActual.ModificationDate = currentDate;

            MiniBus minibusProcesado = await _miniBusRepository.UpdateMinibus(minibusActual);
            return minibusProcesado;
        }
    }
}

