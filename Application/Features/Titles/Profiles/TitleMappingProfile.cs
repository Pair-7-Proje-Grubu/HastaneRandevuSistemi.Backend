using Application.Features.Titles.Commands.Create;
using Application.Features.Titles.Commands.Update;
using Application.Features.Titles.Queries.GetByIdTitle;
using Application.Features.Titles.Queries.GetListTitle;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Titles.Profiles
{
    public class TitleMappingProfile : Profile
    {
        public TitleMappingProfile() 
        {
            CreateMap<Title, CreateTitleCommand>().ReverseMap();
            CreateMap<Title, CreateTitleResponse>().ReverseMap();
            CreateMap<Title, UpdateTitleCommand>().ReverseMap();
            CreateMap<Title, UpdateTitleResponse>().ReverseMap();
            CreateMap<Title, GetListTitleResponse>().ReverseMap();
            CreateMap<Title, GetByIdTitleResponse>().ReverseMap();
        }

    }
}
