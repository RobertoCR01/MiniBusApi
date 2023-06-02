using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Domain.Models.Administration;

namespace MiniBusManagement.Api.Mapper;

public class MiniBusMapper
{
    public  MiniBus MinibusDtoToMiniBus(MiniBusDTO miniBusDTO)
    {
        if (miniBusDTO != null)
        {
            return new MiniBus
            {
                Id = miniBusDTO.Id,
                IdCompany = miniBusDTO.IdCompany,
                Brand = miniBusDTO.Brand,
                Plate = miniBusDTO.Plate,
                Tipo = miniBusDTO.Tipo,
                Year = miniBusDTO.Year,
                Capacity = miniBusDTO.Capacity,
                UserInsert = miniBusDTO.UserInsert,
                InsertionDate = miniBusDTO.InsertionDate,
                UserModifies = miniBusDTO.UserModifies,
                ModificationDate = miniBusDTO.ModificationDate
            };
        }

        return new MiniBus();
    }
    public MiniBusDTO MinibusToMiniBusDto(MiniBus miniBus)
    {
        if (miniBus != null)
        {
            return new MiniBusDTO
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

        return new MiniBusDTO();
    }
}
