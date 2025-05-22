using AutoMapper;
using MakersApiWeb.App.DTOs;
using MakersApiWeb.App.Handlers.UserHandler.Params;
using MakersApiWeb.Domain.Entities;

namespace MakersApiWeb.Infraestructure.AutoMapper.EntityMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserInsCommand, User>()
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}
