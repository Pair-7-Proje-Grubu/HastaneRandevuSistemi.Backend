using Application.Features.Clinics.Commands.Create;
using Application.Features.Clinics.Commands.Update;
using Application.Features.Clinics.Queries.GetByIdClinic;
using Application.Features.Clinics.Queries.GetListClinic;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CreateMap<Clinic, GetListClinicResponse>().ReverseMap();
            CreateMap<Clinic, GetByIdClinicResponse>().ReverseMap();
        
        }
    }
}
