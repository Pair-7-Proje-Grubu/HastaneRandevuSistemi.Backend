using Application.Features.Clinics.Commands.Create;
using Application.Features.Clinics.Commands.Update;
using Application.Features.Clinics.Dtos;
using Application.Features.Clinics.Queries.GetByIdClinic;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Clinics.Profiles
{
    public class ClinicMappingProfile : Profile
    {

        public ClinicMappingProfile() 
        {
            CreateMap<Clinic, CreateClinicCommand>().ReverseMap();
            CreateMap<Clinic, CreateClinicResponse>().ReverseMap();
            CreateMap<Clinic, UpdateClinicCommand>().ReverseMap();
            CreateMap<Clinic, UpdateClinicResponse>().ReverseMap();
            CreateMap<Clinic, GetListClinicDto>().ReverseMap();
            CreateMap<Clinic, GetClinicResponse>().ReverseMap();
            
        
        }
    }
}
