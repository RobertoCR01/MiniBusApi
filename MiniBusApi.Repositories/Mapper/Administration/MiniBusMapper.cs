using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Administration;

namespace MiniBusManagement.Repository.Maps.Administration
{
    public class MiniBusMapper
    {
        public  MiniBus MinibusToMiniBusDomain(MiniBusDBEntity miniBus)
        {
            if (miniBus != null)
            {
                return new MiniBus
                {
                    Id = miniBus.Id,
                    IdCompany = miniBus.IdCompany,
                    Brand = miniBus.Brand,
                    Plate = miniBus.Plate,
                    Tipo = miniBus.Tipo,
                    Year = miniBus.Year,
                    Capacity = miniBus.Capacity,
                    UserInsert = miniBus.UserInsert,
                    InsertionDate = miniBus.InsertionDate,
                    UserModifies = miniBus.UserModifies,
                    ModificationDate = miniBus.ModificationDate
                };
            }

            return new MiniBus();
        }
        public MiniBusDBEntity MinibusDomainToMiniBus(MiniBus miniBusDomain)
        {
            if (miniBusDomain != null)
            {
                return new MiniBusDBEntity
                {
                    Id = miniBusDomain.Id,
                    IdCompany = miniBusDomain.IdCompany,
                    Brand = miniBusDomain.Brand,
                    Plate = miniBusDomain.Plate,
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
