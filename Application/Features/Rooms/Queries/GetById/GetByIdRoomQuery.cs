using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rooms.Queries.GetById
{
    public class GetByIdRoomQuery : IRequest<GetByIdRoomResponse>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] RequiredRoles => ["Admin"];
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
                Room? room = await _roomRepository.GetAsync(i => i.Id == request.Id);
                if (room is null)
                    throw new BusinessException("Böyle bir veri bulunamadı.");

                GetByIdRoomResponse response = _mapper.Map<GetByIdRoomResponse>(room);

                return response;
            }
        }
    }
}
