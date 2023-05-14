using MiniBusApi.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusApi.Data.Data
{
    public static class MiniBusStore
    {
        public static List<MiniBusDTO> miniBusLista = new List<MiniBusDTO>
        {
            new MiniBusDTO { Id = 1,IdCompany= 1,Brand = "Toyota",Capacity = "3", Tipo="Van"},
            new MiniBusDTO { Id = 2,IdCompany= 1,Brand = "Mazada",Capacity = "6", Tipo="Car"},
            new MiniBusDTO { Id = 3,IdCompany= 1,Brand = "Isuzu",Capacity = "7", Tipo="Bus"},
            new MiniBusDTO { Id = 4,IdCompany= 1,Brand = "Ford",Capacity = "8", Tipo="Tri"}
        };
    }
}
