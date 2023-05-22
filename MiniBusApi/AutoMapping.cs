using AutoMapper;
using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Domain.Models.Administration;

namespace MiniBusManagement.Api
{
    public class AutoMapping : Profile
        {
            public AutoMapping()
            {
                CreateMap<MiniBus, MiniBusDTO>();
                CreateMap<MiniBusDTO, MiniBus>();

        }
        }
}
