using Application.Features.Patients.Commands.Update;
using Application.Features.Patients.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Patients.MappingProfiles
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, GetListPatientQuery>().ReverseMap();
            CreateMap<Patient, GetListPatientResponse>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientResponse>().ReverseMap();
        }
    }
}
