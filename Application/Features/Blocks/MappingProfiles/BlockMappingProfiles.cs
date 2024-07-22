using Application.Features.Blocks.Commands.Create;
using Application.Features.Blocks.Commands.Update;
using Application.Features.Blocks.Queries.GetById;
using Application.Features.Blocks.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Blocks.MappingProfiles
{
    public class BlockMappingProfiles: Profile
    {
        public BlockMappingProfiles()
        {
            CreateMap<Block, CreateBlockCommand>().ReverseMap();
            CreateMap<Block, GetListBlockResponse>().ReverseMap();
            CreateMap<Block, GetByIdBlockResponse>().ReverseMap();
            CreateMap<Block, UpdateBlockResponse>().ReverseMap();
            CreateMap<Block, UpdateBlockCommand>().ReverseMap();
            CreateMap<Block, CreateBlockResponse>().ReverseMap();
        }
    }
}
