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
            CreateMap<MiniBus, MiniBusDTO>();
            CreateMap<MiniBusDTO, MiniBus>();
            CreateMap<MiniBus, MiniBusDBEntity>();
            CreateMap<MiniBusDBEntity, MiniBus>();
        }

    }
}