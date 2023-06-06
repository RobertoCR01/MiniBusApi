using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBusManagement.Repositories.Mapper.Administration
{
    internal class CompanyMapper
    {
        public Company CompanyToCompanyDomain(CompanyDBEntity company)
        {
            if (company != null)
            {
                return new Company
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

            return new Company();
        }
        public CompanyDBEntity CompanyDomainToCompany(Company company)
        {
            if (company != null)
            {
                return new CompanyDBEntity
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

            return new CompanyDBEntity();
        }
    }
}