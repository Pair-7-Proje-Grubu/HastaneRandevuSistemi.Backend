using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rooms.Queries.GetList
{
    public class GetListRoomQuery : IRequest<List<GetListRoomResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string[] RequiredRoles => ["Room.Add", "Room.Update"];

        public class GetListQueryHandler : IRequestHandler<GetListRoomQuery, List<GetListRoomResponse>>
        {
            private readonly IRoomRepository _roomRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IRoomRepository roomRepository, IMapper mapper)
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
