using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBusApi.Domain.Models;

namespace MiniBusApi.Service.administration.services
{
    public interface IMiniBusService
    {
        Task<IEnumerable<MiniBus>> GetMinibus(String loggedUser, DateTime currentDate);
        Task<MiniBus> GetMiniBusByID(int minibusID, String loggedUser, DateTime currentDate);
        Task<MiniBus> InsertMinibus(MiniBus minibus, String loggedUser, DateTime currentDate);
        Task<MiniBus> DeleteMinibus(int minibusID, String loggedUser, DateTime currentDate);
        Task<ActionResult<MiniBus>> UpdateMinibus(int minibusID, MiniBus minibus, String loggedUser, DateTime currentDate);
        void Save();
    }
}
