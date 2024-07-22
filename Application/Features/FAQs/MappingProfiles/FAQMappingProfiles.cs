using Application.Features.FAQs.Command.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.FAQs.MappingProfiles
{
    public class FAQMappingProfiles : Profile
    {
        public FAQMappingProfiles() 
        {
            CreateMap<FAQ, CreateFAQCommand>().ReverseMap();
            CreateMap<FAQ, CreateFAQResponse>().ReverseMap();
        }
    }
}
