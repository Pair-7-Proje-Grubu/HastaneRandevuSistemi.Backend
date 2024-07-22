using Application.Features.Floors.Commands.Create;
using Application.Features.Floors.Commands.Update;
using Application.Features.Floors.Queries.GetById;
using Application.Features.Floors.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Floors.MappingProfiles
{
    public class FloorMappingProfiles : Profile
    {
        public FloorMappingProfiles()
        {
            CreateMap<Floor, CreateFloorCommand>().ReverseMap();
            CreateMap<Floor, GetListFloorResponse>().ReverseMap();
            CreateMap<Floor, GetByIdFloorResponse>().ReverseMap();
            CreateMap<Floor, UpdateFloorResponse>().ReverseMap();
            CreateMap<Floor, UpdateFloorCommand>().ReverseMap();
            CreateMap<Floor, CreateFloorResponse>().ReverseMap();
        }
    }
}
