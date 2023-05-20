using AutoMapper;
using MiniBusManagement.Domain.Models;
using MiniBusManagement.Models.Dto;

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
