using AutoMapper;
using MakersApiWeb.App.DTOs;
using MakersApiWeb.Domain.Entities;

namespace MakersApiWeb.Infraestructure.AutoMapper.EntityMapper
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanDto>()
                        .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FullName))
                        .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.RequestedDate));

            CreateMap<LoanDto, Loan>();
        }
    }
}
