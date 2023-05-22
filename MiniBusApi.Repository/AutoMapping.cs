using AutoMapper;
using MiniBusManagement.Repository.Administration;
using MiniBusManagement.Domain.Models.Administration;

namespace MiniBusManagement.Repository
{
    public class AutoMapping : Profile
        {
            public AutoMapping()
            {
                CreateMap<MiniBus, MiniBusDBEntity>();
                CreateMap<MiniBusDBEntity, MiniBus>();

        }
        }
}
