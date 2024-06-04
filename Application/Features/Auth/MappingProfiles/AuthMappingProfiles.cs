using AutoMapper;
using Application.Features.Auth.Register;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
