using AutoMapper;
using MiniBusApi.Domain.Models;
using MiniBusApi.Models.Dto;

namespace MiniBusApi
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
