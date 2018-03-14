using AutoMapper;
using DAL;

namespace BL.Mapping
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<User, UserDto>().ForMember(m => m.NameWithPrefix, opt => opt.MapFrom(src => $"Dto_{src.Name}"));
            CreateMap<UserDto, User>().ForMember(m => m.Name, opt => opt.MapFrom(src => src.NameWithPrefix.Substring("Dto_".Length)));
        }
    }
}