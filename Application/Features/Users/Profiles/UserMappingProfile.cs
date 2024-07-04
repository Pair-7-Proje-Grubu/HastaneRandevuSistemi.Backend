using AutoMapper;
using Domain.Entities;
using Application.Features.Users.Commands.Update;

namespace Application.Features.Users.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Patient, ChangePhoneNumberResponse>()
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Telefon numarası başarıyla güncellendi"));
        }
    }
}