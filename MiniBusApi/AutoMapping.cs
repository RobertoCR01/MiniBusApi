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
            CreateMap<MiniBus, MiniBusDTO>()
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Placa));
            CreateMap<MiniBusDTO, MiniBus>()
                .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.Plate));
            CreateMap<MiniBus, MiniBusDBEntity>()
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Placa));
            CreateMap<MiniBusDBEntity, MiniBus>()
                .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.Plate));
            //Compamy
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
            CreateMap<Company, CompanyDBEntity>();
            CreateMap<CompanyDBEntity, Company>();
            //Users
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDBEntity>();
            CreateMap<UserDBEntity, User>();
            //Roles
            CreateMap<Rol, RolDTO>();
            CreateMap<RolDTO, Rol>();
            CreateMap<Rol, RolDBEntity>();
            CreateMap<RolDBEntity, Rol>();

        }

    }
}