﻿using MiniBusManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MiniBusManagement.Repository.administration.dao
{
    public interface IMiniBusRepository : IDisposable
    {
        Task<IEnumerable<MiniBus>> GetMinibus();
        Task<MiniBus> GetMinibusByID(int minibusID);
        Task<MiniBus> InsertMinibus(MiniBus minibus);
        Task<MiniBus> DeleteMinibus(int minibusID);
        Task<MiniBus> UpdateMinibus(MiniBus minibus);
        void Save();
    }
}
