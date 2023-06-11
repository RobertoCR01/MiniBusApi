using Microsoft.AspNetCore.Mvc;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Data.Repositories.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusManagement.Services.Administration
{
    public class MiniBusService : IMiniBusService
    {
        private readonly IMiniBusRepository _miniBusRepository;

        public MiniBusService(IMiniBusRepository miniBusRepository)
        {
            _miniBusRepository = miniBusRepository;
        }
        public async Task<int> DeleteMinibus(int minibusID, string loggedUser, DateTime currentDate)
        {
            try
            {
                int result = await _miniBusRepository.DeleteMinibus(minibusID);
                return result; 
            } catch (Exception)
            {
                return 500;
            }
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
        public async Task<int> InsertMinibus(MiniBus minibusProcesar, string loggedUser, DateTime currentDate)
        {
            minibusProcesar.InsertionDate = currentDate;
            minibusProcesar.ModificationDate = currentDate;
            minibusProcesar.UserInsert = loggedUser;
            minibusProcesar.UserModifies = loggedUser;
            int result = await _miniBusRepository.InsertMinibus(minibusProcesar);
            return result;
        }
        public async Task<int> UpdateMinibus(int minibusID, MiniBus minibusUpdated, string loggedUser, DateTime currentDate)
        {
            try
            {
                MiniBus minibusActual = await _miniBusRepository.GetMinibusByID(minibusID);
                minibusActual.Brand = minibusUpdated.Brand;
                minibusActual.Tipo = minibusUpdated.Tipo;
                minibusActual.Year = minibusUpdated.Year;
                minibusActual.Capacity = minibusUpdated.Capacity;
                minibusActual.UserModifies = loggedUser;
                minibusActual.ModificationDate = currentDate;

                int result = await _miniBusRepository.UpdateMinibus(minibusActual);
                return result;
            } catch (Exception)
            {
                return 500;
            }
        }
    }
}

