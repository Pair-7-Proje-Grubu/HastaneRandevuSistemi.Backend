using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rooms.Queries.GetById
{
    public class GetByIdRoomQuery : IRequest<GetByIdRoomResponse>
    {
        public int Id { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdRoomQuery, GetByIdRoomResponse>
        {
            private IRoomRepository _roomRepository;
            private IMapper _mapper;

            public GetByIdQueryHandler(IRoomRepository roomRepository, IMapper mapper)
            {
                _roomRepository = roomRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdRoomResponse> Handle(GetByIdRoomQuery request, CancellationToken cancellationToken)
            {
                Room? room = await _roomRepository.GetAsync(r => r.Id == request.Id);

                if (room is null)
                    throw new Exception("Böyle bir veri bulunamadı.");

                GetByIdRoomResponse response = _mapper.Map<GetByIdRoomResponse>(room);

                return response;
            }
        }
    }
}
