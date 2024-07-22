using Application.Features.Rooms.Commands.Create;
using Application.Features.Rooms.Commands.Update;
using Application.Features.Rooms.Queries.GetById;
using Application.Features.Rooms.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Rooms.MappingProfiles
{
    public class RoomMappingProfiles: Profile
    {
        public RoomMappingProfiles()
        {
            CreateMap<Room, CreateRoomCommand>().ReverseMap();
            CreateMap<Room, GetListRoomResponse>().ReverseMap();
            CreateMap<Room, GetByIdRoomResponse>().ReverseMap();
            CreateMap<Room, UpdateRoomResponse>().ReverseMap();
            CreateMap<Room, UpdateRoomCommand>().ReverseMap();
            CreateMap<Room, CreateRoomResponse>().ReverseMap();
        }
    }
}
