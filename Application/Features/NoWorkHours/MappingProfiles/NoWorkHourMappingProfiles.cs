using Application.Features.NoWorkHours.Commands.Create;
using Application.Features.NoWorkHours.Commands.Update;
using Application.Features.NoWorkHours.Dtos;
using Application.Features.NoWorkHours.Queries.GetById;
using Application.Features.NoWorkHours.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.MappingProfiles
{
    public class NoWorkHourMappingProfiles : Profile
    {
        public NoWorkHourMappingProfiles()
        {
            CreateMap<NoWorkHour, NoWorkHourDto>().ReverseMap();
            CreateMap<NoWorkHour, CreateNoWorkHourResponse>().ReverseMap();
            CreateMap<CreateNoWorkHourCommand, List<NoWorkHour>>()
            .ConvertUsing((src, dest, context) =>
                src.NoWorkHours.Select(dto => context.Mapper.Map<NoWorkHour>(dto)).ToList());

            CreateMap<NoWorkHour, UpdateNoWorkHourCommand>().ReverseMap();
            CreateMap<NoWorkHour, UpdateNoWorkHourResponse>().ReverseMap();

            CreateMap<NoWorkHour, GetListNoWorkHourResponse>().ReverseMap();
            CreateMap<NoWorkHour, GetByIdNoWorkHourResponse>().ReverseMap();
        }
    }
}
