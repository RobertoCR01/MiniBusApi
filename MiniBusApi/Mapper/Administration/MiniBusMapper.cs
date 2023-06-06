using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Domain.Models.Administration;

namespace MiniBusManagement.Api.Mapper.Administration;

public class MiniBusMapper
{
    CompanyMapper companyMapper = new CompanyMapper();
    public MiniBus MinibusDtoToMiniBus(MiniBusDTO miniBusDTO)
    {
        if (miniBusDTO != null)
        {
            return new MiniBus
            {
                Id = miniBusDTO.Id,
                Company = companyMapper.CompanyDtoToCompany(miniBusDTO.Company),
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
                Company = companyMapper.CompanyToCompanyDto(miniBus.Company),
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
