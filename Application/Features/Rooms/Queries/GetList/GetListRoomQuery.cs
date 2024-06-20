using Application.Features.Blocks.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rooms.Queries.GetList
{
    public class GetListRoomQuery : IRequest<List<GetListRoomResponse>>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Admin"];

        public class GetListRoomQueryHandler : IRequestHandler<GetListRoomQuery, List<GetListRoomResponse>>
        {
            private readonly IRoomRepository _roomRepository;
            private readonly IMapper _mapper;

            public GetListRoomQueryHandler(IRoomRepository roomRepository, IMapper mapper)
            {
                _roomRepository = roomRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListRoomResponse>> Handle(GetListRoomQuery request, CancellationToken cancellationToken)
            {
                List<Room> rooms = await _roomRepository.GetListAsync();

                List<GetListRoomResponse> response = _mapper.Map<List<GetListRoomResponse>>(rooms);

                return response;
            }
        }
    }
}
