using AutoMapper;
using MiniBusManagement.Repository.Administration;
using MiniBusManagement.Domain.Models.Administration;

namespace MiniBusManagement.Repository
{
    public class AutoMapping : Profile
        {
            public AutoMapping()
            {
                CreateMap<MiniBusDomain, MiniBus>();
                CreateMap<MiniBus, MiniBusDomain>();

        }
        }
}
