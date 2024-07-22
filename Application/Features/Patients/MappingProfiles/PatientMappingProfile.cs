using Application.Features.Patients.Commands.Update;
using Application.Features.Patients.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
