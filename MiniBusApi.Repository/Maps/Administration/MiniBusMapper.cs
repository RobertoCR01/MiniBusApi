using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repository.Administration;

namespace MiniBusManagement.Repository.Maps.Administration
{
    public class MiniBusMapper
    {
        public  MiniBusDomain MinibusToMiniBusDomain(MiniBusDBEntity miniBus)
        {
            if (miniBus != null)
            {
                return new MiniBusDomain
                {
                    Id = miniBus.Id,
                    IdCompany = miniBus.IdCompany,
                    Brand = miniBus.Brand,
                    Tipo = miniBus.Tipo,
                    Year = miniBus.Year,
                    Capacity = miniBus.Capacity,
                    UserInsert = miniBus.UserInsert,
                    InsertionDate = miniBus.InsertionDate,
                    UserModifies = miniBus.UserModifies,
                    ModificationDate = miniBus.ModificationDate
                };
            }

            return new MiniBusDomain();
        }
        public MiniBusDBEntity MinibusDomainToMiniBus(MiniBusDomain miniBusDomain)
        {
            if (miniBusDomain != null)
            {
                return new MiniBusDBEntity
                {
                    Id = miniBusDomain.Id,
                    IdCompany = miniBusDomain.IdCompany,
                    Brand = miniBusDomain.Brand,
                    Tipo = miniBusDomain.Tipo,
                    Year = miniBusDomain.Year,
                    Capacity = miniBusDomain.Capacity,
                    UserInsert = miniBusDomain.UserInsert,
                    InsertionDate = miniBusDomain.InsertionDate,
                    UserModifies = miniBusDomain.UserModifies,
                    ModificationDate = miniBusDomain.ModificationDate
                };
            }

            return new MiniBusDBEntity();
        }
    }
}
