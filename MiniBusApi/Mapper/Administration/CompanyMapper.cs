using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Domain.Models.Administration;

namespace MiniBusManagement.Api.Mapper.Administration
{
    public class CompanyMapper
    {
        public Company CompanyDtoToCompany(CompanyDTO companyDTO)
        {
            if (companyDTO != null)
            {
                return new Company
                {
                    ID = companyDTO.ID,
                    Name = companyDTO.Name,
                    Address = companyDTO.Address,
                    City = companyDTO.City,
                    ContactName = companyDTO.ContactName,
                    ContactNumber = companyDTO.ContactNumber,
                    Email = companyDTO.Email,
                    Phone = companyDTO.Phone
                };
            }

            return new Company();
        }
        public CompanyDTO CompanyToCompanyDto(Company company)
        {
            if (company != null)
            {
                return new CompanyDTO
                {
                    ID = company.ID,
                    Name = company.Name,
                    Address = company.Address,
                    City = company.City,
                    ContactName = company.ContactName,
                    ContactNumber = company.ContactNumber,
                    Email = company.Email,
                    Phone = company.Phone
                };
            }

            return new CompanyDTO();
        }
    }
}
