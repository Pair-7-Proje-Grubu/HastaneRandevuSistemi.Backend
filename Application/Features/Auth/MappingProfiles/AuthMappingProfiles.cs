using AutoMapper;
using Application.Features.Auth.Register;
using Domain.Entities;

namespace Application.Features.Auth.MappingProfiles
{
    public class AuthMappingProfiles : Profile
    {
        public AuthMappingProfiles() 
        {
            CreateMap<Patient, RegisterCommand>().ReverseMap();
        }
    }
}
