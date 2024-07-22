using Application.Features.Allergies.Commands.Create;
using Application.Features.Allergies.Commands.Update;
using Application.Features.Allergies.Queries.GetByIdAllergy;
using Application.Features.Allergies.Queries.GetListAllergy;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Allergies.Profiles
{
    public class AllergyMappingProfile : Profile
    {
        public AllergyMappingProfile()
        {
            CreateMap<Allergy, CreateAllergyCommand>().ReverseMap();
            CreateMap<Allergy, CreateAllergyResponse>().ReverseMap();
            CreateMap<Allergy, UpdateAllergyCommand>().ReverseMap();
            CreateMap<Allergy, UpdateAllergyResponse>().ReverseMap();
            CreateMap<Allergy, GetListAllergyResponse>().ReverseMap();
            CreateMap<Allergy, GetByIdAllergyResponse>().ReverseMap();


        }
    }
}
