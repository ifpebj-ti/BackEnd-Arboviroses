using arbovirose.Domain.Entities;
using arbovirose.WebApi.Responsemodels.User;
using AutoMapper;

namespace arbovirose.WebApi.Responsemodels.Profiles.User
{
    public class GetAllUsersProfile : Profile
    {
        public GetAllUsersProfile()
        {
            CreateMap<UserEntity, GetAllUserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.value))
                .ForMember(dest => dest.UniqueCode, opt => opt.MapFrom(src => src.UniqueCode.value))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                .ForPath(dest => dest.Profile.Office, opt => opt.MapFrom(src => src.Profile.Office.value))
                .ForPath(dest => dest.Profile.Id, opt => opt.MapFrom(src => src.Profile.Id));
        }
    }
}
