using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBusManagement.Domain.Models;

namespace MiniBusManagement.Service.administration.services
{
    public interface IMiniBusService
    {
        Task<IEnumerable<MiniBus>> GetMinibus(String loggedUser, DateTime currentDate);
        Task<MiniBus> GetMiniBusByID(int minibusID, String loggedUser, DateTime currentDate);
        Task<MiniBus> InsertMinibus(MiniBus minibus, String loggedUser, DateTime currentDate);
        Task<MiniBus> DeleteMinibus(int minibusID, String loggedUser, DateTime currentDate);
        Task<MiniBus> UpdateMinibus(int minibusID, MiniBus minibus, String loggedUser, DateTime currentDate);
        void Save();
    }
}
