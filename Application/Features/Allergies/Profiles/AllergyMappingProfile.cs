using Application.Features.Allergies.Commands.Create;
using Application.Features.Allergies.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Allergies.Profiles
{
    public class AllergyMappingProfile : Profile
    {
        public AllergyMappingProfile()
        {
            CreateMap<Allergy, CreateAllergyCommand>().ReverseMap();
            CreateMap<Allergy, UpdateAllergyCommand>().ReverseMap();


        }
    }
}
