using AutoMapper;
using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Entities.Administration;

namespace MiniBusManagement.Api
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //Minibus
            CreateMap<MiniBus, MiniBusDTO>();
            CreateMap<MiniBusDTO, MiniBus>();
            CreateMap<MiniBus, MiniBusDBEntity>();
            CreateMap<MiniBusDBEntity, MiniBus>();
            //Compamy
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
            CreateMap<Company, CompanyDBEntity>();
            CreateMap<CompanyDBEntity, Company>();
           
        }

    }
}