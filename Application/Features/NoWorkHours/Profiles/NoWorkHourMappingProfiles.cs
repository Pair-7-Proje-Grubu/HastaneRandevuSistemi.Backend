using Application.Features.NoWorkHours.Commands.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Profiles
{
    public class NoWorkHourMappingProfiles : Profile
    {
        public NoWorkHourMappingProfiles()
        {
            CreateMap<NoWorkHour, CreateNoWorkHourCommand>().ReverseMap();
            CreateMap<NoWorkHour, CreateNoWorkHourResponse>().ReverseMap();
        }
    }
}
