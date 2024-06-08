using Application.Features.Titles.Commands.Create;
using Application.Features.Titles.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Profiles
{
    public class TitleMappingProfile : Profile
    {
        public TitleMappingProfile() 
        {
            CreateMap<Title, CreateTitleCommand>().ReverseMap();
            CreateMap<Title, UpdateTitleCommand>().ReverseMap();
        }

    }
}
