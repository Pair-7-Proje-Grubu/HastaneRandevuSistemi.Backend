using Application.Features.FAQs.Command.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
