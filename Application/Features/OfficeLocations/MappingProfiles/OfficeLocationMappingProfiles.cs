using Application.Features.OfficeLocations.Commands.Create;
using Application.Features.OfficeLocations.Commands.Update;
using Application.Features.OfficeLocations.Queries.GetById;
using Application.Features.OfficeLocations.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.OfficeLocations.MappingProfiles
{
    public class OfficeLocationMappingProfiles : Profile
    {
        public OfficeLocationMappingProfiles()
        {
            CreateMap<OfficeLocation, CreateOfficeLocationCommand>().ReverseMap();
            CreateMap<OfficeLocation, GetListOfficeLocationResponse>().ReverseMap();
            CreateMap<OfficeLocation, GetByIdOfficeLocationResponse>().ReverseMap();
            CreateMap<OfficeLocation, UpdateOfficeLocationResponse>().ReverseMap();
            CreateMap<OfficeLocation, UpdateOfficeLocationCommand>().ReverseMap();
            CreateMap<OfficeLocation, CreateOfficeLocationResponse>().ReverseMap();
        }
    }
}
